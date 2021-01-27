
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 3, 2, 5, 7, 6, 9, 8};
            HeapSort(array, array.Length -1);
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        private static void BubbleSort(int[] array)
        {
            //Extract items from array
            for(int i = 1; i < array.Length; i++)
            {
                //Find last item in array
                for(int j = array.Length -1; j >= i; j--)
                {
                    //Swap items if item number "j - 1" is larger than item "j"
                    if(array[j] < array[j - 1])
                    {
                        (array[j -1], array[j]) = (array[j], array[j-1]);
                    }
                }
            }
        }

        private static void InsertionSort(int[] array)
        {
            //Extract items from array
            for(int i = 1; i < array.Length; i++)
            {
                int j = i;
                int t = array[j];

                //While item "j" is NOT ordered correctly, move it around the array until it is
                while (j > 0 && t < array[j -1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = t;
            }
        }

        private static void SelectionSort(int[] array)
        {
            //Extract items from array
            for(int i = 0; i < array.Length -1; i++)
            {
                int k = i;

                //Find smallest item in array
                for(int j = i+1; j < array.Length; j++)
                {
                    //If the current item is smaller than the first unordered item, swap the two items.
                    if(array[j] < array[k])
                    {
                        k = j;
                    }
                    (array[i], array[k]) = (array[k], array[i]);
                }
            }
        }

        /*
        private static void TreeSort(int[] array)
        {
            SortedSet<int> t = new();
            for(int i = 0; i < array.Length; i++)
            {
                t.Add(array[i]);
            }
            FillArray(t, array, 0);
        }
        
        private static int FillArray(SortedSet<int> t, int[] array, int j)
        {
            if(t.Count != 0)
            {
                j = FillArray(t, array, j);
               // array[j++] = root(t);
              //  j = FillArray(t.Max, array, j)
            }
            return j;
        }*/

        private static void HeapSort(int[] array, int n)
        {
            // Build heap (rearrange array)
            for(int i = n / 2; i >= 0; i--)
            {
                Heapify(array, n, i);
            }
            // One by one extract an element from heap
            for(int i = n; i > 0; i--)
            {
                // Move current root to end 
                (array[0], array[i]) = (array[i], array[0]);
                // call max heapify on the reduced heap
                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int left = 2 * i + 1;
            int right = 2 * i + 2; 

            // If left child is larger than root
            if(left < n && array[left] > array[largest])
            {
                largest = left;
            }

            // If right child is larger than largest so far
            if(right < n && array[right] > array[largest])
            {
                largest = right;
            }

            // If largest is not root
            if(largest != i)
            {
                (array[largest], array[i]) = (array[i], array[largest]);

                // Recursively heapify the affected sub-tree
                Heapify(array, n, largest);
            }
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                //int pivotIndex = 
                    OtherPartition(array, left, right);
                //QuickSort(array, left, pivotIndex - 1);
           //     QuickSort(array, pivotIndex + 1, right);
            }
        }


        //Not in use!
        private static int Partition(int[] array, int left, int right)
        {
            int pivotIndex = (array.Length - 1) / 2;
            int pivot = array[pivotIndex];
            (array[pivotIndex], array[right]) = (array[right], array[pivotIndex]);
            int leftMark = left;
            int rightMark = right - 1;

            while(leftMark <= rightMark)
            {
                while(leftMark <= rightMark && array[leftMark] <= pivot)
                {
                    leftMark++;
                }
                while(leftMark <= rightMark && array[rightMark] >= pivot)
                {
                    rightMark--;
                }
                if(leftMark < rightMark)
                {
                    (array[leftMark++], array[rightMark--]) = (array[rightMark--], array[leftMark++]);
                }
            }
            (array[leftMark], array[rightMark]) = (array[rightMark], array[leftMark]);
            return leftMark; 
        }

        private static int OtherPartition(int[] array, int left, int right)
        {
            //Create new array half as long as the original array
            int[] newArray = new int[right - left + 1];

            //Find centre index of original array
            int pivotIndex = (array.Length - 1) / 2;
            int pivot = array[pivotIndex];

            int arrayCount = left;
            int newArrayCount = 1;

            for(int i = left; i <= right; i++)
            {
                if(i== pivotIndex)
                {
                    newArray[0] = array[i];
                }
                else if(array[i] < pivot || (array[i] == pivot && i < pivotIndex))
                {
                    array[arrayCount++] = array[i];
                }
                else
                {
                    newArray[newArrayCount++] = array[i];
                }
            }
            for(int i = 0; i < newArrayCount; i++)
            {
                array[arrayCount++] = newArray[i];
            }
            return right - newArrayCount + 1;
        }

        //Splits array into 2 smaller arrays, orders items in the first array, then 1 by 1 inserts and sorts all items from the second array to the first.
        private static void MergeSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private static void Merge(int[] array, int left, int mid, int right)
        {
            int[] newArray = new int[right - left + 1];
            int newArrayCount = 0;
            int lCount = left;
            int rCount = mid + 1;
            while((lCount <= mid) && (rCount <= right))
            {
                if(array[lCount] <= array[rCount])
                {
                    newArray[newArrayCount++] = array[lCount++];
                }
                else
                {
                    newArray[newArrayCount++] = array[rCount++];
                }
            }
            if(lCount > mid)
            {
                while(rCount <= right)
                {
                    newArray[newArrayCount++] = array[rCount++];
                }
            }
            else
            {
                while(lCount <= mid)
                {
                    newArray[newArrayCount++] = array[lCount++];
                }
            }
            for( newArrayCount = 0; newArrayCount < right - left + 1; newArrayCount++)
            {
                array[left + newArrayCount] = newArray[newArrayCount];
            }
        }
    }
}
