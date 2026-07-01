using System;
public class Sorting
{
    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
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
        BubbleSort(dataset);
        Console.WriteLine("After Sorting:");
        PrintArray(dataset);
    }
}