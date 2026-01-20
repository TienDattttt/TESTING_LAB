using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RadixApp;

namespace RadixApp.Tests
{
    [TestClass]
    public class RadixTests
    {
        // B1: normal case
        [TestMethod]
        public void B1_Convert_10_To_Binary()
        {
            Radix radix = new Radix(10);
            string result = radix.ConvertDecimalToAnother(2);
            Assert.AreEqual("1010", result);
        }

        // B2: normal case
        [TestMethod]
        public void B2_Convert_15_To_Hex()
        {
            Radix radix = new Radix(15);
            string result = radix.ConvertDecimalToAnother(16);
            Assert.AreEqual("F", result);
        }

        // B3: boundary number = 1
        [TestMethod]
        public void B3_Convert_1_To_Binary()
        {
            Radix radix = new Radix(1);
            string result = radix.ConvertDecimalToAnother(2);
            Assert.AreEqual("1", result);
        }

        // B4: boundary number = 0
        [TestMethod]
        public void B4_Convert_0_Returns_Zero()
        {
            Radix radix = new Radix(0);
            string result = radix.ConvertDecimalToAnother(2);
            Assert.AreEqual("0", result);
        }

        // B5: number < 0 → Exception
        [TestMethod]
        public void B5_Negative_Number_Throws_Exception()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Radix radix = new Radix(-1);
            });
        }

        // B6: radix < 2 → Exception
        [TestMethod]
        public void B6_Invalid_Radix_Less_Than_2()
        {
            Radix radix = new Radix(10);

            Assert.Throws<ArgumentException>(() =>
            {
                radix.ConvertDecimalToAnother(1);
            });
        }

        // B7: radix > 16 → Exception
        [TestMethod]
        public void B7_Invalid_Radix_Greater_Than_16()
        {
            Radix radix = new Radix(10);

            Assert.Throws<ArgumentException>(() =>
            {
                radix.ConvertDecimalToAnother(17);
            });
        }
    }
}
