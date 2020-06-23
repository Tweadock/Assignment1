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
        //{
        //    int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 7, 9 };
        //    int x = 6;
        //    GetArray(arr, x);


        //}

        //static void GetArray(int[] marks, int target)

        ////set up the function, plus the first and last numbers.
        ////with the for loop, say that if the target number is not equal to i, move on, if not and first is == -1, set it equal to the target, then continue to make last equal to i until the end
        //{
        //    int n = marks.Length;
        //    int first = -1, last = -1;

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (target != marks[i])
        //            continue;
        //        if (first == -1)
        //            first = i;
        //        last = i;
        //    }

        //    Console.WriteLine(first);
        //    Console.WriteLine(last);






        //    //question 2
        //    {
        //        string rev = "";
        //        string myStr = "Rocky was here";
        //        Console.WriteLine("my input is: " + myStr);
        //        //set length equal to 1 minus the string length to avoid errors
        //        int len;
        //        len = myStr.Length - 1;
        //        //take the string starting with the highest number and place them until the end, moving down one number at a time.
        //        while (len >= 0)
        //        {
        //            rev = rev + myStr[len];
        //            len--;
        //        }

        //        Console.WriteLine("reversed string is: " + rev);
        //        Console.ReadLine();


                {   //problem #3 
                    //creating the array, length argument, and function.
                    int[] arr = { 2, 2, 3, 5, 6 };
                    int n = arr.Length;
                    Console.WriteLine(minSum(arr, n));
                }
                static int minSum(int[] arr, int n)
                {   //setting the sum of the array to start at the first number
                    int sum = arr[0];
                    //creating a loop to run as long as the length of the array, starting at position 1 because position 0 is already accounted for
                    for (int i = 1; i < n; i++)
                    {   //if i is the same as the number before it, run the while loop to check for while the two numbers are equal, make the number i + 1, then add position i to the sum
                        if (arr[i] == arr[i - 1])
                        {
                            int k = i;
                            while (k < n && arr[k] <= arr[k - 1])
                            {
                                arr[k] = arr[k] + 1;
                                k++;
                            }
                        }
                        sum = sum + arr[i];
                    }
                    return sum;
                }
            }
        }
    
