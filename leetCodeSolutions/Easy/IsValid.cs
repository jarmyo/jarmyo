namespace leetCodeSolutions
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/valid-parentheses
        /// <br/>Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        /// <br/>An input string is valid if:
        /// <br/>- Open brackets must be closed by the same type of brackets.
        /// <br/>- Open brackets must be closed in the correct order.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            if (s.Length % 2 != 0) return false;
            Stack<char> stack = new();
            int inx = 0;
            Dictionary<char, char> open = new()
            {
                ['('] = ')',
                ['['] = ']',
                ['{'] = '}',
            };
            Dictionary<char, char> close = new()
            {
                [')'] = '(',
                [']'] = '[',
                ['}'] = '{',
            };
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (open.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        if (stack.Pop() != close[c])
                            return false;
                    }
                    else
                    {
                        if (i > 0)
                            return false;
                    }
                }
            }
            return inx == 0;
        }
    }
}