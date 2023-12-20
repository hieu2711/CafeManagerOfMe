using BTL_LTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DAO
{
    class TableDAO
    {
        private static TableDAO instance; //Crtl + R + E
        
        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TableDAO();
                }

                return TableDAO.instance;
            }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }
        public static int TableWight = 175;
        public static int TableHeight = 100;
        public List<Table> LoadListTable()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;  
        }
        //public List<Table> GetNameTable(int id)
        //{
        //    List<Table> listmenu = new List<Table>();
        //    string query = "Select SoBan from ThongTinBan";
        //    DataTable data = DataProvider.Instance.ExecuteQuery(query);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        Table menu = new Table(item);
        //        listmenu.Add(menu);
        //    }
        //    return listmenu;
        //}

        public bool InsertTable(int BanID,int SoBan,String TrangThai)
        {
            string query = string.Format("SET IDENTITY_INSERT ThongTinBan ON; INSERT ThongTinBan(BanID,SoBan,TrangThai)VALUES ('{0}', '{1}', N'{2}')", BanID,SoBan,TrangThai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTable(int BanID, int SoBan, string TrangThai)
        {
            string query = string.Format("SET IDENTITY_INSERT ThongTinBan ON; Update ThongTinBan SET SoBan =N'{1}',TrangThai=N'{2}' where BanID='{0}'",BanID,SoBan,TrangThai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTable(int id)
        {
            string query = string.Format("Delete ThongTinBan where BanID= '{0}'", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<Table> SearchSoBanByName(int SoBan)
        {
            List<Table> list = new List<Table>();
            string query = string.Format("Select * from ThongTinBan where SoBan = '{0}'", SoBan);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table food = new Table(item);
                list.Add(food);
            }
            return list;
        }
    }
}
