using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BTL_LTCSDL.DTO;

namespace BTL_LTCSDL.DAO
{
    class BillDAO
    {
        private static BillDAO instance; //Crtl + R + E

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDAO();
                }

                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        public int GetUnCheckBillByTableID(int id)
        {
            DataTable data =DataProvider.Instance.ExecuteQuery("Select * from HoaDon where SoBanDaDung = " + id + " AND TrangThai = 0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.HoaDonID;
            }
            return -1;
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBill @idTable", new object[] { id });
        }


        public int GetMaxIDBill()
        {
            try {
                return (int)DataProvider.Instance.ExecuteScalar("Select Max(HoaDonID) From HoaDon");
            }
            catch {
                return 1;
            }
        }

        public void CheckOut(int id, int discount, double totalPrice)
        {
            string query = "UPDATE HoaDon SET dateCheckOut = GETDATE(), TrangThai = 1 ,discount = " + discount + ", totalPrice = " + totalPrice + "Where HoaDonID = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_ThongKe @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
    }
}
