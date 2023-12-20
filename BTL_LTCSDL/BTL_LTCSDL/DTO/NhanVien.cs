using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    class NhanVien
    {
        private int nvid;
        public int NhanVienID
        {
            get { return nvid; }
            set { nvid = value; }
        }

        private string ngaysinh;
        public string NgaySinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        private string hovaten;
        public string HoVaTen
        {
            get { return hovaten; }
            set { hovaten = value; }
        }

        private string gt;
        public string GioiTinh
        {
            get { return gt; }
            set { gt = value; }
        }

        private string sdt;
        public string SoDienThoai
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private string ngayvaolam;
        public string NgayVaoLam
        {
            get { return ngayvaolam; }
            set { ngayvaolam = value; }
        }

        private int chucvu;
        public int ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        public NhanVien(int nhanvienid,string hovaten,string ngaysinh,string gt,string sdt,string ngayvaolam,int chucvu)
        {
            this.HoVaTen = hovaten;
            this.NhanVienID = nhanvienid;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gt;
            this.SoDienThoai = sdt;
            this.NgayVaoLam = ngayvaolam;
            this.ChucVu = chucvu;
        }

        public NhanVien(DataRow row)
        {
            this.HoVaTen = row["HoVaTen"].ToString();
            this.NhanVienID = (int)row["NhanVienID"];
            //this.NgaySinh = row["NgaySinh"].ToString();
            //this.GioiTinh = row["GioiTinh"].ToString();
            //this.SoDienThoai = row["SoDienThoai"].ToString();
            //this.NgayVaoLam = row["NgayVaoLam"].ToString();
            //this.ChucVu = (int)row["ChucVu"];
        }
    }
}
