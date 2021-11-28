using System;

namespace SortingAlgorthms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(algorithm1(new int[]{ 12, 11, 13, 5, 6, 7 }, 3));
            Console.WriteLine(algorithm2(new int[]{ 12, 11, 13, 5, 6, 7 }, 3));
        }
        static int algorithm1(int[] array, int k) {
            MergeSort ms = new MergeSort(array);
            ms.sort();

            return array[k - 1];
        }
        static int algorithm2(int[] array, int k)
        {
            QuickSort qs = new QuickSort(array);
            qs.sort();

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
