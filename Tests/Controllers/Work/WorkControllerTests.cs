using Personal.Controllers.Work;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Controllers.Work.Tests
{
    [TestClass()]
    public class WorkControllerTests
    {
        [TestMethod()]
        public void IsNotNumericTest()
        {
            //correct values
            Assert.IsFalse(WorkController.IsNotNumeric("0"));
            Assert.IsFalse(WorkController.IsNotNumeric("12345678901"));
            Assert.IsFalse(WorkController.IsNotNumeric("-12345678901"));
            //wrong values
            Assert.IsTrue(WorkController.IsNotNumeric("1239223372036854775809"));
            Assert.IsTrue(WorkController.IsNotNumeric("-1239223372036854775809"));
            Assert.IsTrue(WorkController.IsNotNumeric(""));
            Assert.IsTrue(WorkController.IsNotNumeric("abc"));
            Assert.IsTrue(WorkController.IsNotNumeric("1.1.1"));
            Assert.IsTrue(WorkController.IsNotNumeric("1.1"));
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
    }
}