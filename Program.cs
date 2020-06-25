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
            // At this point, dictionary has counts of letters
            // find the max count on the dictionary
            int maxCount = 0;
            char[] keysArray = lettersDictionary.Keys.ToArray<char>();
            for (int index = 0; index < keysArray.Length; index++)
            {
                int Value;
                lettersDictionary.TryGetValue(keysArray[index], out Value);
                if (Value > maxCount)
                {
                    maxCount = Value;
                }
            }
            // at this point, we know what is the max number of occurrences
            // append to the output string
            string returnValue = "";
            for (int count = maxCount; count > 0; count--)
            {
                for (int index = 0; index < keysArray.Length; index++)
                {
                    int value;
                    lettersDictionary.TryGetValue(keysArray[index], out value);
                    if (value == count)
                        returnValue += keysArray[index];
                }
            }
            Console.WriteLine(returnValue);
        }

    }
}
    
