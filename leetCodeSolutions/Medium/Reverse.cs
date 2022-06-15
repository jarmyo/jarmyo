namespace leetCodeSolutions
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/reverse-integer
        /// <br/>Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit
        /// integer range [-231, 231 - 1], then return 0.
        /// <b>Assume the environment does not allow you to store 64-bit integers (signed or unsigned).</b>
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            long divisor = 10;
            bool signed = false;
            List<long> digits = new();
            long y = x;
            if (x < 0)
            {
                signed = true;
                y *= -1;
            }
            long result = y;
            while (result != 0)
            {
                var firstDiv = y % divisor;
                var secontDiv = divisor / 10;
                digits.Add( firstDiv / secontDiv);
                result = result / 10;
                divisor *= 10;
            }
            divisor /= 100;
            for (int i = 0; i < digits.Count; i++)
            {
                result += digits[i] * divisor;
                divisor /= 10;
            }

            if (result > int.MaxValue)
                return 0;
            else
            {
                if (signed)
                    result *= -1;
                return (int)result;
            }
        }
    }
}
