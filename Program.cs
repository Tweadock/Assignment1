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
            //updated solution to #2, using a nested if inside of a foreach loop to catch any punctuation
        {
            Console.WriteLine("Enter a string: ");
            string entry = Console.ReadLine();
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
            Console.WriteLine(strrev);
            Console.ReadLine();


        }


    }

    //static void Main(string[] args)

    ////question 2
    //{

    //    string myStr = "Rocky was here";
    //    Console.WriteLine("my input is: " + myStr);
    //    string rev = StringReverse(myStr);

    //    Console.WriteLine("reversed string is: " + rev);
    //    Console.ReadLine();
    //}

    //private static string StringReverse(string s)
    //{
    //    string returnValue = "";
    //    //set length equal to 1 minus the string length to avoid errors
    //    int len = s.Length - 1;
    //    //take the string starting with the highest number and place them until the end, moving down one number at a time.
    //    while (len >= 0)
    //    {
    //        returnValue = returnValue + s[len];
    //        len--;
    //    }

    //    return returnValue;
}
   

    
