using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynomial_Bai2; 

namespace Polynomial_Test
{
    [TestClass]
    public sealed class PolynomialTests
    {
        private const double EPS = 1e-10;


        [TestMethod]
        public void KiemTra_DaThucBac0_TinhDung()
        {
            // P(x) = a0 = 5
            int n = 0;
            var heSo = new List<int> { 5 };

            var p = new Polynomial(n, heSo);

            Assert.AreEqual(5, p.Cal(10));
            Assert.AreEqual(5, p.Cal(0));
            Assert.AreEqual(5, p.Cal(-3));
        }

        [TestMethod]
        public void KiemTra_DaThucBac2_TinhDung_VoiXDuong()
        {
            // P(x) = 1 + 2x + 3x^2
            int n = 2;
            var heSo = new List<int> { 1, 2, 3 };

            var p = new Polynomial(n, heSo);

            // P(0) = 1
            Assert.AreEqual(1, p.Cal(0));
            // P(1) = 1 + 2 + 3 = 6
            Assert.AreEqual(6, p.Cal(1));
            // P(2) = 1 + 4 + 12 = 17
            Assert.AreEqual(17, p.Cal(2));
        }

        [TestMethod]
        public void KiemTra_DaThucBac2_TinhDung_VoiXAm()
        {
            // P(x) = -1 + 0x + 2x^2 = -1 + 2x^2
            int n = 2;
            var heSo = new List<int> { -1, 0, 2 };

            var p = new Polynomial(n, heSo);

            // P(-1) = -1 + 2*1 = 1
            Assert.AreEqual(1, p.Cal(-1));
            // P(-2) = -1 + 2*4 = 7
            Assert.AreEqual(7, p.Cal(-2));
        }

        [TestMethod]
        public void KiemTra_HeSo0_KhongAnhHuongTinhToan()
        {
            // P(x) = 0 + 0x + 5x^2 = 5x^2
            int n = 2;
            var heSo = new List<int> { 0, 0, 5 };

            var p = new Polynomial(n, heSo);

            Assert.AreEqual(0, p.Cal(0));        // 0
            Assert.AreEqual(20, p.Cal(2));       // 5 * 2^2 = 20
        }

        [TestMethod]
        public void KiemTra_DaThucBac3_TinhDung()
        {
            // P(x) = 2 - x + 0x^2 + x^3  = 2 - x + x^3
            int n = 3;
            var heSo = new List<int> { 2, -1, 0, 1 };

            var p = new Polynomial(n, heSo);

            Assert.AreEqual(2, p.Cal(0));   // 2
            Assert.AreEqual(2, p.Cal(1));   // 2 - 1 + 1 = 2
            Assert.AreEqual(8, p.Cal(2));   // 2 - 2 + 8 = 8
            Assert.AreEqual(2, p.Cal(-1));  // 2 - (-1) + (-1) = 2
        }

        // Thiếu hệ số (Count < n+1)
        [TestMethod]
        public void KiemTra_ThieuHeSo_ThrowArgumentException()
        {
            int n = 2;
            var heSo = new List<int> { 1, 2 }; // cần 3, mới có 2

            var ex = Assert.ThrowsException<ArgumentException>(
                () => new Polynomial(n, heSo));

            Assert.AreEqual("Invalid Data", ex.Message);
        }

        // Thừa hệ số (Count > n+1)
        [TestMethod]
        public void KiemTra_ThuaHeSo_ThrowArgumentException()
        {
            int n = 2;
            var heSo = new List<int> { 1, 2, 3, 4 }; // cần 3, đưa 4

            var ex = Assert.ThrowsException<ArgumentException>(
                () => new Polynomial(n, heSo));

            Assert.AreEqual("Invalid Data", ex.Message);
        }

        // n âm (đặc tả yêu cầu phải ném ngoại lệ)
        [TestMethod]
        public void KiemTra_NAm_ThrowArgumentException()
        {
            int n = -1;
            var heSo = new List<int> { 1 }; // số hệ số không quan trọng, n < 0 là sai

            var ex = Assert.ThrowsException<ArgumentException>(
                () => new Polynomial(n, heSo));

            Assert.AreEqual("Invalid Data", ex.Message);
        }
    }
}
