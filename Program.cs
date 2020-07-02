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
        {   //problem #3 
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
            while ((!returnValue) && (i < arr.Length))
            {
                int j = i + 1;
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
    
