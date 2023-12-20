using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    class Food
    {
        private int sanphamid;
        public int SanPhamID
        {
            get { return sanphamid; }
            set { sanphamid = value; }
        }

        private string tensanpham;
        public string TenSanPham
        {
            get { return tensanpham; }
            set { tensanpham = value; }
        }

        private string donvitinh;
        public string DonViTinh
        {
            get { return donvitinh; }
            set { donvitinh = value; }
        }

        private float dongia;
        public float DonGia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        private int idloaisanpham;
        public int IDLoaiSanPham
        {
            get { return idloaisanpham; }
            set { idloaisanpham = value; }
        }

        private int idkhuyenmai;
        public int IDKhuyenMai
        {
            get { return idkhuyenmai; }
            set { idkhuyenmai = value; }
        }

        public Food(int sanphamID,string tensanpham ,string donvitinh,float dongia,int idloaisanpham,int idkhuyenmai)
        {
            this.SanPhamID = sanphamid;
            this.TenSanPham = tensanpham;
            this.DonViTinh = donvitinh;
            this.DonGia = dongia;
            this.IDLoaiSanPham = idloaisanpham;
            this.IDKhuyenMai = idkhuyenmai; 
        }

        public Food(DataRow row)
        {
            this.SanPhamID = (int)row["SanPhamID"];
            this.TenSanPham = row["TenSanPham"].ToString();
            this.DonViTinh = row["DonViTinh"].ToString();
            this.DonGia = (float)(double)row["DonGia"];
            this.IDLoaiSanPham = (int)row["ID_LoaiSanPham"];
            this.IDKhuyenMai = (int)row["ID_KhuyenMai"];

        }
        //public Food(DataRow row)
        //{
        //    this.SanPhamID = (int)row["sanphamid"];
        //    this.TenSanPham = row["tensanpham"].ToString();
        //    this.DonViTinh = row["donvitinh"].ToString();
        //    this.DonGia = (float)(double)row["dongia"];
        //    this.IDLoaiSanPham = (int)row["ID_LoaiSanPham"];
        //    this.IDKhuyenMai = (int)row["ID_KhuyenMai"];

        //}
    }
}
