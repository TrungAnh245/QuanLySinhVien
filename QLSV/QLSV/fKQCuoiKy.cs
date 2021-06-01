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
    public partial class fKQCuoiKy : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        public fKQCuoiKy()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fKQCuoiKy_Load(object sender, EventArgs e)
        {
            
            cbhk.DataSource = db.HocKies.ToList();
            cbhk.ValueMember = "MaHK";
            cbhk.DisplayMember = "HienThi";

            cbl.DataSource = db.LopChuyenNganhs.ToList();
            cbl.ValueMember = "MaLop";
            cbl.DisplayMember = "TenLop";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void cbhk_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbl_SelectedValueChanged(object sender, EventArgs e)
        {
             
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (cbhk.Text != "" && cbl.Text != "")
            {
                int ml = db.LopChuyenNganhs.Where(x => x.TenLop == cbl.Text.Trim()).FirstOrDefault().MaLop;
                int mhk = db.HocKies.Where(x => x.HienThi == cbhk.Text.Trim()).FirstOrDefault().MaHK;
                dgvDS.DataSource = db.xemKQHT(ml, mhk).ToList();
            }
        }
    }
}
