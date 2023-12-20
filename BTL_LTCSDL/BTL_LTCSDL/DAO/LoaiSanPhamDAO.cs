using BTL_LTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DAO
{
    class LoaiSanPhamDAO
    {
        private static LoaiSanPhamDAO instance; //Crtl + R + E

        public static LoaiSanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSanPhamDAO();
                }

                return LoaiSanPhamDAO.instance;
            }
            private set { LoaiSanPhamDAO.instance = value; }
        }
        private LoaiSanPhamDAO() { }
        public static int FoodWight = 175;
        public static int FoodHeight = 100;
        public List<LoaiSanPham> LoadListCategory()
        {
            List<LoaiSanPham> categoryList = new List<LoaiSanPham>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetCatogoryList");
            foreach (DataRow item in data.Rows)
            {
                LoaiSanPham category = new LoaiSanPham(item);
                categoryList.Add(category);
            }
            return categoryList;
        }


    }
}
