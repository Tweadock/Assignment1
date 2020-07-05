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
        {
            ////set up the initial array and the target number
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 7, 9 };
            int x = 6;
            int[] getArrayResult = targetRange(arr, x);
            Console.WriteLine("Problem 1 Response: [" + getArrayResult[0] + ", " + getArrayResult[1] + "]");

            // Exercise 2
            Console.WriteLine("Enter a string: ");
            string entry = Console.ReadLine();

            string strrev = StringReverse(entry);
            Console.WriteLine(strrev);
            Console.ReadLine();
        }

        static int[] targetRange(int[] marks, int target)

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

        //updated solution to #2, using a nested if inside of a foreach loop to catch any punctuation
        private static string StringReverse(string entry)
        {
            string strrev = "";
            string ph = "";
            //setting up an array of common punctuation to look for
            char[] punc = ".,?!".ToCharArray();
            foreach (char ch in entry)
            {   //maintaining the whitespace of the string entry
                if (ch != ' ')
                {   //if the character does not exist in the punctuation array, the placeholder is set to the character is put at the start of the string, if it does exist it is put at the end.
                    if (Array.IndexOf(punc, ch) == -1)
                        ph = ch + ph;
                    else
                        ph = ph + ch;
                    //Console.WriteLine(ph);
                }
                else
                {   //set the final text store equal to itself, plus the word from the place holder, then reset placeholder to blank
                    strrev = strrev + ph + " ";
                    ph = "";
                }
            }
            strrev = strrev + ph + " ";
            return strrev;
        }
    }
}
   

    
