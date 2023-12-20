using System;
using BTL_LTCSDL.DTO;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance; //Crtl + R + E

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }

                return FoodDAO.instance;
            }
            private set { FoodDAO.instance = value; }
        }
        private FoodDAO() { }
        public static int FoodWight = 250;
        public static int FoodHeight = 100;
        public List<Food> LoadListTable()
        {
            List<Food> tableList = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetFoodList");
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                tableList.Add(food);
            }
            return tableList;
        }
        public List<Food> GetListMenuByFood(int id)
        {
            List<Food> listmenu = new List<Food>();
            string query = "Select* from SanPham where SanPhamID = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listmenu.Add(food);
            }
            return listmenu;
        }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> listmenu = new List<Food>();
            string query = "Select* from SanPham where ID_LoaiSanPham = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listmenu.Add(food);
            }
            return listmenu;
        }
        public bool InsertFood(int id, string name, float gia)
        {
            string query = string.Format("INSERT SanPham(SanPhamID,TenSanPham,DonGia)VALUES (N'{0}', {1}, {2})", id, name, gia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertFood(int id, string name, string dvTinh, float gia, int idLoaiSanPham, int ID_KhuyenMai)
        {
            string query = string.Format("SET IDENTITY_INSERT SanPham ON; INSERT SanPham(SanPhamID,TenSanPham,DonViTinh,DonGia,ID_LoaiSanPham,ID_KhuyenMai)VALUES ('{0}', N'{1}', N'{2}','{3}', '{4}','{5}')", id, name, dvTinh, gia, idLoaiSanPham, ID_KhuyenMai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateFood(int id,string name, string dvTinh, float gia, int idLoaiSanPham)
        {
            string query = string.Format("SET IDENTITY_INSERT SanPham ON; Update SanPham SET TenSanPham =N'{0}',DonViTinh=N'{1}',DonGia='{2}',ID_LoaiSanPham='{3}' where SanPhamID='{4}'", name, dvTinh, gia, idLoaiSanPham,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int id)
        {
            string query = string.Format("Delete SanPham where SanPhamID= '{0}'", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();
            string query = string.Format("Select * from SanPham where TenSanPham like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
    }
}
