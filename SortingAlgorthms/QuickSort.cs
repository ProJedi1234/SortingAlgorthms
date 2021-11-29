using System;
class QuickSort {
    public int[] arr;
    public QuickSort(int[] array) {
        arr = array;
    }
    #region Helpers
    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    public static int partition(int[] arr, int low, int high)
    {
        // pivot
        int pivot = arr[low]; 
        
        // Index of smaller element and
        // indicates the right position
        // of pivot found so far
        int i = low; 

        for(int j = low + 1; j <= high; j++)
        {
            // If current element is smaller 
            // than the pivot
            if (arr[j] < pivot) 
            {                
                // Increment index of 
                // smaller element
                i++; 
                swap(arr, i, j);
            }
        }
        swap(arr, i, low);
        return (i + 1);
    }
    public int partitionMM(int[] arr, int low, int high)
    {
        // pivot
        int pivot = low == 0 && high == arr.Length - 1 ? MedianOfMedians(arr, 1) : arr[low];

        // Index of smaller element and
        // indicates the right position
        // of pivot found so far
        int i = low;

        for (int j = low + 1; j <= high; j++)
        {
            // If current element is smaller 
            // than the pivot
            if (arr[j] < pivot)
            {
                // Increment index of 
                // smaller element
                i++;
                swap(arr, i, j);
            }
        }
        swap(arr, i, low);
        return (i + 1);
    }
    public int MedianOfMedians(int[] arr, int x)
    {
        if (arr.Length < 5)
            return 2 * (int)(Math.Pow(5, x) / 2);

        var n = arr.Length / 5 + (arr.Length % 5 != 0 ? 1 : 0);
        var newArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            var low = i * 5;
            var high = Math.Min((i + 1) * 5, arr.Length) - 1;

            sort(arr, low, high);

            newArray[i] = arr[(low + high) / 2];
        }

        return MedianOfMedians(newArray, x + 1);
    }
    #endregion
    #region Sorting
    void sort(int[] arr, int low, int high)
    {
        if (low < high) 
        {
            int pi = partition(arr, low, high);

            // Separately sort elements before
            // partition and after partition
            sort(arr, low, pi - 1);
            sort(arr, pi + 1, high);
        }
    }
    public void sort() {
        sort(arr, 0, arr.Length - 1);
    }
    #endregion
    #region Sort Until
    int? sortUntil(int k, int[] arr, int low, int high, bool MM = false) {
        if (low < high) 
        {
            int pi = 0;

            if (MM)
                pi = partitionMM(arr, low, high);
            else
                pi = partition(arr, low, high);

            if (k == pi) {
                return arr[pi - 1];
            }

            // Separately sort elements before
            // partition and after partition
            if (k - 1 < pi)
                return sortUntil(k, arr, low, pi - 1);
            else
                return sortUntil(k, arr, pi + 1, high);
        }
        return arr[0];
    }
    public int sortUntil(int k, bool MM = false) {
        return sortUntil(k, arr, 0, arr.Length - 1, MM).Value;
    }
    #endregion
}