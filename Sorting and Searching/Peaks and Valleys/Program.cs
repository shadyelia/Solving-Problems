using System;

namespace Peaks_and_Valleys
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 9, 1, 0, 4, 8, 7 };
            BuildPeaksAndValleysArray(arr);

            int[] arr2 = { 5, 3, 1, 2, 3 };
            BuildPeaksAndValleysArray(arr2);
        }

        private static void BuildPeaksAndValleysArray(int[] arr)
        {
            int len = arr.Length - 1;
            for (int i = 0; i <= len; i++)
            {
                if (i % 2 == 0 && i + 1 < len && arr[i] < arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                }
                if (i % 2 != 0 && i + 1 < len && arr[i] > arr[i + 1])
                {
                    Swap(arr, i + 1, i);
                }
            }
            Print(arr);
        }

        private static void Swap(int[] arr, int left, int right)
        {
            var buffer = arr[left];
            arr[left] = arr[right];
            arr[right] = buffer;
        }

        private static void Print(int[] arr)
        {
            foreach (var number in arr)
            {
                Console.Write(number);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
