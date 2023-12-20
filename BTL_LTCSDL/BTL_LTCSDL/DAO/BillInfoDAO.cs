using BTL_LTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BTL_LTCSDL.DAO
{
    class BillInfoDAO
    {
        private static BillInfoDAO instance; //Crtl + R + E

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillInfoDAO();
                }

                return BillInfoDAO.instance;
            }
            private set { BillInfoDAO.instance = value; }
        }
        private BillInfoDAO() { }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from ChiTietHoaDon where ID_HoaDon = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public void DeleteBillInfoByFoodID(int id)
        {
            DataProvider.Instance.ExecuteQuery("Delete ChiTietHoaDon where ChiTietHoaDonID =" + id);
        }
        public void InsertBillInfo(int idbill, int idfood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idbill , @idfood , @count ", new object[] { idbill, idfood, count });
        }
        //public void InsertBillInfo(int idbill, int idfood, int count,int discount,float totalPrice)
        //{
        //    DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idbill , @idfood , @count ", new object[] { idbill, idfood, count });
        //}
    }
}
