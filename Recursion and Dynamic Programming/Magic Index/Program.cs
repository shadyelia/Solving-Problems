using System;
using System.Linq;

namespace Magic_Index
{
    class Program
    {
        static void Main()
        {
            int[] arr = { -1, 0, 1, 2, 4, 10 };
            Console.WriteLine("The index is : " + FindTheMagicIndex2(arr));
            Console.WriteLine("The index is : " + FindTheMagicIndex(arr));

            int[] arr2 = { -40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13 };
            Console.WriteLine("The index is : " + FindTheMagicIndex2(arr2));
            Console.WriteLine("The index is : " + FindTheMagicIndex(arr2));

            int[] arr3 = { -40, -40, -1, -1, 3, 3, 5, 6, 8, 10, 10 };
            Console.WriteLine("The index is : " + FindTheMagicIndex2(arr3));
            Console.WriteLine("The index is : " + FindTheMagicIndex(arr3));
        }

        static int FindTheMagicIndex(int[] arr)
        {
            int index = FindTheMagicIndex(arr, arr.Length / 2, arr.Length / 2);
            return index;
        }

        static int FindTheMagicIndex(int[] arr, int actualIndex, int middleIndex)
        {
            if (arr.Length == 0) return -1;
            if (arr[middleIndex] == actualIndex) return actualIndex;

            if (actualIndex > arr[middleIndex])
            {
                return FindTheMagicIndex(arr.Skip(middleIndex).ToArray(), actualIndex + (middleIndex / 2), middleIndex / 2);
            }
            else
            {
                return FindTheMagicIndex(arr.Take(middleIndex).ToArray(), actualIndex + (middleIndex * 2), middleIndex * 2);
            }
        }

        static int FindTheMagicIndex2(int[] arr)
        {
            int index = FindTheMagicIndex2(arr, 0, arr.Length);
            return index;
        }

        static int FindTheMagicIndex2(int[] arr, int start, int end)
        {
            if (start > end) return -1;
            int middleIndex = (start + end) / 2;
            if (arr[middleIndex] == middleIndex) return middleIndex;

            if (middleIndex > arr[middleIndex])
            {
                return FindTheMagicIndex2(arr, middleIndex + 1, end);
            }
            else
            {
                return FindTheMagicIndex2(arr, start, middleIndex - 1);
            }
        }

    }
}
