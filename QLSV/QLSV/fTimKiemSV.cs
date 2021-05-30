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
    
    public partial class fTimKiemSV : Form
    {
        QLSinhVienCon db = new QLSinhVienCon();
        public SinhVien sv;
        public fTimKiemSV()
        {
            InitializeComponent();
        }

        private void fTimKiemSV_Load(object sender, EventArgs e)
        {
            lblTen.Text = sv.HoTen.Trim();
            lblNgaySinh.Text = ((DateTime)sv.NgaySinh).ToString("dd/MM/yyyy");
            lblLop.Text = db.LopChuyenNganhs.Find(sv.LopChuyenNganh).TenLop.Trim();
            lblKhoa.Text = db.Khoas.Find(db.LopChuyenNganhs.Find(sv.LopChuyenNganh).Khoa).TenKhoa.Trim();
            lblGT.Text = sv.GioiTinh.Trim();
            lblDiem.Text = sv.DiemTichLuy.ToString().Trim();
            lblTC.Text = sv.STCDKy.ToString().Trim();
            lblTCD.Text = sv.STCD.ToString().Trim();
        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            sv = db.SinhViens.Find(txtTimKiem.Text.Trim());
            lblTen.Text = sv.HoTen.Trim();
            lblNgaySinh.Text = ((DateTime)sv.NgaySinh).ToString("dd/MM/yyyy");
            lblLop.Text = db.LopChuyenNganhs.Find(sv.LopChuyenNganh).TenLop.Trim();
            lblKhoa.Text = db.Khoas.Find(db.LopChuyenNganhs.Find(sv.LopChuyenNganh).Khoa).TenKhoa.Trim();
            lblGT.Text = sv.GioiTinh.Trim();
            lblDiem.Text = sv.DiemTichLuy.ToString().Trim();
            lblTC.Text = sv.STCDKy.ToString().Trim();
            lblTCD.Text = sv.STCD.ToString().Trim();
        }
    }
}
