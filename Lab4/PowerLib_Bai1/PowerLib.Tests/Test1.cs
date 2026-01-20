using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerLib_Bai1;

namespace PowerLib.Tests
{
    [TestClass]
    public sealed class PowerTests
    {
        private const double EPS = 1e-10;

        [TestMethod]
        public void KiemTra_NBang0_TraVe1()
        {
            Assert.AreEqual(1.0, MathUtils.Power(2.0, 0), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(-3.5, 0), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(0.0, 0), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(1.0, 0), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(-1.0, 0), EPS);
        }

        [TestMethod]
        public void KiemTra_NDuong_XDuong()
        {
            Assert.AreEqual(2.0, MathUtils.Power(2.0, 1), EPS);
            Assert.AreEqual(4.0, MathUtils.Power(2.0, 2), EPS);
            Assert.AreEqual(8.0, MathUtils.Power(2.0, 3), EPS);
        }

        [TestMethod]
        public void KiemTra_NDuong_XAm()
        {
            Assert.AreEqual(-2.0, MathUtils.Power(-2.0, 1), EPS);
            Assert.AreEqual(-8.0, MathUtils.Power(-2.0, 3), EPS);
            Assert.AreEqual(4.0, MathUtils.Power(-2.0, 2), EPS);
            Assert.AreEqual(16.0, MathUtils.Power(-2.0, 4), EPS);
        }

        [TestMethod]
        public void KiemTra_NAm_XDuong()
        {
            Assert.AreEqual(0.5, MathUtils.Power(2.0, -1), EPS);
            Assert.AreEqual(0.25, MathUtils.Power(2.0, -2), EPS);
            Assert.AreEqual(0.125, MathUtils.Power(2.0, -3), EPS);
        }

        [TestMethod]
        public void KiemTra_NAm_XAm()
        {
            Assert.AreEqual(-0.5, MathUtils.Power(-2.0, -1), EPS);
            Assert.AreEqual(0.25, MathUtils.Power(-2.0, -2), EPS);
        }

        [TestMethod]
        public void KiemTra_XBang1()
        {
            Assert.AreEqual(1.0, MathUtils.Power(1.0, 5), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(1.0, -5), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(1.0, 0), EPS);
        }

        [TestMethod]
        public void KiemTra_XBangTru1()
        {
            Assert.AreEqual(-1.0, MathUtils.Power(-1.0, 3), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(-1.0, 4), EPS);
            Assert.AreEqual(-1.0, MathUtils.Power(-1.0, -1), EPS);
            Assert.AreEqual(1.0, MathUtils.Power(-1.0, -2), EPS);
        }

        [TestMethod]
        public void KiemTra_XBang0_NDuong()
        {
            Assert.AreEqual(0.0, MathUtils.Power(0.0, 1), EPS);
            Assert.AreEqual(0.0, MathUtils.Power(0.0, 5), EPS);
        }

        [TestMethod]
        public void KiemTra_TinhDungTheoDinhNghia_KhongNhanN()
        {
            // Test này để bắt bug kiểu return n * Power(x, n - 1)
            Assert.AreEqual(8.0, MathUtils.Power(2.0, 3), EPS);
        }
    }
}
