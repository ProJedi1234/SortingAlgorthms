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

            int m = 0;
            int j = array.Length - 1;
            var pivot = -1;
            while (pivot != k)
            {
                pivot = QuickSort.partition(qs.arr, m, j);

                if (k == pivot)
                    return qs.arr[k - 1];
                else if (k < pivot)
                    j = pivot - 1;
                else
                {
                    m = pivot + 1;
                    k = k - pivot;
                }
            }

            return pivot;
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
