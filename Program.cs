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
            string rev = "";
            string myStr = "Rocky was here";
            Console.WriteLine("my input is: " + myStr);
            //set length equal to 1 minus the string length to avoid errors
            int len = myStr.Length - 1;
            //take the string starting with the highest number and place them until the end, moving down one number at a time.
            while (len >= 0)
            {
                rev = rev + myStr[len];
                len--;
            }

            Console.WriteLine("reversed string is: " + rev);
            Console.ReadLine();
        }
    }
}
    
