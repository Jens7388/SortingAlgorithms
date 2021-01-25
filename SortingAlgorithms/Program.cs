using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 3, 2 };
            SelectionSort(array);
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
    }
}
