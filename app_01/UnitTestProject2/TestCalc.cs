using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lib_01;

namespace UnitTestProject2
{
    [TestClass]
    public class TestCalc
    {
        SimpleCalculator calculator;

        [TestMethod]
        public void TestSum()
        {
            calculator = new SimpleCalculator(10, 15);
            Assert.AreEqual(25, calculator.Sum());
        }

        [TestMethod]
        public void TestSub()
        {
            calculator = new SimpleCalculator(-3, 4);
            Assert.AreEqual(-7, calculator.Sub());
        }

        [TestMethod]
        public void TestMult()
        {
            calculator = new SimpleCalculator(0, -141);
            Assert.AreEqual(0, calculator.Mult());
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestDiv()
        {
            calculator = new SimpleCalculator(5, 0);
            calculator.Div();
        }
    }
}
