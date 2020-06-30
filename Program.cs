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

        //question 2
        {

            string myStr = "Rocky was here";
            Console.WriteLine("my input is: " + myStr);
            string rev = StringReverse(myStr);

            Console.WriteLine("reversed string is: " + rev);
            Console.ReadLine();
        }
        
        private static string StringReverse(string s)
        {
            string returnValue = "";
            //set length equal to 1 minus the string length to avoid errors
            int len = s.Length - 1;
            //take the string starting with the highest number and place them until the end, moving down one number at a time.
            while (len >= 0)
            {
                returnValue = returnValue + s[len];
                len--;
            }

            return returnValue;
        }
    }
}
    
