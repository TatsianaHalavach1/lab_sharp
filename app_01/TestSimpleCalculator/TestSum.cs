
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSimpleCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSum()
        {
            int a = 5;
            int b = 7;
            SimpleCalculator calculator = new SimpleCalculator();
            Assert.Equals(a + b, );
        }



    }
}
