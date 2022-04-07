namespace leetCodeSolutions
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-common-prefix/
        /// <br/>Write a function to find the longest common prefix string amongst an array of strings.
        /// If there is no common prefix, return an empty string "".        
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            // var temp = string.Empty;
            var result = string.Empty;
            if (strs.Length > 1)
            {
                result = string.Empty;
                for (int i = 0; i < strs[0].Length; i++)
                {
                    var c = strs[0][i];
                    for (int j = 1; j < strs.Length; j++)
                    {
                        if (i < strs[j].Length)
                        {
                            var letrahijo = strs[j][i];
                            if (c != letrahijo)
                                return result;
                        }
                        else
                            return result;
                    }
                    result += c;
                }
            }
            else if (strs.Length == 1)
                result = strs[0];
            return result;
        }
    }
}