
using BTL_LTCSDL.DAO;
using BTL_LTCSDL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLTCSDL
{
    public partial class FormAdmin : Form
    {
        BindingSource foodlist = new BindingSource();
        public FormAdmin()
        {
            InitializeComponent();
            LoadAccountList();
            LoadFoodList();
            LoadTableList();
            LoadNhanVienList();
            AddFoodBinding();
            AddTableBinding();
            AddNhanVienBinding();
            AddTaiKhoanBinding();
        }

        void LoadAccountList()
        {
            string query = "Select TenHienThi,Username,ChucVu,ID_NhanVien from TaiKhoan";
            dtgvTaiKhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadFoodList()
        {
            string query = "Select * from SanPham";
            dtgvThucAn.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadTableList()
        {
            string query = "Select * from ThongTinBan";
            dtgvPhongBan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadNhanVienList()
        {
            string query = "Select * from NhanVien";
            dtgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddFoodBinding()
        {
            txtTenMon.DataBindings.Add(new Binding("Text", dtgvThucAn.DataSource, "TenSanPham",true,DataSourceUpdateMode.Never));
            txtID_Mon.DataBindings.Add(new Binding("Text", dtgvThucAn.DataSource, "SanPhamID", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", dtgvThucAn.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
            txtCategory.DataBindings.Add(new Binding("Text", dtgvThucAn.DataSource, "ID_LoaiSanPham", true, DataSourceUpdateMode.Never));
            txtSale.DataBindings.Add(new Binding("Text", dtgvThucAn.DataSource, "ID_KhuyenMai", true, DataSourceUpdateMode.Never));
            txtDonVi.DataBindings.Add(new Binding("Text", dtgvThucAn.DataSource, "DonViTinh", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            txtIDBan.DataBindings.Add(new Binding("Text", dtgvPhongBan.DataSource, "BanID", true, DataSourceUpdateMode.Never));
            txtTenBan.DataBindings.Add(new Binding("Text", dtgvPhongBan.DataSource, "SoBan", true, DataSourceUpdateMode.Never));
            txtStatusBan.DataBindings.Add(new Binding("Text", dtgvPhongBan.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }

        void AddNhanVienBinding()
        {
            txtIDNv.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NhanVienID", true, DataSourceUpdateMode.Never));
            txtNameNv.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "HoVaTen", true, DataSourceUpdateMode.Never));
            txtSDTNv.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SoDienThoai", true, DataSourceUpdateMode.Never));
            txtNgaySinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txtGioiTinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            txtNgayVaoLam.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgayVaoLam", true, DataSourceUpdateMode.Never));
            txtChucVu.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
        }
        void AddTaiKhoanBinding()
        {
            txtNameAcc.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txtNameAccount.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "TenHienThi", true, DataSourceUpdateMode.Never));
            txtTypeAcc.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            txt_TkNv.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "ID_NhanVien", true, DataSourceUpdateMode.Never));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtTenMon.Text;
            float gia = float.Parse(txtPrice.Text);
            int id = int.Parse(txtID_Mon.Text);
            string dvTinh = txtDonVi.Text;
            int ID_LoaiSanPham = int.Parse(txtCategory.Text);
            int ID_KhuyenMai = int.Parse(txtSale.Text);

            if (FoodDAO.Instance.InsertFood(id, name, dvTinh, gia, ID_LoaiSanPham, ID_KhuyenMai))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadFoodList();
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!");
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            string name = txtTenMon.Text;
            float gia = float.Parse(txtPrice.Text);
            int id = int.Parse(txtID_Mon.Text);
            string dvTinh = txtDonVi.Text;
            int ID_LoaiSanPham = int.Parse(txtCategory.Text);
            int ID_KhuyenMai = int.Parse(txtSale.Text);
            

            if (FoodDAO.Instance.UpdateFood(id,name, dvTinh, gia, ID_LoaiSanPham))
            {
                MessageBox.Show("Sửa món thành công!");
                LoadFoodList();
            }
            else
            {
                MessageBox.Show("Sửa món thất bại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID_Mon.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadFoodList();
            }
            else
            {
                MessageBox.Show("Xóa món thất bại!");
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            int BanID = int.Parse(txtIDBan.Text);
            int SoBan = int.Parse(txtTenBan.Text);
            string TrangThai = txtStatusBan.Text;

            if (TableDAO.Instance.InsertTable(BanID,SoBan,TrangThai))
            {
                MessageBox.Show("Thêm bàn thành công!");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!");
            }
        }

        private void btnFix1_Click(object sender, EventArgs e)
        {
            int BanID = int.Parse(txtIDBan.Text);
            int SoBan = int.Parse(txtTenBan.Text);
            string TrangThai = txtStatusBan.Text;

            if (TableDAO.Instance.UpdateTable(BanID, SoBan, TrangThai))
            {
                MessageBox.Show("Sửa bàn thành công!");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Sửa bàn thất bại!");
            }
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            int BanID = int.Parse(txtIDBan.Text);
            if (TableDAO.Instance.DeleteTable(BanID))
            {
                MessageBox.Show("Xóa bàn thành công!");
                LoadTableList();
            }
            else
            {
                MessageBox.Show("Xóa bàn thất bại!");
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            string name = txtNameNv.Text;
            int id = int.Parse(txtIDNv.Text);
            string NgaySinh = txtNgaySinh.Text;
            string GioiTinh = txtGioiTinh.Text;
            int SDT = int.Parse(txtSDTNv.Text);
            int ChucVu = int.Parse(txtChucVu.Text);
            string NgayVaoLam = txtNgayVaoLam.Text;


            if (NhanVienDAO.Instance.InsertNhanVien(id,name,NgaySinh,GioiTinh,SDT,NgayVaoLam,ChucVu))
            {
                MessageBox.Show(" Thêm nhân viên thành công!");
                LoadNhanVienList();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }
        }

        private void btnFix2_Click(object sender, EventArgs e)
        {
            string name = txtNameNv.Text;
            int id = int.Parse(txtIDNv.Text);
            string NgaySinh = txtNgaySinh.Text;
            string GioiTinh = txtGioiTinh.Text;
            int SDT = int.Parse(txtSDTNv.Text);
            string NgayVaoLam = txtNgayVaoLam.Text;
            int ChucVu = int.Parse(txtChucVu.Text);
           

            if (NhanVienDAO.Instance.UpdateNhanVien(id, name, NgaySinh, GioiTinh, SDT, NgayVaoLam, ChucVu))
            {
                MessageBox.Show(" Sửa nhân viên thành công!");
                LoadNhanVienList();
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại!");
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDNv.Text);
            if (NhanVienDAO.Instance.DeleteNhanVien(id))
            {
                MessageBox.Show(" Xóa nhân viên thành công!");
                LoadNhanVienList();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại!");
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            string username = txtNameAcc.Text;
            string TenHienThi = txtNameAccount.Text;
            string password = "1";
            int ID_Nv = int.Parse(txt_TkNv.Text);

            if (AccountDAO.Instance.InsertAccount(TenHienThi,username,password,ID_Nv))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản món thất bại!");
            }
        }

        private void btnFix3_Click(object sender, EventArgs e)
        {
            string username = txtNameAcc.Text;
            string TenHienThi = txtNameAccount.Text;
            int ID_Nv = int.Parse(txt_TkNv.Text);

            if (AccountDAO.Instance.UpdateAccount(TenHienThi, username, ID_Nv))
            {
                MessageBox.Show("Sửa tài khoản thành công!");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Sửa tài khoản món thất bại!");
            }
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            string username = txtNameAcc.Text;
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Xóa tài khoản món thất bại!");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadFoodList();
        }

        private void btnView1_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }

        private void btnView2_Click(object sender, EventArgs e)
        {
            LoadNhanVienList();
        }

        private void btnView4_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listfood = FoodDAO.Instance.SearchFoodByName(name);
            return listfood;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           dtgvThucAn.DataSource = SearchFoodByName(txtTimKiem.Text);
        }

        List<Table> SearchTableByName(int SoBan)
        {
            List<Table> listTable= TableDAO.Instance.SearchSoBanByName(SoBan);
            return listTable;
        }

        private void btnTimKiem1_Click_1(object sender, EventArgs e)
        {
            dtgvPhongBan.DataSource = SearchTableByName(int.Parse(txtTimKiem1.Text));
        }

        List<NhanVien> SearchNhanVienByName(string name)
        {
            List<NhanVien> listfood = NhanVienDAO.Instance.SearchNhanVienByName(name);
            return listfood;
        }

        private void btnTimKiem2_Click(object sender, EventArgs e)
        {
            dtgvNhanVien.DataSource = SearchNhanVienByName(txtTimKiem2.Text);
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dateTPStart.Value = new DateTime(today.Year, today.Month, 1);
            dateTPEnd.Value = dateTPStart.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvDoanhThu.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTPStart.Value,dateTPEnd.Value);
        }
    }
}

