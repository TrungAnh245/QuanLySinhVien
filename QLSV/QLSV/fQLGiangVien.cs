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
    public partial class fQLGiangVien : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        public fQLGiangVien()
        {
            InitializeComponent();
        }

        private void dgrDSGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtAnh_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void fQLGiangVien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cbKhoaTK.DataSource = (from c in db.Khoas
                                   select c.TenKhoa).ToList();
            cbKhoa.DataSource = (from c in db.Khoas
                                 select c.TenKhoa).ToList();
            dgvDSGV.DataSource = db.xemDSGV().ToList();
        }

        private void cbKhoaTK_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvDSGV.DataSource = db.xemDSGV().Where(x => x.Khoa == cbKhoaTK.SelectedItem.ToString()).ToList();
        }

        private void dgvDSGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSGV.SelectedRows.Count > 0)
            {
                txtMaGiangVien.Text = dgvDSGV.SelectedRows[0].Cells[0].Value.ToString();
                txtHoTen.Text = dgvDSGV.SelectedRows[0].Cells[1].Value.ToString();
                txtSDT.Text = dgvDSGV.SelectedRows[0].Cells[3].Value.ToString();
                cbKhoa.SelectedItem = dgvDSGV.SelectedRows[0].Cells[5].Value.ToString();
                txtEmail.Text = dgvDSGV.SelectedRows[0].Cells[4].Value.ToString();
                dpNgaySinh.Value = DateTime.Parse(dgvDSGV.SelectedRows[0].Cells[2].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận thêm giảng viên này?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                GiangVien gv = new GiangVien();
                gv.TenGV = txtHoTen.Text.Trim();
                gv.NgaySinh = dpNgaySinh.Value;
                gv.SDT = txtSDT.Text.Trim();
                gv.Email = txtEmail.Text.Trim();
                gv.MaKhoa = db.Khoas.Where(x => x.TenKhoa == cbKhoa.SelectedItem.ToString()).FirstOrDefault().MaKhoa;
                db.GiangViens.Add(gv);
                db.SaveChanges();
                dgvDSGV.DataSource = db.xemDSGV().Where(x => x.Khoa == cbKhoa.SelectedItem.ToString()).ToList();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

                DialogResult rs = MessageBox.Show("Xác nhận sửa giảng viên này?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        GiangVien gv = db.GiangViens.Find(int.Parse(txtMaGiangVien.Text.Trim()));
                        gv.TenGV = txtHoTen.Text.Trim();
                        gv.NgaySinh = dpNgaySinh.Value;
                        gv.SDT = txtSDT.Text.Trim();
                        gv.Email = txtEmail.Text.Trim();
                        gv.MaKhoa = db.Khoas.Where(x => x.TenKhoa == cbKhoa.SelectedItem.ToString()).FirstOrDefault().MaKhoa;
                        db.SaveChanges();
                        dgvDSGV.DataSource = db.xemDSGV().Where(x => x.Khoa == cbKhoa.SelectedItem.ToString()).ToList();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Kiểm tra lại thông tin mã giảng viên");
                    }
                    
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvDSGV.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa những giảng viên này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    
                    foreach (DataGridViewRow item in dgvDSGV.SelectedRows)
                    {
                        db.sp_xoaGV(int.Parse(item.Cells[0].Value.ToString()));
                        

                    }
                    
                    dgvDSGV.DataSource = db.xemDSGV().ToList();
                    dgvDSGV.Refresh();
                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtMaGiangVien.Text = "";
            txtSDT.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
        }
    }
}
