using System;
using System.Collections;
using System.Collections.Generic;

namespace Smallest_Difference
{
    class Data
    {
        public int Number { get; set; }
        public int Type { get; set; }
    }
    class Program
    {
        static void Main()
        {
            int[] arr1 = { 1, 3, 15, 11, 2 };
            int[] arr2 = { 23, 127, 235, 19, 8 };
            //solution(arr1, arr2);
            
            int[] arr3 = { 10, 5, 40};
            int[] arr4 = { 50, 90, 80 };
            solution(arr3, arr4);

        }

        static void solution(int[] arr1, int[] arr2)
        {

            List<Data> allNumbers = new List<Data>();

            Array.Sort(arr1);
            Array.Sort(arr2);
            int firstCounter = 0, secondCounter = 0;
            while (firstCounter < arr1.Length || secondCounter < arr2.Length)
            {
                if (firstCounter < arr1.Length && secondCounter < arr2.Length)
                {
                    if (arr1[firstCounter] < arr2[secondCounter])
                    {
                        allNumbers.Add(new Data() { Number = arr1[firstCounter], Type = 1 });
                        firstCounter++;
                    }
                    else
                    {
                        allNumbers.Add(new Data() { Number = arr2[secondCounter], Type = 2 });
                        secondCounter++;
                    }
                }
                else if (firstCounter < arr1.Length)
                {
                    allNumbers.Add(new Data() { Number = arr1[firstCounter], Type = 1 });
                    firstCounter++;
                }
                else
                {
                    allNumbers.Add(new Data() { Number = arr2[secondCounter], Type = 2 });
                    secondCounter++;
                }
            }

            int result = int.MaxValue;
            int[] resultList = new int[2];
            for (int i = 0; i < allNumbers.Count; i++)
            {
                if (allNumbers[i].Type == 1)
                {
                    //search before
                    for (int j = i - 1; j > 0; j--)
                    {
                        if (allNumbers[j].Type == 2)
                        {
                            int currentDiff = Math.Abs(allNumbers[j].Number - allNumbers[i].Number);
                            if (currentDiff < result)
                            {
                                result = currentDiff;
                                resultList[0] = allNumbers[i].Number;
                                resultList[1] = allNumbers[j].Number;
                            }
                        }
                    }
                    //search after 
                    for (int j = i + 1; j < allNumbers.Count; j++)
                    {
                        if (allNumbers[j].Type == 2)
                        {
                            int currentDiff = Math.Abs(allNumbers[j].Number - allNumbers[i].Number);
                            if (currentDiff < result)
                            {
                                result = currentDiff;
                                resultList[0] = allNumbers[i].Number;
                                resultList[1] = allNumbers[j].Number;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(result);
            Console.WriteLine(resultList[0]);
            Console.WriteLine(resultList[1]);
        }
    }
}
