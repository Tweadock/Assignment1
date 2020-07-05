using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            ////set up the initial array and the target number
            Console.WriteLine("Problem 1 Input: marks = [ 1, 2, 3, 4, 5, 6, 6, 6, 7, 9 ], target = 6");
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 7, 9 };
            int x = 6;
            int[] getArrayResult = targetRange(arr, x);
            Console.WriteLine("Problem 1 Response: [" + getArrayResult[0] + ", " + getArrayResult[1] + "]");

            // Exercise 2
            Console.WriteLine("Enter a string for Problem 2: ");
            string entry = Console.ReadLine();

            string strrev = StringReverse(entry);
            Console.WriteLine("Problem 2 Response: " + strrev);

            // Exercise 3
            Console.WriteLine("Problem 3 Input: [ 2, 2, 3, 5, 6 ]");
            int[] arr2 = { 2, 2, 3, 5, 6 };
            int n = arr2.Length;
            Console.WriteLine("Problem 3 Output: " + minSum(arr2, n));

            // Exercise 4
            //creating the array, length argument, and function.

            string myStr = "Aaaababc";
            Console.WriteLine("Problem 4 input: " + myStr);
            string returnValue = FreqSort(myStr);
            Console.WriteLine("Problem 4 output: " + returnValue);

            // Exercise 5
            int[] nums1 = { 2, 5, 5, 2 }, nums2 = { 1, 2, 5 };

            Console.WriteLine("Problem 5 input: nums1 = [2, 5, 5, 2] , nums2 = [1, 2, 5 ]");
            int size;
            int[] intersect1 = Intersect1(nums1, nums2, out size);
            Console.WriteLine("Problem 5 output from first solution:");
            PrintOut(intersect1, size);
            int[] intersect2 = Intersect2(nums1, nums2, out size);
            Console.WriteLine("Problem 5 output from second solution:");
            PrintOut(intersect2, size);

            // Exercise 6 
            //creating the array, length argument, and function.
            Console.WriteLine("Problem 6 Input: arr = [a,b,c,a,b,c], k=3");
            char[] arr6 = { 'a', 'b', 'c', 'a', 'b', 'c' };
            int k = 3;
            Console.WriteLine("Problem 6 output: " +  ContainsDuplicate(arr6, k));
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

        static int minSum(int[] arr, int n)
        {   //setting the sum of the array to start at the first number
            int sum = arr[0];
            //creating a loop to run as long as the length of the array, starting at position 1 because position 0 is already accounted for
            int i = 1;
            while (i < n)
            {   //if i is the same as the number before it, run the while loop to check for while the two numbers are equal, make the number i + 1, then add position i to the sum
                if (arr[i] == arr[i - 1])
                {
                    // propagate the change until the updated number does not match next,
                    // or until the end of the string, in case the new number matches the next
                    // needs to be a loop because the next updated number could go to multiple positions
                    // on the array
                    while ((i < n) && (arr[i] <= arr[i - 1]))
                    {
                        arr[i] = arr[i] + 1;
                        sum = sum + arr[i];
                        i++;
                    }
                }
                else
                {
                    sum = sum + arr[i];
                    i++;
                }
            }
            return sum;
        }
        private static string FreqSort(string myStr)
        {
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
                    if (newCount > maxCount)
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
                        for (int occurrences = 0; occurrences < count; occurrences++)
                            returnValue += keysArray[index];
                    }
                }
            }

            return returnValue;
        }
        private static void PrintOut(int[] intersect1, in int size)
        {
            Console.Write("Intersection : [");
            for (int i = 0; i < size; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(intersect1[i]);
            }
            Console.WriteLine("]");
        }

        private static int[] Intersect1(int[] nums1, int[] nums2, out int arraySize)
        {
            Dictionary<int, int> nums1Dictionary = InsertIntoDictionary(nums1);
            Dictionary<int, int> nums2Dictionary = InsertIntoDictionary(nums2);
            int[] keys1 = nums1Dictionary.Keys.ToArray<int>();
            arraySize = 0;
            int[] retValue = new int[Math.Min(nums1.Length, nums2.Length)];
            for (int i = 0; i < keys1.Length; i++)
            {
                if (nums2Dictionary.ContainsKey(keys1[i]))
                {
                    // we have it on both, but need to check which has the lowest count
                    nums1Dictionary.TryGetValue(keys1[i], out int value1);
                    nums2Dictionary.TryGetValue(keys1[i], out int value2);
                    for (int j = 0; j < Math.Min(value1, value2); j++)
                    {
                        retValue[arraySize++] = keys1[i];
                    }
                }
            }
            return retValue;
        }
        private static int[] Intersect2(int[] nums1, int[] nums2, out int arraySize)
        {
            Dictionary<int, int> nums1Dictionary = InsertIntoDictionary(nums1);
            Dictionary<int, int> intersect = Intersection(nums1Dictionary, nums2);
            int[] keys = intersect.Keys.ToArray<int>();
            int[] retValue = new int[Math.Min(nums1.Length, nums2.Length)];
            arraySize = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                intersect.TryGetValue(keys[i], out int value);
                for (int j = 0; j < value; j++)
                {
                    retValue[arraySize++] = keys[i];
                }
            }
            return retValue;
        }

        public static Dictionary<int, int> InsertIntoDictionary(int[] nums)
        {
            Dictionary<int, int> retValue = new Dictionary<int, int>();
            for (int count = 0; count < nums.Length; count++)
            {
                if (retValue.ContainsKey(nums[count]))
                {
                    retValue.TryGetValue(nums[count], out int newCount);
                    retValue.Remove(nums[count]);
                    newCount++;
                    retValue.TryAdd(nums[count], newCount);
                    // keep track of the overall max number of occurrences
                }
                else // never saw this number; add it to dictionary with count = 1
                {
                    retValue.Add(nums[count], 1);
                }
            }
            return retValue;
        }

        public static Dictionary<int, int> Intersection(Dictionary<int, int> inputDictionary, int[] nums)
        {
            Dictionary<int, int> retValue = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (inputDictionary.ContainsKey(nums[i])) // num on second set is on first set
                {
                    // how many occurrences on first set?
                    inputDictionary.TryGetValue(nums[i], out int count1);
                    // check if we already have in the intersection
                    if (retValue.ContainsKey(nums[i]))
                    {
                        // check how many we already have on the intersection
                        retValue.TryGetValue(nums[i], out int count2);
                        if (count1 > count2) // we have more on the first set than we already counted in the intersection
                        {
                            count2++; // increament the number of occurrences on the intersection
                            retValue.Remove(nums[i]);
                            retValue.TryAdd(nums[i], count2);
                        } // if we alread found all matching items in first list, do not add more.
                    }
                    else // found a match, but was not on the intersection list yet
                    {
                        retValue.TryAdd(nums[i], 1);
                    }
                }
            }
            return retValue;
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

