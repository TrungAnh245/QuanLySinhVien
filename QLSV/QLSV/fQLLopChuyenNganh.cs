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
    public partial class fQLLopChuyenNganh : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        public fQLLopChuyenNganh()
        {
            InitializeComponent();
        }

        private void fQLLopChuyenNganh_Load(object sender, EventArgs e)
        {
            this.CenterToScreen(); 
            var tempL= (from c in db.Khoas
                                   select c.TenKhoa).ToList();
            tempL.Add("Tất cả");
            cbKhoaTK.DataSource = tempL;
            cbKhoaTK.SelectedItem = "Tất cả";
            cbKhoa.DataSource = (from c in db.Khoas
                                 select c.TenKhoa).ToList();
            dgvLop.DataSource = db.xemDSLCN().ToList();

        }

        private void cbKhoaTK_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbKhoaTK.SelectedValue=="Tất cả")
            {
                dgvLop.DataSource = db.xemDSLCN().ToList();
            }
            else
            {
                dgvLop.DataSource = db.xemDSLCN().Where(x => x.khoa.Trim() == cbKhoaTK.SelectedValue.ToString().Trim()).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (db.LopChuyenNganhs.Where(x => x.TenLop == txtTenlop.Text.Trim()) != null)
            {
                DialogResult rs = MessageBox.Show("Xác nhận thêm lớp chuyên ngành này?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {

                    LopChuyenNganh lcn = new LopChuyenNganh();
                    lcn.TenLop = txtTenlop.Text.Trim();
                    lcn.MaKhoa = db.Khoas.Where(x => x.TenKhoa == cbKhoa.SelectedItem.ToString()).FirstOrDefault().MaKhoa;
                    lcn.BatDau = int.Parse(txtBatDau.Text.Trim());
                    lcn.KetThuc = int.Parse(txtKetThuc.Text.Trim());
                    lcn.SoSV = 0;
                    db.LopChuyenNganhs.Add(lcn);
                    db.SaveChanges();
                    dgvLop.DataSource = db.xemDSLCN().Where(x => x.khoa.Trim() == cbKhoa.SelectedValue.ToString().Trim()).ToList();
                }
            }
            else
            {
                MessageBox.Show("Lớp " + txtTenlop.Text.Trim() + " đã tồn tại!", "Thử lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
           
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận sửa lớp chuyển ngành này?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    LopChuyenNganh lcn = db.LopChuyenNganhs.Find(int.Parse(txtML.Text.Trim()));
                    lcn.TenLop = txtTenlop.Text.Trim();
                    lcn.MaKhoa = db.Khoas.Where(x => x.TenKhoa == cbKhoa.SelectedItem.ToString()).FirstOrDefault().MaKhoa;
                    lcn.BatDau = int.Parse(txtBatDau.Text.Trim());
                    lcn.KetThuc = int.Parse(txtKetThuc.Text.Trim());
                    db.SaveChanges();
                    dgvLop.DataSource = db.xemDSLCN().Where(x => x.khoa.Trim() == cbKhoa.SelectedValue.ToString().Trim()).ToList();
                }
                catch (Exception)
                {

                    MessageBox.Show("Kiểm tra lại thông tin mã lớp");
                }
                
            }
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                txtML.Text = dgvLop.SelectedRows[0].Cells[0].Value.ToString();
                txtTenlop.Text = dgvLop.SelectedRows[0].Cells[1].Value.ToString();
                cbKhoa.SelectedItem = dgvLop.SelectedRows[0].Cells[2].Value.ToString();
                txtBatDau.Text = db.LopChuyenNganhs.Find(int.Parse(txtML.Text)).BatDau.ToString();
                txtKetThuc.Text = db.LopChuyenNganhs.Find(int.Parse(txtML.Text)).KetThuc.ToString();
            }
           
        }

        private void bntXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa những lớp này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {

                    foreach (DataGridViewRow item in dgvLop.SelectedRows)
                    {
                        db.xoaLCN(int.Parse(item.Cells[0].Value.ToString()));


                    }

                    dgvLop.DataSource = db.xemDSLCN().ToList();
                    dgvLop.Refresh();
                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtML.Text = "";
            txtTenlop.Text = "";
            txtBatDau.Text = "";
            txtKetThuc.Text = "";
        }

        private void txtKetThuc_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
