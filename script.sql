USE QLSinhVien
GO

CREATE FUNCTION [dbo].[change4](@diem10 FLOAT)
RETURNS FLOAT
BEGIN
	DECLARE @diem4 FLOAT
	IF @diem10 < 4
		SET @diem4 = 0
	ELSE IF @diem10 >= 4 AND @diem10 <= 4.9
		SET @diem4 = 1
	ELSE IF @diem10 >=5 AND @diem10 <= 5.4
		SET @diem4 = 1.5
	ELSE IF @diem10 >=5.5 AND @diem10 <= 6.4
		SET @diem4 = 2
	ELSE IF @diem10 >= 6.5 AND @diem10 <= 6.9
		SET @diem4 = 2.5
	ELSE IF @diem10 >=7 AND @diem10 <= 7.9
		SET @diem4 = 3
	ELSE IF @diem10 >= 8 AND @diem10 <= 8.4
		SET @diem4 = 3.5
	ELSE IF @diem10 >= 8.5 AND @diem10 <= 8.9
		SET @diem4 = 3.7
	ELSE IF @diem10 >= 9 AND @diem10 < =10
		SET @diem4 = 4
	RETURN @diem4
END
GO
/****** Object:  UserDefinedFunction [dbo].[changeW]    Script Date: 5/19/2021 5:01:50 PM ******/

 --Tạo hàm chuyển đổi điểm hệ 4 ->chữ
 CREATE FUNCTION [dbo].[changeW](@diem4 FLOAT)
RETURNS CHAR(2)
BEGIN
	DECLARE @diemChu CHAR(10)
	IF @diem4 = 0
		SET @diemChu = 'F'
	ELSE IF @diem4 = 1
		SET @diemChu = 'D'
	ELSE IF @diem4 = 1.5
		SET @diemChu = 'D+'
	ELSE IF @diem4 = 2
		SET @diemChu = 'C'
	ELSE IF @diem4 = 2.5
		SET @diemChu = 'C+'
	ELSE IF @diem4 =3
		SET @diemChu = 'B'
	ELSE IF @diem4 =3.5
		SET @diemChu = 'B+'
	ELSE IF @diem4 = 3.7
		SET @diemChu = 'A'
	ELSE IF @diem4 = 4
		SET @diemChu = 'A+'
	RETURN @diemChu
END
GO
/****** Object:  UserDefinedFunction [dbo].[changeXL]    Script Date: 5/19/2021 5:01:50 PM ******/

CREATE FUNCTION [dbo].[changeXL](@diem4 FLOAT)
RETURNS NVARCHAR(50)
BEGIN
	DECLARE @XL NVARCHAR(50)
	IF(@diem4>=3.2)
		SET @XL=N'GIỎI'
	ELSE IF(@diem4>=2.5)
		SET @XL=N'Khá'
	ELSE IF(@diem4>=1)
		SET @XL=N'TRUNG BÌNH'
	ELSE
		SET @XL=N'YẾU'
	RETURN @XL
END
GO


GO

CREATE TABLE [HocKy](
	[MaHK] int identity(1,1) NOT NULL primary key,
	HienThi nvarchar(30),
	TGBatDau date,
	TGKetThuc date
)
GO

CREATE TABLE [HocPhan](
	MaHP int NOT NULL identity(1,1) primary key,
	TenHP [nvarchar](100) NULL,
	[SoTiet] tinyint NULL,
	[SoTC] tinyint NULL,
	[HinhThucThi] [nvarchar](50) NULL
)
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] int identity(1,1) NOT NULL Primary key,
	[TenKhoa] [nvarchar](50) NULL
)
CREATE TABLE [dbo].[GiangVien](
	[MaGV] int identity(1,1) NOT NULL primary key,
	[TenGV] [nvarchar](50) NULL,
	MaKhoa int NULL references Khoa(MaKhoa),
	HienThi nvarchar(60),
	NgaySinh date,
	SDT char(10),
	Email varchar(50)
) 

CREATE TABLE [dbo].[LopChuyenNganh](
	[MaLop] int identity(1,1) NOT NULL Primary key,
	[TenLop] nvarchar(50) NULL,
	BatDau int,
	SoSV int NULL,
	[MaKhoa] int NULL references Khoa(MaKhoa)
)
CREATE TABLE [dbo].[SinhVien](
	[MaSV]  int NOT NULL identity(10000000,1) primary key,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] date NULL,
	[GioiTinh] Nvarchar(5) NULL,
	[STCD] [int] NULL,
	[STCDKy] [int] NULL,
	Avt nvarchar(100),
	[DiemTichLuy] [float] NULL,
	[MaLop] int NULL references LopChuyenNganh(MaLop)
)
CREATE TABLE [dbo].[TongKetKy](
	MaSV int NOT NULL references SinhVien(MaSV),
	[MaHK] int NOT NULL references HocKy(MaHK),
	[DiemTBC] [float] NULL,
	[STCDKy] [int] NULL,
	STCD int NULL,
	[XepLoai] [nvarchar](20) NULL
	constraint pk_tkk Primary key(MaSV,MaHK)
	
)
GO
CREATE TABLE [dbo].[LopHP](
	[MaLHP] int identity(1,1) NOT NULL primary key,
	[PhongHoc] [nvarchar](50) NULL,
	[NgayThi] date NULL,
	[TongSoSV] [int] NULL,
	[MaHP] int NULL references HocPhan(MaHP),
	[MaHK] int NULL references HocKy(MaHK),
	[MaGV] int NULL references GiangVien(MaGV)
)
CREATE TABLE [dbo].[KetQuaLopHP](
	[MaSV] int NOT NULL references SinhVien,
	[MaLHP] int NOT NULL references LopHP(MaLHP),
	[DiemCC] [float] NULL,
	[DiemTX] [float] NULL,
	[DiemThi] [float] NULL,
	[DiemHe10] [float] NULL,
	[DiemHe4] [float] NULL,
	[DiemChu] [char](10) NULL,
 CONSTRAINT PK_KQLHP PRIMARY KEY(MaSV,MaLHP) 
)
GO

