namespace leetCodeSolutions.Easy
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/palindrome-number/
        /// <br/>Given an integer x, return true if x is palindrome integer.
        /// An integer is a palindrome when it reads the same backward as forward.
        /// For example, 121 is a <b>palindrome</b> while 123 is not.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            var s = x.ToString();
            for (int i = 0; i < (s.Length / 2); i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}