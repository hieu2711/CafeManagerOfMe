using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
   public  class Menu
    {
        private string TenSanPham;
        public string tenSanPham
        {
            get { return TenSanPham; }
            set { TenSanPham = value; }
        }

        private int TongSanPham;
        public int tongSanPham
        {
            get { return TongSanPham; }
            set { TongSanPham = value; }
        }

        private float DonGia;
        public float donGia
        {
            get { return DonGia; }
            set { DonGia = value; }
        }

        private float totalprice;
        public float TotalPrice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }
        public Menu(string foodname, int count, float price, float totalprice)
        {
            this.tenSanPham = foodname;
            this.TongSanPham = count;
            this.donGia = price;
            this.TotalPrice = totalprice;

        }

        public Menu(DataRow row)
        {
            this.tenSanPham = row["TenSanPham"].ToString();
            this.tongSanPham = (int)row["TongSanPham"];
            this.donGia = (float)(double)row["DonGia"];
            this.TotalPrice = (float)(double)row["TotalPrice"];
        }

    }
}
