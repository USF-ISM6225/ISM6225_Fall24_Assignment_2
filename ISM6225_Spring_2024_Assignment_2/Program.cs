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
        public static IList<int> GetMissingNumbers(int[] nums)
        {
            int length = nums.Length;  
            List<int> missing = new List<int>();  
            for (int i = 0; i < length; i++)
            {
                int idx = Math.Abs(nums[i]) - 1;  
                if (nums[idx] > 0)
                {
                    nums[idx] = -nums[idx];
                }
            }
            for (int i = 0; i < length; i++)
            {
                if (nums[i] > 0)
                {
                    missing.Add(i + 1);  
                }
            }
            return missing;
        }


        // Question 2: Sort Array by Parity
        public static int[] RearrangeByParity(int[] nums)
        {
            int start = 0;  
            int end = nums.Length - 1;  
            while (start < end)
            {
                while (start < end && nums[start] % 2 == 0) start++;
                while (start < end && nums[end] % 2 != 0) end--;
                if (start < end)
                {
                    int temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                }
            }
            return nums;
        }

        // Question 3: Two Sum
        public static int[] FindTwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];  
                if (map.ContainsKey(diff))
                {
                    return new int[] { map[diff], i };
                }
                map[nums[i]] = i;
            }
            return new int[0];
        }


        // Question 4: Find Maximum Product of Three Numbers
        public static int GetMaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int option1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
            int option2 = nums[0] * nums[1] * nums[n - 1];  
            return Math.Max(option1, option2);
        }

        // Question 5: Decimal to Binary Conversion
        public static string ConvertToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";
            string binaryRepresentation = "";  
            while (decimalNumber > 0)
            {
                binaryRepresentation = (decimalNumber % 2) + binaryRepresentation;
                decimalNumber /= 2;
            }
            return binaryRepresentation;
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMinimum(int[] nums)
        {
            int start = 0, end = nums.Length - 1;  
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] > nums[end]) start = mid + 1;
                else end = mid;
            }
            return nums[start];  
        }

        // Question 7: Palindrome Number
        public static bool CheckIfPalindrome(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;
            int reversedNumber = 0;  
            while (x > reversedNumber)
            {
                reversedNumber = reversedNumber * 10 + x % 10;
                x /= 10;
            }
            return x == reversedNumber || x == reversedNumber / 10;
        }

        // Question 8: Fibonacci Number
        public static int CalculateFibonacciNumber(int n)
        {
            if (n <= 1) return n;
            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;  
                a = b;
                b = temp;
            }
            return b;
        }
    }

