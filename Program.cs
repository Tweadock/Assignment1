using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)

     
        {   //problem #4 
            //creating the array, length argument, and function.

            string myStr = "Aaaababc";
            int len = myStr.Length;

            Dictionary<char, int> lettersDictionary = new Dictionary<char, int>();

            for (int i = 0; i < len; i++)
            {
                // Already saw the letter; get the count, increment, and save to dictionary.
                if (lettersDictionary.ContainsKey(myStr[i]))
                {
                    int newCount = 0;
                    lettersDictionary.TryGetValue(myStr[i], out newCount);
                    lettersDictionary.Remove(myStr[i]);
                    newCount++;
                    lettersDictionary.TryAdd(myStr[i], newCount);
                } 
                else // never saw this letter; add it to dictionary with count = 1
                {
                    lettersDictionary.Add(myStr[i], 1);
                }
            }

        }

    }
}
    
