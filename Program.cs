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
            int maxCount = 0;

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
                    // keep track of the overall max number of occurrences
                    if(newCount>maxCount)
                        maxCount = newCount;
                } 
                else // never saw this letter; add it to dictionary with count = 1
                {
                    lettersDictionary.Add(myStr[i], 1);
                }
            }
            char[] keysArray = lettersDictionary.Keys.ToArray<char>();
            // at this point, we know what is the max number of occurrences
            // append to the output string
            string returnValue = "";
            for (int count = maxCount; count > 0; count--)
            {
                for (int index = 0; index < keysArray.Length; index++)
                {
                    lettersDictionary.TryGetValue(keysArray[index], out int value);
                    if (value == count)
                    {
                        for (int occurrences = 0; occurrences < count; occurrences ++)
                            returnValue += keysArray[index];
                    }                
                }
            }
            Console.WriteLine(returnValue);
        }

    }
}
    
