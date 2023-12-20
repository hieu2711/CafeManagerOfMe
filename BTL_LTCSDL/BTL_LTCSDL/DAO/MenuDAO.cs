using BTL_LTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DAO
{
    class MenuDAO
    {
        private static MenuDAO instance; //Crtl + R + E

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuDAO();
                }

                return MenuDAO.instance;
            }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listmenu = new List<Menu>();
            string query = "Select s.TenSanPham,c.TongSanPham,s.DonGia,(c.TongSanPham * s.DonGia) as TotalPrice from ChiTietHoaDon as c,HoaDon as h,SanPham as s where c.ID_SanPham = s.SanPhamID and h.HoaDonID = c.ID_HoaDon and h.TrangThai = 0 and h.SoBanDaDung = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
