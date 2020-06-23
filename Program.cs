using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)

        ////Problem 1
        ////set up the initial array and the target number
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 7, 9 };
            int x = 6;
            int[] getArrayResult = GetArray(arr, x);
            Console.WriteLine(getArrayResult[0]);
            Console.WriteLine(getArrayResult[1]);
        }

        static int[] GetArray(int[] marks, int target)

        ////set up the function, plus the first and last numbers.
        ////with the for loop, say that if the target number is not equal to i, move on, if not and first is == -1, set it equal to the target, then continue to make last equal to i until the end
        {
            int n = marks.Length;
            int first = -1, last = -1;

            int[] retValue = new int[2];

            for (int i = 0; i < n; i++)
            {
                if (target == marks[i])
                {
                    if (first == -1)
                        first = i;
                    last = i;
                }
            }

            retValue[0] = first;
            retValue[1] = last;
            return retValue;
        }
    }
}
    
