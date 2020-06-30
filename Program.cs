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
            int[] nums1 = { 2, 5, 5, 2 }, nums2 = { 5, 2, 5 };
            int[] intersect1 = Intersect2(nums1, nums2);
            Console.Write("Intersection : [");
            for(int i = 0; i < intersect1.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(intersect1[i]);
            }
            Console.WriteLine("]");
            Console.ReadLine();
        }

        private static int[] Intersect2(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> nums1Dictionary = InsertIntoDictionary(nums1);
            Dictionary<int, int> intersect = Intersection(nums1Dictionary, nums2);
            int[] keys = intersect.Keys.ToArray<int>();
            int[] retValue = new int[Math.Min(nums1.Length, nums2.Length)];
            int arraySize = 0;
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
    }
}
    
