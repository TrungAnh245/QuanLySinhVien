using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class fQLSinhVien : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        List<int> delList = new List<int>();
        public fQLSinhVien()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fQLSinhVien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            var dsl = (from c in db.LopChuyenNganhs
                      select c.TenLop).ToList();
            dsl.Add("Tất cả");
            cbLopTK.DataSource = dsl;
            cbLop.DataSource = dsl.ToList();
            cboGioiTinh.SelectedValue = "Nam";

            dgrDSSV.DataSource = db.xemDSSV().ToList();
   
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("xác nhận thêm sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                SinhVien sv = new SinhVien();
                sv.HoTen = txtHoTen.Text.Trim();
                sv.NgaySinh = dpNgaySinh.Value;
                sv.GioiTinh = cboGioiTinh.Text.Trim();
                sv.MaLop = db.LopChuyenNganhs.Where(x => x.TenLop == cbLop.Text.Trim()).FirstOrDefault().MaLop;
                sv.Email = txtEmail.Text.Trim();
                sv.SDT = txtSDT.Text.Trim();
                sv.DiaChi = txtDiaChi.Text.Trim();
                sv.STCDKy = 0;
                sv.STCD = 0;
                sv.DiemTichLuy = 0;
                db.SinhViens.Add(sv);
                if (rs == DialogResult.Yes)
                {

                    db.SaveChanges();
                    dgrDSSV.DataSource = db.xemDSSV();
                }
            }
            catch (NullReferenceException )
            {

                MessageBox.Show("Kiểm tra lại thông tin lớp chuyên ngành", "Thử lại !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
                if(string.IsNullOrEmpty(txtMaSV.Text) || db.SinhViens.Find(int.Parse(txtMaSV.Text.Trim())) == null)
                {
                    MessageBox.Show("Mã sinh viên này không đúng !");
                }
                else
                {
                    DialogResult rs = MessageBox.Show("xác nhận sửa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    SinhVien sv = db.SinhViens.Find(int.Parse(txtMaSV.Text.Trim()));
                    sv.HoTen = txtHoTen.Text.Trim();
                    sv.NgaySinh = dpNgaySinh.Value;
                    sv.GioiTinh = cboGioiTinh.Text.Trim();
                    sv.MaLop = db.LopChuyenNganhs.Where(x => x.TenLop == cbLop.Text.Trim()).FirstOrDefault().MaLop;
                    sv.Email = txtEmail.Text.Trim();
                    sv.SDT = txtSDT.Text.Trim();
                    sv.DiaChi = txtDiaChi.Text.Trim();
                    sv.STCDKy = 0;
                    sv.STCD = 0;
                    sv.DiemTichLuy = 0;

                    if (rs == DialogResult.Yes)
                    {

                        db.SaveChanges();
                        dgrDSSV.DataSource = db.xemDSSV().Where(x => x.Lớp== cbLopTK.Text).ToList();
                        dgrDSSV.Refresh();
                    }
                }   
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgrDSSV.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa những sinh viên này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    
                    foreach (DataGridViewRow item in dgrDSSV.SelectedRows)
                    {
                       db.sp_xoaSV(int.Parse(item.Cells[0].Value.ToString()));
                       

                    }

                    dgrDSSV.DataSource = db.xemDSSV().ToList();
                    dgrDSSV.Refresh();
                }
                
            }
            
        }

        private void cbLopTK_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbLopTK.SelectedValue=="Tất cả")
            {
                dgrDSSV.DataSource = db.xemDSSV().ToList();
            }
            else
            {
                dgrDSSV.DataSource = db.xemDSSV().Where(x => x.Lớp == cbLopTK.Text).ToList();
                dgrDSSV.Refresh();
            }
            
        }

        private void cbLopTK_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbLopTK_SelectionChangeCommitted(object sender, EventArgs e)
        {
    
        }

        private void cbLopTK_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgrDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDSSV.SelectedRows[0].Cells[0].Value.ToString();
            txtHoTen.Text = dgrDSSV.SelectedRows[0].Cells[1].Value.ToString();
            dpNgaySinh.Value= DateTime.Parse(dgrDSSV.SelectedRows[0].Cells[2].Value.ToString());
            cboGioiTinh.SelectedItem = dgrDSSV.SelectedRows[0].Cells[3].Value.ToString();
            cbLop.SelectedItem= dgrDSSV.SelectedRows[0].Cells[6].Value.ToString();
            txtSDT.Text= dgrDSSV.SelectedRows[0].Cells[7].Value.ToString();
            txtEmail.Text = dgrDSSV.SelectedRows[0].Cells[8].Value.ToString();
            txtDiaChi.Text = dgrDSSV.SelectedRows[0].Cells[9].Value.ToString();

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
