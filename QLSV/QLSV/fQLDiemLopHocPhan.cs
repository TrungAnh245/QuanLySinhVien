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
    public partial class fQLDiemLopHocPhan : Form
    {
        public string tenLHP;
        public string hocky;
        public int malhp;
        QLSinhVienCon db = new QLSinhVienCon();
        public fQLDiemLopHocPhan()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void fQLDiemLopHocPhan_Load(object sender, EventArgs e)
        {
            lblCCTX.Visible = false;
            lblThi.Visible = false;
            this.CenterToScreen();
            lblLopHP.Text = "LỚP HỌC PHẦN: " + tenLHP;
            lblHocKy.Text = hocky;
            dgvDSSV.DataSource = db.xemDSSVLHP(malhp).ToList();
            dgvDSV.DataSource = db.xemDSDiemSV(malhp).ToList();
            dgvDSV.Enabled = false;
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTK1.Text))
            {
                DialogResult rs = MessageBox.Show("Xác nhận thêm sinh viên " + lblTenSV.Text + " mã " + lblMaSV.Text + " vào lớp học phần","XÁC NHẬN",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    int masvtk = int.Parse(txtTK1.Text);

                    //LINQ to entity
                    /*KetQuaLopHP temp = (from c in db.KetQuaLopHPs
                                where c.MaLHP == malhp && c.MaSV == masvtk
                                select c.MaLHP).FirstOrDefault();*/

                    //Entity
                    KetQuaLopHP temp = db.KetQuaLopHPs.Where(x => x.MaLHP == malhp && x.MaSV == masvtk).FirstOrDefault();
                    if (temp == null)
                    {
                        db.themKQLHP(int.Parse(txtTK1.Text), malhp);
                        dgvDSSV.DataSource = db.xemDSSVLHP(malhp);
                    }
                    else
                    {
                        MessageBox.Show("Đã có sinh viên " + lblTenSV.Text + " trong lớp học phần này !","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                   
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSSV.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa những sinh viên này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {

                    foreach (DataGridViewRow item in dgvDSSV.SelectedRows)
                    {
                        db.xoaKQLHP(int.Parse(item.Cells[0].Value.ToString()),malhp);


                    }

                    dgvDSSV.DataSource = db.xemDSSVLHP(malhp).ToList();
                 
                }

            }
        }

        private void txtTK1_TextChanged(object sender, EventArgs e)
        {
            SinhVien temp = db.SinhViens.Find(int.Parse(txtTK1.Text));
            if (temp != null)
            {
                lblGioiTinh.Text = temp.GioiTinh;
                lblLop.Text = temp.MaLop.ToString();
                lblMaSV.Text = temp.MaSV.ToString();
                lblNgaySinh.Text = DateTime.Parse(temp.NgaySinh.ToString()).ToString("dd/MM/yyyy");
                lblTenSV.Text = temp.HoTen;
            }
            else
            {
                lblGioiTinh.Text = "";
                lblLop.Text = "";
                lblMaSV.Text = "";
                lblNgaySinh.Text = "";
                lblTenSV.Text = "";
            }
            
        }

        private void txtTK2_TextChanged(object sender, EventArgs e)
        {
            dgvDSSV.DataSource = db.xemDSSVLHPTheoTen(malhp, txtTK2.Text).ToList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtTKTab2_TextChanged(object sender, EventArgs e)
        {
            dgvDSV.DataSource = db.xemDSDiemSVTheoTen(malhp, txtTKTab2.Text).ToList();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            dgvDSV.Enabled = true;
            dgvDSV.Columns[0].ReadOnly = true;
            dgvDSV.Columns[1].ReadOnly = true;
            dgvDSV.Columns[2].ReadOnly = true;
            dgvDSV.Columns[3].ReadOnly = true;
            dgvDSV.Columns[4].ReadOnly = true;
            dgvDSV.Columns[5].ReadOnly = true;
            dgvDSV.Columns[6].ReadOnly = true;
            dgvDSV.Columns[7].ReadOnly = true;
            dgvDSV.Columns[8].ReadOnly = true;
            dgvDSV.Columns[9].ReadOnly = true;
            DateTime now = DateTime.Now;
            if(now<=(db.LopHPs.Find(malhp).NgayThi)-(new TimeSpan(7, 0, 0, 0))){
                dgvDSV.Columns[4].ReadOnly = false;
                dgvDSV.Columns[5].ReadOnly = false;
            }
            else
            {
                lblCCTX.Visible = true;
            }
            if(now > (db.LopHPs.Find(malhp).NgayThi) && now<= (db.LopHPs.Find(malhp).NgayThi)+(new TimeSpan(7, 0, 0, 0)))
            {
                dgvDSV.Columns[6].ReadOnly = false;
               
            }
            else 
            {
                lblThi.Visible = true;
            }
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn lưu những thay đổi ?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dgvDSV.Rows)
                {
                    db.suaKQLHP(int.Parse(item.Cells[0].Value.ToString()), malhp, double.Parse(item.Cells[4].Value.ToString()),
                        double.Parse(item.Cells[5].Value.ToString()), double.Parse(item.Cells[6].Value.ToString()));
                }
                dgvDSV.DataSource = db.xemDSDiemSV(malhp);
                dgvDSV.Columns[4].ReadOnly = true;
                dgvDSV.Columns[5].ReadOnly = true;
                dgvDSV.Columns[6].ReadOnly = true;
                lblCCTX.Visible = false;
                lblThi.Visible = false;
            }
        }
    }
}
