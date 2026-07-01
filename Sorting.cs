using System;
using System.Threading.Tasks;

public class Sorting
{
    // Quick Sort
    public static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            // Ordenación paralela para conjuntos grandes
            if (high - low > 1000)
            {
                Parallel.Invoke(
                    () => QuickSort(arr, low, pivotIndex - 1),
                    () => QuickSort(arr, pivotIndex + 1, high)
                );
            }
            else
            {
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int swap = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = swap;

        return i + 1;
    }

    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        int[] dataset = { 50, 20, 40, 10, 30 };

        Console.WriteLine("Before Sorting:");
        PrintArray(dataset);

        QuickSort(dataset, 0, dataset.Length - 1);

        Console.WriteLine("After Sorting:");
        PrintArray(dataset);
    }
}