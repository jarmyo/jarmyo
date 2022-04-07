using System.Linq;

namespace leetCodeSolutions.Hard
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/explore/challenge/card/july-leetcoding-challenge-2021/611/week-4-july-22nd-july-28th/3823/
        /// Given an array nums, partition it into two (contiguous) subarrays left and right so that:
        /// Every element in left is less than or equal to every element in right.
        /// left and right are non-empty.
        /// left has the smallest possible size.
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>Return the length of left after such a partitioning.  It is guaranteed that such a partitioning exists.</returns>
        public static int PartitionDisjoint(int[] nums)
        {
            List<int> left = new List<int>();
            List<int> right = nums.ToList();
            right.RemoveAt(0);
            left.Add(nums[0]);
            int pivot = nums[0];
            int temporalPivot = nums[0];
            var counter = 0;
            int y = 0;
            while (y < right.Count)
            {
                counter++;
                if (right[y] < pivot)
                {
                    left.AddRange(right.GetRange(0, counter));
                    right.RemoveRange(0, counter);
                    pivot = temporalPivot;
                    counter = 0;
                    y = 0;
                }
                else
                {
                    if (right[y] > temporalPivot)
                        temporalPivot = right[y];
                    y++;
                }
            }
            return left.Count;
        }
    }
}
