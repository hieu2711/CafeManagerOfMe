using System;
using BTL_LTCSDL.DTO;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BTL_LTCSDL.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance; //Crtl + R + E

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAO();
                }

                return NhanVienDAO.instance;
            }
            private set { NhanVienDAO.instance = value; }
        }
        private NhanVienDAO() { }
        public static int FoodWight = 250;
        public static int FoodHeight = 100;
        //public List<NhanVien> LoadListNV()
        //{
        //    List<NhanVien> tableList = new List<NhanVien>();
        //    DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetNhanVienList");
        //    foreach (DataRow item in data.Rows)
        //    {
        //        NhanVien nv = new NhanVien(item);
        //        tableList.Add(nv);
        //    }
        //    return tableList;
        //}
        public List<NhanVien> GetListNV()
        {
            List<NhanVien> listnv = new List<NhanVien>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select NhanVienID,HoVaTen from NhanVien");
            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                listnv.Add(nv);
            }
            return listnv;
        }

        public bool InsertNhanVien(int NvID,string HoTen,string NgaySinh,string GioiTinh,int SoDienThoai,string NgayVaoLam,int ChucVu)
        {
            string query = string.Format("SET IDENTITY_INSERT NhanVien ON; INSERT NhanVien(NhanVienID,HoVaTen,NgaySinh,GioiTinh,SoDienThoai,NgayVaoLam,ChucVu)VALUES ('{0}', N'{1}', '{2}',N'{3}', '{4}',N'{5}','{6}')", NvID,HoTen,NgaySinh,GioiTinh,SoDienThoai,NgayVaoLam,ChucVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNhanVien(int NvID, string HoTen, string NgaySinh, string GioiTinh, int SoDienThoai, string NgayVaoLam, int ChucVu)
        {
            string query = string.Format("SET IDENTITY_INSERT NhanVien ON; Update NhanVien SET HoVaTen=N'{1}', NgaySinh='{2}',GioiTinh=N'{3}',SoDienThoai='{4}',NgayVaoLam=N'{5}',ChucVu='{6}' where NhanVienID='{0}'",NvID, HoTen,NgaySinh,GioiTinh,SoDienThoai,NgayVaoLam,ChucVu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteNhanVien(int id)
        {
            string query = string.Format("Delete NhanVien where NhanVienID= '{0}'", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<NhanVien> SearchNhanVienByName(string name)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = string.Format("Select * from NhanVien where HoVaTen like '%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien food = new NhanVien(item);
                list.Add(food);
            }
            return list;
        }

    }
}
