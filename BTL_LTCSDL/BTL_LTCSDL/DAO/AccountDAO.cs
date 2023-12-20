using BTL_LTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance; //Crtl + R + E

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }

                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; }
        }
        public AccountDAO() { }
        public bool Login(string username,string password)
        {
            string query = "Select * From TaiKhoan Where username = N'"+ username +"' AND password=N'"+ password +"' ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public bool LoginAdmin(string username, string password)
        {
            return false;
        }

        public bool InsertAccount(string TenHienThi,string Username,string Password,int ID_NV)
        {
            string query = string.Format("INSERT TaiKhoan(TenHienThi,Username,Password,ID_NhanVien)VALUES ('{0}', '{1}', N'{2}','{3}')", TenHienThi,Username,Password,ID_NV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateAccount(string TenHienThi, string Username,int ID_NV)
        {
            string query = string.Format("Update TaiKhoan SET TenHienThi =N'{1}',ID_NhanVien='{2}' where Username='{0}'",Username,TenHienThi,ID_NV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("Delete TaiKhoan where Username= '{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public Account GetAccountByUserName(string username)
        {
           DataTable data = DataProvider.Instance.ExecuteQuery("Select * from TaiKhoan where Username = '" + username + "'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
    }
}
