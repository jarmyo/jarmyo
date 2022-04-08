namespace leetCodeSolutions
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
        /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
        /// </summary>
        /// <param name="nums">nums is sorted in non-decreasing order.</param>
        /// <returns>Return k after placing the final result in the first k slots of nums.</returns>
        public static int RemoveDuplicates(int[] nums)
        {
            //This code results:
            //Runtime: 213 ms
            //Memory Usage: 44.5 MB
            if (nums==null) return 0; //optimization
            int k = nums.Length; //initializate the result
            for (int x = nums.Length - 1; x > 0; x--) //go through the array in reverse order.
            {
                for (int y = x-1; y >= 0; y--)//go through the rest of numbers in reverse order.
                {
                    if (nums[x] == nums[y] ) //if found duplicate
                    {                      
                        k--; //reduce the result counter                        
                        for (int z =y; z<k; z++) //move array element from current position to k
                        {
                            nums[z] = nums[z+1];
                        }
                        break; //continue with next element.
                    }
                }
            }

            for (int j = 0; j < k; j++)
                System.Diagnostics.Debug.Write(nums[j]); //this is for debug purposes.

            return k;
        }

        public static int[] RemoveDuplicates_TestCases()
        {
            //return  new int[] { 0,0,1,1,1,2,2,3,3,4};
            return  new int[] { 1,1,1};
        }
    }
}