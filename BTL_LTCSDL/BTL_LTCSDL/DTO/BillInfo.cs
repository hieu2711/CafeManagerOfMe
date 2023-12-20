using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    class BillInfo
    {
        private int chitiethoadonid;
        public int ChiTietHoaDonID
        {
            get { return chitiethoadonid; }
            set { chitiethoadonid = value; }
        }

        private int hoadonid;
        public int HoaDonID
        {
            get { return hoadonid; }
            set { hoadonid = value; }
        }

        private int idsanpham;
        public int IDSanPham
        {
            get { return idsanpham; }
            set { idsanpham = value; }
        }

        private int tongsanpham;
        public int TongSanPham
        {
            get { return tongsanpham; }
            set { tongsanpham = value; }
        }

        public BillInfo(int chitiethoadonid,int hoadonid,int idsanpham,int tongsanpham)
        {
            this.ChiTietHoaDonID = chitiethoadonid;
            this.HoaDonID = hoadonid;
            this.IDSanPham = idsanpham;
            this.TongSanPham = tongsanpham;
        }

        public BillInfo(DataRow row)
        {
            this.ChiTietHoaDonID = (int)row["ChiTietHoaDonID"];
            this.HoaDonID = (int)row["ID_HoaDon"];
            this.IDSanPham = (int)row["ID_SanPham"];
            this.TongSanPham = (int)row["TongSanPham"];

        }
    }
}
