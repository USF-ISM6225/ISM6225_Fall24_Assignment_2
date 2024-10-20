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
            // List to store missing numbers
            List<int> missingNumbers = new List<int>();

            // Mark each index corresponding to the value at that index as negative 
            // This helps in tracking the numbers that are present in the array
            for (int i = 0; i < nums.Length; i++)
            {
                int val = Math.Abs(nums[i]) - 1; // Use absolute value to handle previously marked numbers
                if (nums[val] > 0) // If value at that index is positive, mark it negative
                    nums[val] = -nums[val];
            }

            // If the value at an index is still positive, 
            // it means the corresponding number was missing from the array
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    missingNumbers.Add(i + 1); // The number is index + 1
            }
            return missingNumbers; // Return the list of missing numbers
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            // Create a result array to store the sorted numbers
            int[] result = new int[nums.Length];

            // Two pointers: 
            // evenIndex starts from the beginning and stores even numbers
            // oddIndex starts from the end and stores odd numbers
            int evenIndex = 0, oddIndex = nums.Length - 1;

            // Loop through the input array
            foreach (int num in nums)
            {
                // If the number is even, place it at the next evenIndex
                if (num % 2 == 0)
                    result[evenIndex++] = num;
                else
                    // If the number is odd, place it at the next oddIndex
                    result[oddIndex--] = num;
            }
            return result; // Return the array sorted by parity
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            // Dictionary to store the value and its index in the array
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Loop through the array
            for (int i = 0; i < nums.Length; i++)
            {
                // Calculate the complement that when added to nums[i] gives the target
                int complement = target - nums[i];

                // If the complement exists in the dictionary, return the indices
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                // Otherwise, store the current number and its index in the dictionary
                map[nums[i]] = i;
            }
            return new int[0]; // If no solution is found, return an empty array
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            // Sort the array to easily access the largest and smallest numbers
            Array.Sort(nums);
            int n = nums.Length;

            // The maximum product can either be:
            // 1. The product of the three largest numbers
            // 2. The product of the two smallest (negative) numbers and the largest number
            return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            // Edge case: if the decimal number is 0, return "0"
            if (decimalNumber == 0) return "0";

            // Initialize an empty string to store the binary result
            string binary = "";

            // Convert decimal to binary by repeatedly dividing by 2 
            // and storing the remainder (which is the binary digit)
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary; // Append remainder to binary result
                decimalNumber /= 2; // Divide by 2 for the next digit
            }
            return binary; // Return the binary string
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            // Use binary search approach
            int left = 0, right = nums.Length - 1;

            // Loop until left and right pointers converge
            while (left < right)
            {
                int mid = left + (right - left) / 2; // Find the midpoint

                // If mid element is greater than right element, the minimum must be on the right side
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else
                    // Otherwise, the minimum is on the left side
                    right = mid;
            }
            return nums[left]; // The left pointer will point to the minimum element
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            // If the number is negative, it can't be a palindrome
            if (x < 0) return false;

            int reversed = 0, original = x;

            // Reverse the number by repeatedly taking the last digit
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10; // Append last digit to reversed number
                x /= 10; // Remove the last digit from the original number
            }

            // If the reversed number equals the original, it's a palindrome
            return original == reversed;
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            // Base cases: F(0) = 0 and F(1) = 1
            if (n <= 1) return n;

            // Use recursion to calculate Fibonacci number for n > 1
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
