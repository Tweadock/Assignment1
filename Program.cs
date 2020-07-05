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
        {   //problem # 6
            //creating the array, length argument, and function.
            char[] arr = { 'a', 'b', 'c', 'a', 'b', 'c' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));
            Console.ReadLine();
}
        static bool ContainsDuplicate(char[] arr, int n)
        {
            bool returnValue = false;
            int i = 0;
            //starts a nested loop that executes as long as returnvalue is true and i is less than the length of the array
            while ((!returnValue) && (i < arr.Length))
            {
                int j = i + 1;
              //the inner loop checks that arrays i and j are equal and continues as long as
              //j is less than he value in the duplicates array n nad is less than the # of elements in the original array
              //repeats to next j and i
                while ((!returnValue) && (j <= i + n) && (j < arr.Length))
                {
                    returnValue = (arr[i] == arr[j]);
                    j++;
                }
                i++;
            }
            return returnValue;
        }
    }
}
    
