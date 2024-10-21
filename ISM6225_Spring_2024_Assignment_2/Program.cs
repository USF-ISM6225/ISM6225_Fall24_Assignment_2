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
            // Create a list to store missing numbers
            List<int> missingNumbers = new List<int>();

            // Loop through the array and mark the number's index as negative to track presence
            for (int i = 0; i < nums.Length; i++)
            {
                int val = Math.Abs(nums[i]) - 1; // Convert to 0-index
                if (nums[val] > 0) nums[val] = -nums[val]; // Mark presence by negating the value at that index
            }

            // If the value at an index is positive, it means the number (index+1) is missing
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) missingNumbers.Add(i + 1); // Add missing number
            }

            return missingNumbers; // Return list of missing numbers
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            // Initialize result array to hold sorted values
            int[] result = new int[nums.Length];
            int evenIndex = 0, oddIndex = nums.Length - 1; // Two pointers: even starts from the front, odd from the end

            // Traverse the input array
            foreach (int num in nums)
            {
                if (num % 2 == 0)
                    result[evenIndex++] = num; // Place even numbers at the front
                else
                    result[oddIndex--] = num; // Place odd numbers at the back
            }

            return result; // Return the sorted array
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            // Dictionary to store numbers and their indices
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Traverse through the array
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i]; // Calculate the complement

                // If complement exists in map, return the indices
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                // Otherwise, store the current number and index in the map
                map[nums[i]] = i;
            }

            return new int[0]; // Return empty array if no solution is found
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            // Sort the array
            Array.Sort(nums);

            // Get the length of the array
            int n = nums.Length;

            // The maximum product could be the product of the two smallest numbers (could be negative) and the largest number
            // Or the product of the three largest numbers
            return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            // Edge case: If the decimal number is 0, return "0"
            if (decimalNumber == 0) return "0";

            // Initialize an empty string to store the binary result
            string binary = "";

            // Continue until the decimal number is greater than 0
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary; // Append the remainder of division by 2 (binary digit)
                decimalNumber /= 2; // Divide the decimal number by 2
            }

            return binary; // Return the binary string
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            // Binary search to find the minimum element
            int left = 0, right = nums.Length - 1;

            // While left and right pointers don't converge
            while (left < right)
            {
                int mid = left + (right - left) / 2; // Calculate mid-point

                // If the mid element is greater than the right element, the minimum is on the right
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    right = mid; // Otherwise, it's on the left
            }

            return nums[left]; // Return the minimum element
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // Negative numbers are not palindromes
            if (x < 0) return false;

            int reversed = 0, original = x;

            // Reverse the integer
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10; // Build the reversed number
                x /= 10; // Remove the last digit
            }

            // If the reversed number matches the original, it's a palindrome
            return original == reversed;
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            // Base case: return n if it is 0 or 1
            if (n <= 1) return n;

            // Recursive call to calculate Fibonacci number
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
