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
    public partial class fHocPhanVaDiem : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        public fHocPhanVaDiem()
        {
            InitializeComponent();
        }

        private void fQLHocPhan_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            var temp = db.HocPhans.Select(x => x.TenHP).ToList();
          
            temp.Add("Tất cả");
            cbLopTK.DataSource = temp;
            cbLopTK.SelectedItem = "Tất cả";
            cbHK.DataSource = db.HocKies.ToList();
            cbHK.DisplayMember = "HienThi";
            cbHK.ValueMember = "MaHK";
            
            cbHP.DataSource = db.HocPhans.ToList();
            cbHP.DisplayMember = "TenHP";
            cbHP.ValueMember = "MaHP";

            cbGV.DataSource = db.GiangViens.ToList();
            cbGV.DisplayMember = "HienThi";
            cbGV.ValueMember = "MaGV";
            dgvHP.DataSource = db.xemDSLHP().ToList();
        }

        private void cbLopTK_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbLopTK.SelectedItem=="Tất cả")
            {
                dgvHP.DataSource = db.xemDSLHP().ToList();
            }
            else
            {
                dgvHP.DataSource = db.xemDSLHP().Where(x => x.Học_phần == cbLopTK.Text).ToList();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dgvHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHP.SelectedRows.Count > 0)
            {
                txtMaLopHocPhan.Text = dgvHP.SelectedRows[0].Cells[0].Value.ToString();
                txtTLHP.Text= dgvHP.SelectedRows[0].Cells[1].Value.ToString();
                cbHK.SelectedItem= dgvHP.SelectedRows[0].Cells[6].Value.ToString();
                cbGV.Text= dgvHP.SelectedRows[0].Cells[7].Value.ToString();
                txtPH.Text= dgvHP.SelectedRows[0].Cells[4].Value.ToString();
                cbHP.Text= dgvHP.SelectedRows[0].Cells[5].Value.ToString();
                dpNgayThi.Value=DateTime.Parse(dgvHP.SelectedRows[0].Cells[3].Value.ToString());
            }
        }

        private void cbLopTK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận thêm lớp học phần này", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                var temp = db.LopHPs.Where(x => x.TenLHP == txtTLHP.Text && x.MaHK == (int)cbHK.SelectedValue).FirstOrDefault();
                if (temp == null)
                {
                    
                    LopHP lhp = new LopHP();
                    lhp.TenLHP = txtTLHP.Text.Trim();
                    lhp.MaHK = (int)cbHK.SelectedValue;
                    lhp.MaGV = (int)cbGV.SelectedValue;
                    lhp.PhongHoc = txtPH.Text.Trim();
                    lhp.MaHP = (int)cbHP.SelectedValue;
                    lhp.NgayThi = dpNgayThi.Value;
                    lhp.TongSoSV = 0;
                    db.LopHPs.Add(lhp);
                    db.SaveChanges();
                    if (cbLopTK.SelectedItem == "Tất cả")
                    {
                        dgvHP.DataSource = db.xemDSLHP().ToList();
                    }
                    else
                    {
                        dgvHP.DataSource = db.xemDSLHP().Where(x => x.Học_phần == cbLopTK.Text).ToList();
                    }

                }
                else
                {
                    MessageBox.Show("Đã tồn tại lớp " + txtTLHP.Text.Trim() + " trong " + cbHK.Text, "Thử lại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Xác nhận sửa lớp học phần này", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                
                    try
                    {
                        LopHP lhp = db.LopHPs.Find(int.Parse(txtMaLopHocPhan.Text));
                        lhp.TenLHP = txtTLHP.Text.Trim();
                        lhp.MaHK = (int)cbHK.SelectedValue;
                        lhp.MaGV = (int)cbGV.SelectedValue;
                        lhp.PhongHoc = txtPH.Text.Trim();
                        lhp.MaHP = (int)cbHP.SelectedValue;
                        lhp.NgayThi = dpNgayThi.Value;
                        db.SaveChanges();
                    if (cbLopTK.SelectedItem == "Tất cả")
                    {
                        dgvHP.DataSource = db.xemDSLHP().ToList();
                    }
                    else
                    {
                        dgvHP.DataSource = db.xemDSLHP().Where(x => x.Học_phần == cbLopTK.Text).ToList();
                    }
                }
                    catch (Exception)
                    {

                        MessageBox.Show("Kiểm tra lại thông tin mã lớp");
                    }
                

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtMaLopHocPhan.Text = "";
            txtPH.Text = "";
            txtTLHP.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvHP.SelectedRows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("Xác nhận xóa những lớp học phần đã chọn ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {

                    foreach (DataGridViewRow item in dgvHP.SelectedRows)
                    {
                        db.xoaLHP(int.Parse(item.Cells[0].Value.ToString()));

                    }
                    if (cbLopTK.SelectedItem == "Tất cả")
                    {
                        dgvHP.DataSource = db.xemDSLHP().ToList();
                    }
                    else
                    {
                        dgvHP.DataSource = db.xemDSLHP().Where(x => x.Học_phần == cbLopTK.Text).ToList();
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            fQLMonHoc f = new fQLMonHoc();
            f.Visible = true;
        }

        private void dgvHP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fQLDiemLopHocPhan f = new fQLDiemLopHocPhan();
            f.tenLHP = dgvHP.SelectedRows[0].Cells[1].Value.ToString();
            f.hocky = dgvHP.SelectedRows[0].Cells[6].Value.ToString();
            f.malhp = int.Parse(dgvHP.SelectedRows[0].Cells[0].Value.ToString());
            f.Visible=true;
        }
    }
}
