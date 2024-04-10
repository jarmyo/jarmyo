using Personal.Controllers.Work;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Personal.Controllers.Work.Tests
{
    [TestClass()]
    public class WorkControllerTests
    {
        private static readonly Dictionary<short, string> ResultStack = new()
        {
            [1] = "1.00000",
            [2] = "1.41421",
            [3] = "1.73205",
            [4] = "2.00000",
            [5] = "2.23607",
            [6] = "2.44949",
            [7] = "2.64575",
            [8] = "2.82843",
            [9] = "3.00000",
            [10] = "3.16228",
            [11] = "3.31662",
            [12] = "3.46410",
            [13] = "3.60555",
            [14] = "3.74166",
            [15] = "3.87298",
            [16] = "4.00000",
            [17] = "4.12311",
            [18] = "4.24264",
            [19] = "4.35890"
        };
        private static readonly List<string> ValidShort =
        [
            "0",
            "12345678901",
            "-12345678901"
        ];
        private static readonly List<string> NotValidShort =
        [
             "1239223372036854775809",
            "-1239223372036854775809",
            "",
            "abc",
            "1.1.1",
            "1.1"
        ];
        [TestMethod()]
        public void IsNotNumericTest()
        {
            foreach (var valid in ValidShort)
                Assert.IsFalse(WorkController.IsNotNumeric(valid));
            foreach (var notValid in NotValidShort)
                Assert.IsTrue(WorkController.IsNotNumeric(notValid));
        }
        [TestMethod()]
        public void IsNot16BitsTest()
        {
            //correct values
            Assert.AreEqual(WorkController.IsNot16Bits(short.MaxValue.ToString()), false);
            Assert.AreEqual(WorkController.IsNot16Bits(short.MinValue.ToString()), false);
            //wrong values
            Assert.AreEqual(WorkController.IsNot16Bits(short.MaxValue + 1.ToString()), true);
            Assert.AreEqual(WorkController.IsNot16Bits((short.MinValue - 1).ToString()), true);
        }
        [TestMethod()]
        public void BadResultTest()
        {
            var result = WorkController.BadResult("Bad response test");
            Assert.IsFalse(result.OK);
        }
        [TestMethod()]
        public void SquareResultTest()
        {
            foreach (var val in ResultStack)
            {
                var number = val.Key.ToString();
                var square = val.Value.ToString();
                var request = WorkController.SquareResult(number);
                var result = $"The Square root of {number} is {square}";
                Assert.AreEqual(request.Name, result);
            }
        }
    }
}