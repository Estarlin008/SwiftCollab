using System;
using System;
using System.Collections.Generic;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
    }
}

public class BinarySearchTree
{
    public Node Root;

    // Inserción iterativa para evitar llamadas recursivas innecesarias
    public void Insert(int value)
    {
        Node newNode = new Node(value);

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        Node current = Root;

        while (true)
        {
            if (value < current.Value)
            {
                if (current.Left == null)
                {
                    current.Left = newNode;
                    return;
                }

                current = current.Left;
            }
            else if (value > current.Value)
            {
                if (current.Right == null)
                {
                    current.Right = newNode;
                    return;
                }

                current = current.Right;
            }
            else
            {
                // Evita insertar valores duplicados
                return;
            }
        }
    }

    // Búsqueda eficiente O(h)
    public bool Search(int value)
    {
        Node current = Root;

        while (current != null)
        {
            if (value == current.Value)
                return true;

            if (value < current.Value)
                current = current.Left;
            else
                current = current.Right;
        }

        return false;
    }

    // Recorrido InOrder
    public void PrintInOrder(Node node)
    {
        if (node == null)
            return;

        PrintInOrder(node.Left);
        Console.Write(node.Value + " ");
        PrintInOrder(node.Right);
    }
}

public class TaskExecutor
{
    private Queue<string> taskQueue = new Queue<string>();
    public void AddTask(string task)
    {
        taskQueue.Enqueue(task);
    }
    public void ProcessTasks()
    {
        while (taskQueue.Count > 0)
        {
            string task = taskQueue.Dequeue();
            Console.WriteLine($"Processing task: {task}");
            ExecuteTask(task);
        }
    }
    private void ExecuteTask(string task)
    {
        if (task == null)
        {
            throw new Exception("Task is null");
        }
        if (task.Contains("Fail"))
        {
            throw new Exception("Task execution failed");
        }
        Console.WriteLine($"Task {task} completed successfully.");
    }
}
class Program
{
    static void Main()
    {
        TaskExecutor executor = new TaskExecutor();
        executor.AddTask("Task 1");
        executor.AddTask(null); // This will cause a crash
        executor.AddTask("Fail Task"); // This will also cause a crash
        executor.AddTask("Task 2");
        executor.ProcessTasks();
    }
}