using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

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

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Initialize a list to store the missing numbers
                List<int> missingNumbers = new List<int>();

                // First pass: Mark the numbers that exist in the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Get the correct index corresponding to the value in the array.
                    // Use Math.Abs() to handle cases where the value has already been marked negative.
                    int index = Math.Abs(nums[i]) - 1;

                    // If the number at the index position is positive, mark it as negative.
                    // This indicates that the number corresponding to this index is present in the array.
                    if (nums[index] > 0)
                    {
                        nums[index] = -nums[index];
                    }
                }

                // Second pass: Identify the missing numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    // If a number at position `i` is still positive, it means the number `i + 1` is missing.
                    if (nums[i] > 0)
                    {
                        missingNumbers.Add(i + 1); // Add the missing number to the result list
                    }
                }

                // Return the list of missing numbers
                return missingNumbers;
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Initialize lists to store even and odd numbers
                List<int> evens = new List<int>();
                List<int> odds = new List<int>();

                // Iterate through the array
                foreach (int num in nums)
                {
                    // If the number is even, add to evens list
                    if (num % 2 == 0)
                    {
                        evens.Add(num);
                    }
                    // If the number is odd, add to odds list
                    else
                    {
                        odds.Add(num);
                    }
                }

                // Combine even and odd numbers (evens first, followed by odds)
                evens.AddRange(odds);

                // Return the combined list as an array
                return evens.ToArray();
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Initialize a dictionary to store numbers and their indices
                Dictionary<int, int> map = new Dictionary<int, int>();

                // Iterate over the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate the complement of the current number (target - current number)
                    int complement = target - nums[i];

                    // Check if the complement already exists in the dictionary
                    if (map.ContainsKey(complement))
                    {
                        // If it exists, return the indices of the complement and current number
                        return new int[] { map[complement], i };
                    }

                    // If complement is not found, add the current number and its index to the dictionary
                    map[nums[i]] = i;
                }

                // If no solution is found, return an empty array
                return new int[0];
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sort the array in ascending order
                Array.Sort(nums);

                // Get the length of the sorted array
                int length = nums.Length;

                // Compare two potential maximum products:
                // 1. The product of the three largest numbers in the sorted array (at the end of the array)
                // 2. The product of the two smallest numbers (could be negative) and the largest number
                // The maximum of these two values is the answer
                return Math.Max(nums[length - 1] * nums[length - 2] * nums[length - 3],
                                nums[0] * nums[1] * nums[length - 1]);
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Convert the decimal number to a binary string using the Convert class
                // The '2' specifies that the target base is binary (base-2)
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Initialize left and right pointers
                int left = 0, right = nums.Length - 1;

                // Perform binary search to find the minimum element
                while (left < right)
                {
                    // Calculate the middle index to split the array
                    int mid = left + (right - left) / 2;

                    // If the middle element is greater than the rightmost element, 
                    // the minimum is in the right half, so we move the left pointer to mid + 1
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        // If the middle element is less than or equal to the rightmost element,
                        // the minimum is in the left half or at mid, so we move the right pointer to mid
                        right = mid;
                    }
                }

                // Return the minimum element, which will be at the left pointer
                return nums[left];
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers cannot be palindromes, so return false
                if (x < 0) return false;

                // Store the original number for comparison later
                int originalNumber = x;
                // Variable to store the reversed number
                int reversedNumber = 0;

                // Reverse the number digit by digit
                while (x > 0)
                {
                    // Get the last digit of the number
                    int remainder = x % 10;
                    // Add the last digit to the reversed number after shifting the existing digits to the left
                    reversedNumber = reversedNumber * 10 + remainder;
                    // Remove the last digit from the number
                    x /= 10;
                }

                // Check if the reversed number is equal to the original number
                return originalNumber == reversedNumber;
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Base cases: if n is 0 or 1, return n directly
                if (n <= 1) return n;

                // Initialize variables to store the previous two Fibonacci numbers
                int previous = 0, current = 1;

                // Loop starts from 2, as the first two Fibonacci numbers are already handled
                for (int i = 2; i <= n; i++)
                {
                    // Calculate the next Fibonacci number by adding the two previous numbers
                    int next = previous + current;
                    // Update the previous number to the current one
                    previous = current;
                    // Update the current number to the newly calculated Fibonacci number
                    current = next;
                }

                // Return the nth Fibonacci number
                return current;
            }
            catch (Exception)
            {
                // If any exception occurs, rethrow it
                throw;
            }
        }
    }
}