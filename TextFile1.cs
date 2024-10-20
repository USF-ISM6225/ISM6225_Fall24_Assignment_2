using System;
using System.Collections.Generic;

namespace Assignment_2
{
	class Program
	{
		static void Main(string[] args)
		{
			// Question 1: Find Missing Numbers in Array
			Console.WriteLine("Question 1:");
			int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
			IList<int> missingNumbers = FindMissingNumbers(nums1);
			Console.WriteLine(string.Join(",", missingNumbers));


			// Question 1: Find Missing Numbers in Array
			public static IList<int> FindMissingNumbers(int[] nums)
			{
				List<int> missingNums = new List<int>();
				int length = nums.Length;

				// Mark the presence of numbers in the array
				for (int i = 0; i < length; i++)
				{
					int index = Math.Abs(nums[i]) - 1;
					if (nums[index] > 0)
					{
						nums[index] = -nums[index];
					}
				}

				// Find the missing numbers by checking positive indices
				for (int i = 0; i < length; i++)
				{
					if (nums[i] > 0)
					{
						missingNums.Add(i + 1);
					}
				}
				return missingNums;
			}