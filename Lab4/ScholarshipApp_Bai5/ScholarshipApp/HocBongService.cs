using System;

namespace ScholarshipApp
{
    public class HocBongService
    {
        public bool XetHocBong(HocVien hv)
        {
            if (hv == null)
                throw new ArgumentException("Hoc vien null");

            if (hv.DiemMon1 < 0 || hv.DiemMon1 > 10 ||
                hv.DiemMon2 < 0 || hv.DiemMon2 > 10 ||
                hv.DiemMon3 < 0 || hv.DiemMon3 > 10)
                throw new ArgumentException("Diem khong hop le");

            double dtb = (hv.DiemMon1 + hv.DiemMon2 + hv.DiemMon3) / 3;

            if (dtb >= 8 &&
                hv.DiemMon1 >= 5 &&
                hv.DiemMon2 >= 5 &&
                hv.DiemMon3 >= 5)
                return true;

            return false;
        }
    }
}
