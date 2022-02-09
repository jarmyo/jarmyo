using System;

namespace leetCodeSolutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = Solution.MergeTwoLists_TestCase();
            var result =Solution.MergeTwoLists(test.Item1,test.Item2);
        }
    }
}
