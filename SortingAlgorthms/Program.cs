using System;

namespace SortingAlgorthms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(algorithm1(new int[]{ 12, 11, 13, 5, 6, 7 }, 3));

            QuickSort qs = new QuickSort(new int[]{ 12, 11, 13, 5, 6, 7, 14 });
            Console.WriteLine(qs.sortUntil(k: 3));
        }
        static int algorithm1(int[] array, int k) {
            MergeSort ob = new MergeSort(array);
            ob.sort();

            return array[k - 1];
        }
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
