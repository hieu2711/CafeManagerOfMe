
using BTL_LTCSDL.DAO;
using BTL_LTCSDL.DTO;
using BTLLTCSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace BTL_LTCSDL
{
    public partial class FormQL : Form
    {
        public FormQL()
        {
            InitializeComponent();
            LoadTable();
            LoadFood();
            LoadCategory();
            LoadNV();
        }
        private void MenuItemQuanLy_Click(object sender, EventArgs e)
        {
            FormAdmin f = new FormAdmin();
            f.ShowDialog();
        }


        void LoadTable()
        {
            flpnViewBan.Controls.Clear();
            int temp = 0;
            int temp2 = 0;
            List<Table> tableList = TableDAO.Instance.LoadListTable();
            foreach(Table item in tableList)
            {
               
                Button btn = new Button()
                {
                    Width = TableDAO.TableWight,
                    Height = TableDAO.TableHeight,
                    Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                };
                if (item.TrangThai == "Full")
                {
                    btn.BackColor = Color.DarkOrange;
                    temp = temp + 1;
                }
                else
                {
                    btn.BackColor = Color.White;
                    temp2 = temp2 + 1;
                }
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.Text ="Bàn " + item.SoBan + Environment.NewLine + item.TrangThai ;
                flpnViewBan.Controls.Add(btn);
            }
            radioButtonUsed.Text = "Đã sử dụng (" + temp + ")";
            radioButtonEmpty.Text = "Còn trống (" + temp2 + ")";
            radioButtonAll.Text = "Tất cả (" + (temp + temp2) + ")";
        }
        void LoadFood()
        {
            List<Food> foodList = FoodDAO.Instance.LoadListTable();
            foreach (Food item in foodList)
            {
                Button btn1 = new Button()
                {
                    Width = TableDAO.TableWight,
                    Height = TableDAO.TableHeight,
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                };
                Button btn2 = new Button()
                {
                    Text = "Thêm...",
                };
                if (item.IDLoaiSanPham == 1)
                {
                    btn1.Text = item.TenSanPham + Environment.NewLine + item.DonGia + "đ" + Environment.NewLine + btn1.Text;
                    flowLayoutPanelCafe.Controls.Add(btn1);
                }
                if (item.IDLoaiSanPham == 2)
                {
                    btn1.Text = item.TenSanPham + Environment.NewLine + item.DonGia + "đ" + Environment.NewLine + btn1.Text;
                    flowLayoutPanelNuocEp.Controls.Add(btn1);
                }
                if (item.IDLoaiSanPham == 3)
                {
                    btn1.Text = item.TenSanPham + Environment.NewLine + item.DonGia + "đ" + Environment.NewLine + btn1.Text;
                    flowLayoutPanelSinhTo.Controls.Add(btn1);
                }
                if (item.IDLoaiSanPham == 4)
                {
                    btn1.Text = item.TenSanPham + Environment.NewLine + item.DonGia + "đ" + Environment.NewLine + btn1.Text;
                    flowLayoutPanelNuocNgot.Controls.Add(btn1);
                }
                if (item.IDLoaiSanPham == 5)
                {
                    btn1.Text = item.TenSanPham + Environment.NewLine + item.DonGia + "đ" + Environment.NewLine + btn1.Text;
                    flowLayoutPanelBanhNgot.Controls.Add(btn1);
                }

            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).BanId;
            ShowBill(tableId);
            txtSoBan.Text = "Bàn " + tableId.ToString();
            listViewHoaDon.Tag = (sender as Button).Tag;
        }

        void ShowBill(int id)
        {
            CultureInfo culture = new CultureInfo("vi_VN");
            listViewHoaDon.Items.Clear();
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float TotalPrice = 0;
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.tenSanPham.ToString());
                lsvItem.SubItems.Add(item.tongSanPham.ToString());
                lsvItem.SubItems.Add(item.donGia.ToString("c",culture));
                lsvItem.SubItems.Add(item.TotalPrice.ToString("c", culture));
                TotalPrice += item.TotalPrice;
                listViewHoaDon.Items.Add(lsvItem);
            }
            txtTongTien.Text = TotalPrice.ToString("c", culture);
        }
        void ShowFood(int id)
        {
            CultureInfo culture = new CultureInfo("vi_VN");
            listViewHoaDon.Items.Clear();
            List<Food> listBillInfo = FoodDAO.Instance.GetListMenuByFood(id);
            foreach (Food item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenSanPham.ToString());
                lsvItem.SubItems.Add("1");
                lsvItem.SubItems.Add(item.DonGia.ToString("c", culture));
                listViewHoaDon.Items.Add(lsvItem);
            }
        }

        void LoadNV()
        {
            List<NhanVien> listnv = NhanVienDAO.Instance.GetListNV();
            foreach (NhanVien item in listnv)
            {
                txtID_NV.Text = item.NhanVienID.ToString();
                txtNV_Name.Text = item.HoVaTen.ToString();
            }
        }
        private void thôngTinNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormInfoNV f = new FormInfoNV();
            f.ShowDialog();
        }

        void LoadCategory()
        {
            List<LoaiSanPham> listCategory = LoaiSanPhamDAO.Instance.LoadListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "LoaiSanPham";
        }

        void LoadFoodListByCategory(int id)
        {
            List<Food> listCategory = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbProducts.DataSource = listCategory;
            cbProducts.DisplayMember = "TenSanPham";
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
            {
                return;
            }
            LoaiSanPham selected = cb.SelectedItem as LoaiSanPham;
            id = selected.LoaiSanPhamID;
            LoadFoodListByCategory(id);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = listViewHoaDon.Tag as Table;
            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.BanId);
            int idFood = (cbProducts.SelectedItem as Food).SanPhamID;
            int count = (int)numericUpDown1.Value;
            if (idBill == -1)
            {
                //them bill mới 
                BillDAO.Instance.InsertBill(table.BanId);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }
            ShowBill(table.BanId);
            LoadTable();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = listViewHoaDon.Tag as Table;
            int idBill = BillDAO.Instance.GetUnCheckBillByTableID(table.BanId);
            int discount = (int)numericUpDown2.Value;
            string [] Price  = (txtTongTien.Text.Split(","));
            double totalPrice = Convert.ToDouble(Price[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            if (idBill != -1)
            {
                if (MessageBox.Show(String.Format("Bạn có chắc muốn thanh toán hóa đơn cho bàn {0}\n Giảm giá: {1}% \n Tổng tiền: {2}.000", table.SoBan, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,discount,finalTotalPrice);
                    ShowBill(table.BanId);
                    LoadTable();
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

