using System;
class QuickSort {
    int[] arr;
    public QuickSort(int[] array) {
        arr = array;
    }
    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    static int partition(int[] arr, int low, int high)
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
    int? sortUntil(int k, int[] arr, int low, int high) {
        if (low < high) 
        {
            int pi = partition(arr, low, high);

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
        return null;
    }
    public int sortUntil(int k) {
        return sortUntil(k, arr, 0, arr.Length - 1).Value;
    }
}