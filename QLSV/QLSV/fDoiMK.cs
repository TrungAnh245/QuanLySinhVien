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
    public partial class fDoiMK : Form
    {
        public fDoiMK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMKmoi.Text == txtConfimMk.Text)
            {
                DialogResult rs = MessageBox.Show("Xác nhận đổi mật khẩu ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    QLSinhVienCon db = new QLSinhVienCon();
                    Admin temp = db.Admins.Find(acc.Trim());
                    temp.Pass = txtMKmoi.Text;
                    db.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
            }
            else
            {
                MessageBox.Show("Xác nhận lại mật khẩu mới không khớp !");
            }
            
        }

        private void fDoiMK_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lblSai.Visible = false;
        }

        private void txtConfimMk_TextChanged(object sender, EventArgs e)
        {
            if (txtMKmoi.Text != txtConfimMk.Text)
            {
                lblSai.Visible = true;
            }
            else
            {
                lblSai.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
