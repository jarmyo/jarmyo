namespace leetCodeSolutions
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/two-sum
        /// <br/>Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int x = 0; x < nums.Length; x++)
                for (int y = x + 1; y < nums.Length; y++)
                    if ((nums[x] + nums[y]) == target)
                        return new int[] { x, y };
            return new int[] { 0, 0 }; //default response
        }
    }
}