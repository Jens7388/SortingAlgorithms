using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 4, 1, 3, 2 };
            BubbleSort(array);
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        //Compares the last index with the 1 before it, and swaps them if they are not in the correct order. Repeats this process "n" times.
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
    }
}
