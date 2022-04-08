namespace leetCodeSolutions.Easy
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/roman-to-integer/
        /// <br/><b>13. Roman to Integer</b>
        /// <br/>Given a roman numeral, convert it to an integer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            int result = 0;
            Dictionary<char, int> romanValues = new()
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };

            Dictionary<char, char[]> romanPrevs = new()
            {
                ['I'] = new char[] { 'X', 'V' },
                ['V'] = System.Array.Empty<char>(),
                ['X'] = new char[] { 'L', 'C' },
                ['L'] = System.Array.Empty<char>(),
                ['C'] = new char[] { 'D', 'M' },
                ['D'] = System.Array.Empty<char>(),
                ['M'] = System.Array.Empty<char>()
            };
            int i;
            for (i = 0; i < s.Length; i++)
            {
                var n = romanValues[s[i]];
                foreach (var j in romanPrevs[s[i]])
                {
                    if (i < s.Length && j == s[i + 1])
                    {
                        n = romanValues[s[i]] * -1;
                        break;
                    }
                }
                result += n;
            }

            return result;
        }
    }
}
