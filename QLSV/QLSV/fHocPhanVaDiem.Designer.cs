
namespace QLSV
{
    partial class fHocPhanVaDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHocPhanVaDiem));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTLHP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dpNgayThi = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.cbHP = new System.Windows.Forms.ComboBox();
            this.cbHK = new System.Windows.Forms.ComboBox();
            this.cbGV = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaLopHocPhan = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.button2 = new System.Windows.Forms.Button();
            this.bntThem = new System.Windows.Forms.Button();
            this.dgvHP = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLopTK = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLopHocPhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHP)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ToolTipTitle = "*Note";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "QUẢN LÝ THÔNG TIN LỚP HỌC PHẦN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Mã lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tên lớp";
            // 
            // txtTLHP
            // 
            this.txtTLHP.Location = new System.Drawing.Point(106, 67);
            this.txtTLHP.Name = "txtTLHP";
            this.txtTLHP.Size = new System.Drawing.Size(145, 22);
            this.txtTLHP.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Giảng viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Học kỳ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(550, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "Giảng đường";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(567, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Học phần";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dpNgayThi
            // 
            this.dpNgayThi.CustomFormat = "dd/MM/yyyy";
            this.dpNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpNgayThi.Location = new System.Drawing.Point(106, 117);
            this.dpNgayThi.Name = "dpNgayThi";
            this.dpNgayThi.Size = new System.Drawing.Size(145, 22);
            this.dpNgayThi.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ngày thi";
            // 
            // txtPH
            // 
            this.txtPH.Location = new System.Drawing.Point(643, 28);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(145, 22);
            this.txtPH.TabIndex = 26;
            // 
            // cbHP
            // 
            this.cbHP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbHP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHP.FormattingEnabled = true;
            this.cbHP.Location = new System.Drawing.Point(643, 76);
            this.cbHP.Name = "cbHP";
            this.cbHP.Size = new System.Drawing.Size(145, 23);
            this.cbHP.TabIndex = 27;
            // 
            // cbHK
            // 
            this.cbHK.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbHK.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHK.FormattingEnabled = true;
            this.cbHK.ItemHeight = 15;
            this.cbHK.Location = new System.Drawing.Point(362, 21);
            this.cbHK.Name = "cbHK";
            this.cbHK.Size = new System.Drawing.Size(145, 23);
            this.cbHK.TabIndex = 28;
            // 
            // cbGV
            // 
            this.cbGV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGV.FormattingEnabled = true;
            this.cbGV.ItemHeight = 15;
            this.cbGV.Location = new System.Drawing.Point(362, 73);
            this.cbGV.Name = "cbGV";
            this.cbGV.Size = new System.Drawing.Size(145, 23);
            this.cbGV.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaLopHocPhan);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.cbGV);
            this.groupBox1.Controls.Add(this.cbHK);
            this.groupBox1.Controls.Add(this.cbHP);
            this.groupBox1.Controls.Add(this.txtPH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dpNgayThi);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bntThem);
            this.groupBox1.Controls.Add(this.txtTLHP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(827, 169);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // txtMaLopHocPhan
            // 
            this.txtMaLopHocPhan.Location = new System.Drawing.Point(106, 26);
            this.txtMaLopHocPhan.Name = "txtMaLopHocPhan";
            this.txtMaLopHocPhan.Size = new System.Drawing.Size(145, 20);
            this.txtMaLopHocPhan.TabIndex = 42;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::QLSV.Properties.Resources.refresh2_32x32;
            this.simpleButton1.Location = new System.Drawing.Point(778, 129);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(43, 35);
            this.simpleButton1.TabIndex = 41;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(697, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 17;
            this.button2.Text = "Sửa";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bntThem
            // 
            this.bntThem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.Image = ((System.Drawing.Image)(resources.GetObject("bntThem.Image")));
            this.bntThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntThem.Location = new System.Drawing.Point(610, 127);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(81, 39);
            this.bntThem.TabIndex = 16;
            this.bntThem.Text = "Thêm";
            this.bntThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
            // 
            // dgvHP
            // 
            this.dgvHP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHP.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHP.Location = new System.Drawing.Point(0, 47);
            this.dgvHP.Name = "dgvHP";
            this.dgvHP.ReadOnly = true;
            this.dgvHP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHP.Size = new System.Drawing.Size(821, 153);
            this.dgvHP.TabIndex = 0;
            this.dgvHP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHP_CellClick);
            this.dgvHP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHP_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvHP);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(23, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(827, 200);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(752, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 32);
            this.button3.TabIndex = 18;
            this.button3.Text = "Xóa";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Học phần";
            // 
            // cbLopTK
            // 
            this.cbLopTK.FormattingEnabled = true;
            this.cbLopTK.Location = new System.Drawing.Point(168, 19);
            this.cbLopTK.Name = "cbLopTK";
            this.cbLopTK.Size = new System.Drawing.Size(180, 21);
            this.cbLopTK.TabIndex = 14;
            this.cbLopTK.SelectedIndexChanged += new System.EventHandler(this.cbLopTK_SelectedIndexChanged);
            this.cbLopTK.SelectedValueChanged += new System.EventHandler(this.cbLopTK_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbLopTK);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(222, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(455, 46);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Appearance.Options.UseForeColor = true;
            this.simpleButton3.ImageOptions.SvgImage = global::QLSV.Properties.Resources.bo_document;
            this.simpleButton3.Location = new System.Drawing.Point(742, 12);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(102, 42);
            this.simpleButton3.TabIndex = 41;
            this.simpleButton3.Text = "Quản lý \r\nhọc phần";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ImageOptions.Image = global::QLSV.Properties.Resources.backward_32x32;
            this.simpleButton2.Location = new System.Drawing.Point(12, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(105, 32);
            this.simpleButton2.TabIndex = 40;
            this.simpleButton2.Text = "Quay lại";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // fHocPhanVaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 475);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "fHocPhanVaDiem";
            this.Text = "QUẢN LÝ THÔNG TIN LỚP HỌC PHẦN";
            this.Load += new System.EventHandler(this.fQLHocPhan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLopHocPhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHP)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTLHP;
        private System.Windows.Forms.Button bntThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dpNgayThi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.ComboBox cbHP;
        private System.Windows.Forms.ComboBox cbHK;
        private System.Windows.Forms.ComboBox cbGV;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgvHP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLopTK;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.TextEdit txtMaLopHocPhan;
    }
}