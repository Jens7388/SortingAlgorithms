
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 3, 2, 5};
            QuickSort(array, 1, 3);
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        //Compares the last item with the 1 before it, and swaps them if they are not in the correct order. Repeats this process "n" times.
        private static void BubbleSort(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                for(int j = array.Length -1; j >= i; j--)
                {
                    if(array[j] < array[j - 1])
                    {
                        (array[j -1], array[j]) = (array[j], array[j-1]);
                    }
                }
            }
        }

        //Goes through the entire array to check if item "j" is in the correct spot. Repeats for every item
        private static void InsertionSort(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                int j = i;
                int t = array[j];
                while (j > 0 && t < array[j -1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = t;
            }
        }

        //Finds the smallest item in the array, and puts it in the correct place. Repeats for all remaining unsorted items.
        private static void SelectionSort(int[] array)
        {
            for(int i = 0; i < array.Length -1; i++)
            {
                int k = i;
                for(int j = i+1; j < array.Length; j++)
                {
                    if(array[j] < array[k])
                    {
                        k = j;
                    }
                    (array[i], array[k]) = (array[k], array[i]);
                }
            }
        }

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
        }

        private static void HeapSort(int[] array)
        {
            //TODO
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivotIndex = array[(array.Length - 1) / 2];
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
            int[] newArray = new int[right - left + 1];
            int pivotIndex = array[(array.Length - 1) / 2];
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
    }
}
