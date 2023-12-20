using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    class LoaiSanPham
    {
        private string loaisanpham;
        public string loaiSanPham
        {
            get { return loaisanpham; }
            set { loaisanpham = value; }
        }

        private int loaisanphamid;
        public int LoaiSanPhamID
        {
            get { return loaisanphamid; }
            set { loaisanphamid = value; }
        }
        public LoaiSanPham(int loaisanphamid, string loaisanpham)
        {
            this.LoaiSanPhamID = loaisanphamid;
            this.loaiSanPham = loaisanpham;
        }

        public LoaiSanPham(DataRow row)
        {
            this.LoaiSanPhamID = (int)row["LoaiSanPhamID"];
            this.loaiSanPham = row["LoaiSanPham"].ToString();
        }
    }
}
