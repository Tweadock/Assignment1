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

		{   //problem #3 
			//creating the array, length argument, and function.
			int[] arr = { 2, 2, 3, 5, 6 };
			int n = arr.Length;
			Console.WriteLine(minSum(arr, n));
		}
		static int minSum(int[] arr, int n)
		{   //setting the sum of the array to start at the first number
			int sum = 0;
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
	
