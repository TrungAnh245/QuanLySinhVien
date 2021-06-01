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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lblSai.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            QLSinhVienCon db =new QLSinhVienCon();
            var temp = db.Admins.Where(x => x.Account == txtAcc.Text.Trim() && x.Pass == txtPass.Text.Trim());
            if ( temp!=null)
            {
                fMain f = new fMain();
                f.lblAcc.Text = txtAcc.Text;
                f.lblAcc.Visible = false;
                f.lblten.Text = db.Admins.Find(txtAcc.Text.Trim()).Fullname;
                f.Visible = true;
                this.Visible = false;
            }
            else
            {
                lblSai.Visible = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
