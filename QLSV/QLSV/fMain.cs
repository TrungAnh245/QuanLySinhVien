using DevExpress.XtraEditors;
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

    public partial class fMain : DevExpress.XtraEditors.XtraForm
    {
        public fMain()
        {
            InitializeComponent();
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fQLSinhVien f = new fQLSinhVien();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fQLGiangVien f = new fQLGiangVien();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fQLLopChuyenNganh f = new fQLLopChuyenNganh();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fQLKhoa f = new fQLKhoa();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fHocPhanVaDiem f = new fHocPhanVaDiem();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            fTimKiemSV f = new fTimKiemSV();
            SinhVien tempSV = (new QLSinhVienCon()).SinhViens.Find(txtTimkiem.Text.Trim());
            if (tempSV == null)
            {
                MessageBox.Show("Mã sinh viên này không tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                f.sv = tempSV;
                f.Show();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void fMain_Load(object sender, EventArgs e)
        {
            QLSinhVienCon db = new QLSinhVienCon();
            DateTime now = DateTime.Now;
            int hk =db.HocKies.Where(x => x.TGKetThuc < now).Max(x => x.MaHK);

            if (hk != 0)
            {
                foreach (SinhVien item in db.SinhViens.ToList())
                {
                    var v=db.capnhatdiemvasotinchi(hk, item.MaSV);
                }
            }
            this.CenterToScreen();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fKQCuoiKy f = new fKQCuoiKy();
            f.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fDoiMK f = new fDoiMK();
            f.acc = lblAcc.Text.Trim();
            f.Visible = true;
        }
    }
}