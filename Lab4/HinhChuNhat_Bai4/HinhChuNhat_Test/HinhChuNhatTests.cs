using Microsoft.VisualStudio.TestTools.UnitTesting;
using HinhChuNhat_Bai4;

namespace HinhChuNhat_Test
{
    [TestClass]
    public sealed class HinhChuNhatTests
    {
        // HCN chuẩn A: TL(0,10), BR(10,0)
        private HinhChuNhat TaoHinhChuanA()
        {
            var trenTrai = new Diem(0, 10);
            var duoiPhai = new Diem(10, 0);
            return new HinhChuNhat(trenTrai, duoiPhai);
        }

        // ======== TEST DIỆN TÍCH ========

        [TestMethod]
        public void KiemTra_DienTich_HinhChuNhatThongThuong()
        {
            var hcn = TaoHinhChuanA();
            Assert.AreEqual(100.0, hcn.TinhDienTich(), 1e-10);
        }

        [TestMethod]
        public void KiemTra_DienTich_HinhChuNhatRongBang0()
        {
            var hcn = new HinhChuNhat(
                new Diem(5, 10),
                new Diem(5, 0));   // xLeft = xRight

            Assert.AreEqual(0.0, hcn.TinhDienTich(), 1e-10);
        }

        [TestMethod]
        public void KiemTra_DienTich_HinhChuNhatCaoBang0()
        {
            var hcn = new HinhChuNhat(
                new Diem(0, 3),
                new Diem(10, 3));  // yTop = yBottom

            Assert.AreEqual(0.0, hcn.TinhDienTich(), 1e-10);
        }

        // ======== TEST GIAO NHAU ========

        [TestMethod]
        public void KiemTra_GiaoNhau_HinhTrongHinh()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(2, 8),
                new Diem(8, 2));

            Assert.IsTrue(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_KhongGiaoNhau_NgoaiBenTrai()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(-10, 10),
                new Diem(-1, 0));

            Assert.IsFalse(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_GiaoNhau_ChongLenMotPhanBenTrai()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(-5, 8),
                new Diem(5, 2));

            Assert.IsTrue(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_GiaoNhau_ChamCanhPhai()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(10, 8),
                new Diem(15, 2)); // left2 = right1

            Assert.IsTrue(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_GiaoNhau_ChamCanhTren()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(2, 10),   // top2 = top1
                new Diem(8, 15));

            Assert.IsTrue(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_GiaoNhau_ChamMotGoc()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(10, 0),   // góc chung (BR của h1, TL của h2)
                new Diem(15, -5));

            Assert.IsTrue(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_KhongGiaoNhau_TachXa()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(11, 11),
                new Diem(20, 5));

            Assert.IsFalse(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_GiaoNhau_HaiHinhTrungNhau()
        {
            var h1 = TaoHinhChuanA();
            var h2 = TaoHinhChuanA();

            Assert.IsTrue(h1.GiaoNhau(h2));
        }

        [TestMethod]
        public void KiemTra_GiaoNhau_TinhDoiXung()
        {
            var h1 = TaoHinhChuanA();
            var h2 = new HinhChuNhat(
                new Diem(-5, 8),
                new Diem(5, 2));

            Assert.AreEqual(h1.GiaoNhau(h2), h2.GiaoNhau(h1));
        }
    }
}
