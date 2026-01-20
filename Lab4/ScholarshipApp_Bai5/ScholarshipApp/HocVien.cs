namespace ScholarshipApp
{
    public class HocVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string QueQuan { get; set; }

        public double DiemMon1 { get; set; }
        public double DiemMon2 { get; set; }
        public double DiemMon3 { get; set; }

        public HocVien(string maSo, string hoTen, string queQuan,
                       double d1, double d2, double d3)
        {
            MaSo = maSo;
            HoTen = hoTen;
            QueQuan = queQuan;
            DiemMon1 = d1;
            DiemMon2 = d2;
            DiemMon3 = d3;
        }
    }
}
