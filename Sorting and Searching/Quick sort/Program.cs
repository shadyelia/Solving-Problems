using System;

namespace Quick_sort
{
    class Program
    {
        static void Main()
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
         ;
            int res = QuickSort(arr);

            Console.WriteLine(res);
        }
        static int QuickSort(int[] arr)
        {
            int result = 0;
            QuickSort(arr, 0, arr.Length - 1, ref result);
            return result;
        }

        private static void QuickSort(int[] arr, int left, int right, ref int result)
        {
            int index = Partition(arr, left, right, ref result);
            if (left < index - 1)
            {
                QuickSort(arr, left, index - 1, ref result);
            }
            if (index < right)
            {
                QuickSort(arr, index, right, ref result);
            }
        }

        private static int Partition(int[] arr, int left, int right, ref int result)
        {
            int pivot = arr[(left + right) / 2];
            while (left <= right)
            {
                while (arr[left] < pivot) left++;
                while (arr[right] > pivot) right--;

                if (left <= right)
                {
                    swap(arr, left, right);
                    left++;
                    right--;
                    result++;
                }
            }
            return left;
        }

        private static void swap(int[] arr, int left, int right)
        {
            var buffer = arr[left];
            arr[left] = arr[right];
            arr[right] = buffer;
        }

    }
}
