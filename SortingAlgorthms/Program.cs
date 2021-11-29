using System;
using System.Linq;

namespace SortingAlgorthms
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var sizes = new int[]{ 10, 50, 100, 500, 1000, 5000, 10000 };
            foreach (var size in sizes)
            {
                var kTests = new int[] { 1, size/4, size/2, 3*size/4, size };
                foreach (var k in kTests)
                {
                    var arr = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        arr[i] = rnd.Next(1, 16);
                    }
                    Console.WriteLine("Array of size {0} and k of {1}", size, k);
                    //printArray(arr);
                    Console.WriteLine("algorithm 1:\t{0} ms", runTester(() => { return algorithm1(arr, k); }));
                    Console.WriteLine("algorithm 2:\t{0} ms", runTester(() => { return algorithm2(arr, k); }));
                    Console.WriteLine("algorithm 3:\t{0} ms", runTester(() => { return algorithm3(arr, k); }));
                    Console.WriteLine("algorithm 4:\t{0} ms", runTester(() => { return algorithm4(arr, k); }));
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------------\n");
            }

            //Console.WriteLine();

            //var arr = new int[] { 1, 5, 3, 4, 2, 6, 7, 8, 9, 10, 11, 12, 20, 14, 15, 17, 16, 18, 19, 13, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            //Random random = new Random();
            //arr = arr.OrderBy(x => random.Next()).ToArray();

            //QuickSort qs = new QuickSort(arr);
            //printArray(qs.arr);
            //var median = qs.MedianOfMedians(qs.arr, 0);
            //Console.WriteLine(median);
            //printArray(qs.arr);
            //Console.WriteLine(qs.arr[median]);
        }
        static double runTester(Func<int> func)
        {
            var watch = new System.Diagnostics.Stopwatch(); //create a stop watch to time the algorithm
            watch.Start();
            func();
            watch.Stop();

            return watch.Elapsed.TotalMilliseconds;
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
                pivot = QuickSort.partition(qs.arr, m, j) - m;

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
        static int algorithm3(int[] array, int k)
        {
            QuickSort qs = new QuickSort(array);
            return qs.sortUntil(k);
        }
        static int algorithm4(int[] array, int k)
        {
            QuickSort qs = new QuickSort(array);
            return qs.sortUntil(k, true);
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
