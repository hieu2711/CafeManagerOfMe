using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    public class Table
    {
        private int Banid;
        public int BanId
        {
            get { return Banid; }
            set { Banid = value; }
        }

        private int soBan;
        public int SoBan
        {
            get { return soBan; }
            set { soBan = value; }
        }

        private string trangThai;
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
       
        public Table(int Banid,int soBan,string trangThai)
        {
            this.SoBan = soBan;
            this.BanId = Banid;
            this.TrangThai = trangThai; 
        }

        //public Table(DataRow row)
        //{
        //    this.BanId = (int)row["Banid"];
        //    this.SoBan = (int)row["soBan"];
        //    this.TrangThai = row["trangThai"].ToString();
        //}
        public Table(DataRow row)
        {
            this.BanId = (int)row["BanID"];
            this.SoBan = (int)row["SoBan"];
            this.TrangThai = row["TrangThai"].ToString();
        }

        public Table()
        {
        }
    }
}
