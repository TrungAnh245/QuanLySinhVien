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
    public partial class fQLMonHoc : Form
    {
        QLSinhVienCon db =new QLSinhVienCon();
        public fQLMonHoc()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void fQLMonHoc_Load(object sender, EventArgs e)
        {
            this.CenterToScreen(); 
            dgvDSHP.DataSource = db.xemDSHP("");
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            dgvDSHP.DataSource = db.xemDSHP(txtTK.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận thêm học phần này", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                HocPhan hp = new HocPhan();
                hp.TenHP = txtTenHP.Text.Trim();
                hp.SoTC = byte.Parse(txtSoTC.Text);
                hp.SoTiet = byte.Parse(txtSoTiet.Text);
                hp.HinhThucThi = txHinhThuc.Text.Trim();
                db.HocPhans.Add(hp);
                db.SaveChanges();
                dgvDSHP.DataSource = db.xemDSHP("");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận sửa học phần này", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    HocPhan hp = db.HocPhans.Find(int.Parse(txtMaHP.Text.Trim()));
                    hp.TenHP = txtTenHP.Text.Trim();
                    hp.SoTC = byte.Parse(txtSoTC.Text);
                    hp.SoTiet = byte.Parse(txtSoTiet.Text);
                    hp.HinhThucThi = txHinhThuc.Text.Trim();
                    db.SaveChanges();
                    dgvDSHP.DataSource = db.xemDSHP("").ToList();
                }
                catch (Exception)
                {

                    MessageBox.Show("Kiểm tra lại thông tin mã học phần", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txHinhThuc.Text = "";
            txtMaHP.Text = "";
            txtSoTC.Text = "";
            txtSoTiet.Text = "";
            txtTenHP.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvDSHP.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa những học phần đã chọn ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {

                    foreach (DataGridViewRow item in dgvDSHP.SelectedRows)
                    {
                        db.xoaHP(int.Parse(item.Cells[0].Value.ToString()));

                    }
                    dgvDSHP.DataSource = db.xemDSHP(txtTK.Text);
                }
            }
        }

        private void dgvDSHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSHP.SelectedRows.Count > 0)
            {
                txtMaHP.Text = dgvDSHP.SelectedRows[0].Cells[0].Value.ToString();
                txtTenHP.Text= dgvDSHP.SelectedRows[0].Cells[1].Value.ToString();
                txtSoTiet.Text= dgvDSHP.SelectedRows[0].Cells[2].Value.ToString();
                txtSoTC.Text= dgvDSHP.SelectedRows[0].Cells[3].Value.ToString();
                txHinhThuc.Text= dgvDSHP.SelectedRows[0].Cells[4].Value.ToString();
            }
        }
    }
}
