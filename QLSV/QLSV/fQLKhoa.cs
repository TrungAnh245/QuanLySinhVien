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
    public partial class fQLKhoa : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        public fQLKhoa()
        {
            InitializeComponent();
        }

        private void dgrKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("xác nhận thêm khoa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (rs == DialogResult.Yes)
            {
                Khoa k = new Khoa();
                k.TenKhoa = txtTenKhoa.Text.Trim();
                db.Khoas.Add(k);
                db.SaveChanges();
                dgvDSK.DataSource = db.xemDSK();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("xác nhận sửa khoa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    Khoa k = db.Khoas.Find(int.Parse(txtKhoa.Text.Trim()));
                    k.TenKhoa = txtTenKhoa.Text.Trim();
                    db.SaveChanges();
                    dgvDSK.DataSource = db.xemDSK();
                }
                catch (Exception)
                {

                    MessageBox.Show("Kiểm tra lại thông tin mã khoa");
                }
                
            }
        }

        private void dgvDSK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSK.SelectedRows.Count > 0)
            {
                txtKhoa.Text = dgvDSK.SelectedRows[0].Cells[0].Value.ToString();
                txtTenKhoa.Text = dgvDSK.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvDSK.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa khoa này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {

                    foreach (DataGridViewRow item in dgvDSK.SelectedRows)
                    {
                        db.sp_xoaK(int.Parse(item.Cells[0].Value.ToString()));


                    }

                    dgvDSK.DataSource = db.xemDSK().ToList();
            
                }

            }
        }

        private void fQLKhoa_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            dgvDSK.DataSource = db.xemDSK().ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
