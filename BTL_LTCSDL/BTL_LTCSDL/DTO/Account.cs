using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DTO
{
    public class Account
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        public string PassWord
        {
            get { return password; }
            set { password = value; }
        }

        private int id_NV;
        public int ID_NV
        {
            get { return id_NV; }
            set { id_NV = value; }
        }

        private string tenhienthi;
        public string TenHienThi
        {
            get { return tenhienthi; }
            set { tenhienthi = value; }
        }

        private int chucvu;
        public int ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        public Account(string username, string tenhienthi, int id_nv, int chucvu, string password = null)
        {
            this.Username = username;
            this.PassWord = password;
            this.TenHienThi = tenhienthi;
            this.ID_NV = id_NV;
            this.ChucVu = chucvu;
        }

        public Account(DataRow row)
        {
            this.Username = row["Username"].ToString();
            this.PassWord = row["PassWord"].ToString();
            this.TenHienThi = row["TenHienThi"].ToString();
            this.id_NV = (int)row["ID_Nhanvien"];
            this.ChucVu = (int)row["ChucVu"];
        }
    }
}
