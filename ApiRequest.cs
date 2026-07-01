using System;
using System.Collections.Generic;

public class ApiRequest
{
    public string Endpoint { get; set; }
    public int Priority { get; set; }

    public ApiRequest(string endpoint, int priority)
    {
        Endpoint = endpoint;
        Priority = priority;
    }
}

public class ApiRequestQueue
{
    // PriorityQueue utiliza internamente un Min-Heap (Binary Heap)
    private readonly PriorityQueue<ApiRequest, int> requests =
        new PriorityQueue<ApiRequest, int>();

    // Objeto para sincronizar el acceso concurrente
    private readonly object _lock = new object();

    // Inserta una sola petición
    public void Enqueue(ApiRequest request)
    {
        lock (_lock)
        {
            requests.Enqueue(request, request.Priority);
        }
    }

    // Inserta varias peticiones al mismo tiempo (Batch Enqueue)
    public void EnqueueRange(IEnumerable<ApiRequest> apiRequests)
    {
        lock (_lock)
        {
            foreach (var request in apiRequests)
            {
                requests.Enqueue(request, request.Priority);
            }
        }
    }

    // Extrae la petición de mayor prioridad (menor número)
    public ApiRequest? Dequeue()
    {
        lock (_lock)
        {
            if (requests.Count == 0)
                return null;

            return requests.Dequeue();
        }
    }

    // Devuelve la cantidad de solicitudes pendientes
    public int Count
    {
        get
        {
            lock (_lock)
            {
                return requests.Count;
            }
        }
    }

    // Indica si la cola está vacía
    public bool IsEmpty
    {
        get
        {
            lock (_lock)
            {
                return requests.Count == 0;
            }
        }
    }
}