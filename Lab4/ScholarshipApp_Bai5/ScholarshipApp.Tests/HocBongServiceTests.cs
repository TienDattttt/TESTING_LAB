using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScholarshipApp;

namespace ScholarshipApp.Tests
{
    [TestClass]
    public class HocBongServiceTests
    {
        [TestMethod]
        public void B1_Du_Dieu_Kien_Hoc_Bong()
        {
            var hv = new HocVien("HV01", "A", "HN", 8, 8, 9);
            var service = new HocBongService();

            bool result = service.XetHocBong(hv);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void B2_Trung_Binh_Duoi_8_Khong_Dat()
        {
            var hv = new HocVien("HV02", "B", "HN", 7, 7, 7);
            var service = new HocBongService();

            Assert.IsFalse(service.XetHocBong(hv));
        }

        [TestMethod]
        public void B3_Co_Mon_Duoi_5_Khong_Dat()
        {
            var hv = new HocVien("HV03", "C", "HN", 9, 4, 9);
            var service = new HocBongService();

            Assert.IsFalse(service.XetHocBong(hv));
        }

        [TestMethod]
        public void B4_Diem_Am_Throws_Exception()
        {
            var hv = new HocVien("HV04", "D", "HN", -1, 8, 9);
            var service = new HocBongService();

            Assert.Throws<ArgumentException>(() =>
                service.XetHocBong(hv)
            );
        }

        [TestMethod]
        public void B5_Diem_Lon_Hon_10_Throws_Exception()
        {
            var hv = new HocVien("HV05", "E", "HN", 11, 8, 9);
            var service = new HocBongService();

            Assert.Throws<ArgumentException>(() =>
                service.XetHocBong(hv)
            );
        }

        [TestMethod]
        public void B6_HocVien_Null_Throws_Exception()
        {
            var service = new HocBongService();

            Assert.Throws<ArgumentException>(() =>
                service.XetHocBong(null)
            );
        }
    }
}
