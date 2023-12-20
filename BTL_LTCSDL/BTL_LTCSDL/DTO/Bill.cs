using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    public class Bill
    {
        private int hoadonid;
        public int HoaDonID
        {
            get { return hoadonid; }
            set { hoadonid = value; }
        }

        private DateTime? ngaycheckin;
        public DateTime? NgayCheckIn
        {
            get { return ngaycheckin; }
            set { ngaycheckin = value; }
        }

        private DateTime? ngaycheckout;
        public DateTime? NgayCheckOut
        {
            get { return ngaycheckout; }
            set { ngaycheckout = value; }
        }

        private int sobandadung;
        public int SoBanDaDung
        {
            get { return sobandadung; }
            set { sobandadung = value; }
        }

        private int idkhachhang;
        public int IDKhachHang
        {
            get { return idkhachhang; }
            set { idkhachhang = value; }
        }

        private int idnhanvien;
        public int IDNhanVien
        {
            get { return idnhanvien; }
            set { idnhanvien = value; }
        }

        private int trangthai;
        public int TrangThai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private double totalPrice;
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Bill(int hoadonid, DateTime? ngaycheckin, DateTime? ngaycheckout,int sobandadung,int idkhachhang,int idnhanvien,int trangthai,int discount,float totalPrice)
        {
            this.HoaDonID = hoadonid;
            this.NgayCheckIn = ngaycheckin;
            this.NgayCheckOut = ngaycheckout;
            this.SoBanDaDung = sobandadung;
            this.IDKhachHang = idkhachhang;
            this.IDNhanVien = idnhanvien;
            this.TrangThai = trangthai;
            this.Discount = discount;
            this.TotalPrice = totalPrice;
        }

        public Bill(DataRow row)
        {
            this.HoaDonID = (int)row["hoadonid"];
            this.NgayCheckIn = (DateTime?)row["DateCheckIn"];
            var dataCheckOutTemp = row["DateCheckOut"];
            if (dataCheckOutTemp.ToString() != "")
            {
                this.NgayCheckOut = (DateTime?)dataCheckOutTemp;
            }
            this.SoBanDaDung = (int)row["sobandadung"];
            //this.IDKhachHang = (int)row["idkhachhang"];
            //this.IDNhanVien = (int)row["idnhanvien"];
            this.TrangThai = (int)row["trangthai"];
            //this.Discount = (int)row["discount"];
            //this.TotalPrice = (double)row["totalPrice"];

        }
    }
}
