using System;

namespace HinhChuNhat_Bai4
{
    public class HinhChuNhat
    {
        public double Left { get; }
        public double Right { get; }
        public double Bottom { get; }
        public double Top { get; }

        public HinhChuNhat(Diem trenBenTrai, Diem duoiBenPhai)
        {
            if (trenBenTrai == null || duoiBenPhai == null)
                throw new ArgumentNullException("Điểm không được null");

            Left = Math.Min(trenBenTrai.X, duoiBenPhai.X);
            Right = Math.Max(trenBenTrai.X, duoiBenPhai.X);
            Bottom = Math.Min(trenBenTrai.Y, duoiBenPhai.Y);
            Top = Math.Max(trenBenTrai.Y, duoiBenPhai.Y);
        }

        public double TinhDienTich()
        {
            double rong = Right - Left;
            double cao = Top - Bottom;

            if (rong < 0 || cao < 0)
                return 0; 

            return rong * cao;
        }

        public bool GiaoNhau(HinhChuNhat h)
        {
            if (h == null) return false;

            bool giaoX = this.Left <= h.Right && this.Right >= h.Left;
            bool giaoY = this.Bottom <= h.Top && this.Top >= h.Bottom;

            return giaoX && giaoY;
        }
    }
}
