
--form QLSinhVien
--proc lấy danh sách sinh viên
CREATEalter PROC xemDSSV
AS
BEGIN
	select sv.MaSV as [Mã sinh viên],sv.HoTen as [Tên sinh viên],sv.NgaySinh as [Ngày sinh],
	sv.GioiTinh as [Giới tính],lcn.TenLop as  [Lớp],sv.SDT as [SĐT],
	sv.Email,sv.DiaChi as [Địa chỉ]
	from SinhVien sv join LopChuyenNganh lcn on sv.MaLop=lcn.MaLop
END
--trigger cập nhật khi thêm, xóa sinh viên
CREATEalter TRIGGER themSV
On SinhVien
AFTER insert
AS
BEGIN
	declare @malop int,@nambd int,@mahkd int,@masv int
	select @malop=i.MaLop,@masv=i.MaSV
	from inserted i
	--tăng 1 sinh viên
	UPDATE LopChuyenNganh
	SET SoSV=SoSV+1
	WHERE MaLop=@malop

	select @nambd=lcn.BatDau
	from LopChuyenNganh lcn
	where lcn.MaLop=@malop

	select @mahkd=hk.MaHK
	from HocKy hk
	where hk.HienThi = Convert(nvarchar(30),N'Kì 1('+Convert(char(4),@nambd)+'-'+Convert(char(4),@nambd+1)+')')
	declare @count int=@mahkd
	while @count<@mahkd+16
	BEGIN
		insert into TongKetKy(MaHK,MaSV,DiemTBC,STCDKy,STCD,XepLoai)
		VALUES(@count,@masv,0,0,0,N'Yếu')
		Set @count=@count+1
	END
	--tạo bản ghi 8 năm(16 học kỳ) cho sinh viên

END
--trigger cập nhật khi xóa sinh viên
CREATE TRIGGER xoaSV
On SinhVien
AFTER insert
AS
BEGIN

	declare @malop int
	select @malop=i.MaLop
	from deleted i

	UPDATE LopChuyenNganh
	SET SoSV=SoSV-1
	WHERE MaLop=@malop


END
go
--proc xóa sinh viên
CREATEalter PROC sp_xoaSV
@masv int
as
BEGIN
	--xóa bảng tổng kết kỳ và kết quả lớp học phần\
	delete TongKetKy
	where MaSV=@masv

	delete KetQuaLopHP
	where MaSV=@masv

	delete SinhVien
	where MaSV=@masv
END
--form QLGiangVien
--proc  lây danh sách giảng viên
CREATE PROC xemDSGV
AS
BEGIN
	select gv.MaGV as [Mã giảng viên], gv.TenGV as [Tên giảng viên],gv.NgaySinh as [Ngày sinh],
	gv.SDT as[SĐT],gv.Email,k.TenKhoa as [Khoa]
	from GiangVien gv join Khoa k on gv.MaKhoa=k.MaKhoa
END

--proc xóa Giảng viên
CREATE PROC sp_xoaGV
@magv int
AS
BEGIN
	--set mã giảng viên trong lớp học phần về null
	UPDATE LopHP
	set MaGV=null
	where MaGV=@magv

	delete GiangVien
	where MaGV=@magv
END

--form quản lý lớp
--proc xem danh sách lớp
CREATEalter PROC xemDSLCN
AS
BEGIN
	select lcn.MaLop as [Mã lớp],lcn.TenLop as[Tên lớp],k.TenKhoa as [khoa],lcn.SoSV as[Số sinh viên],
	convert(char(11),(CONVERT(char(4),lcn.BatDau)+'-'+CONVERT(char(4),lcn.KetThuc))) as[Niên khóa]
	from LopChuyenNganh lcn join Khoa k on lcn.MaKhoa=k.MaKhoa
END
--proc xóa lớp
CREATE PROC xoaLCN
@malcn int
AS
BEGIN
	--set mã lớp sinh viên ở lớp này thành null
	UPDATE SinhVien
	Set MaLop=Null
	where MaLop=@malcn

	--xóa lớp 
	Delete LopChuyenNganh
	where MaLop=@malcn
END
--form quản lý khoa
--proc xem danh sách khoa
CREATE PROC xemDSK
AS
BEGIN
	select MaKhoa as [Mã khoa], TenKhoa as[Tên khoa]
	from Khoa
END
--proc xóa khoa
CREATE PROC sp_xoaK
@mak int
AS
BEGIN
	--set null giảng viên
	UPDATE GiangVien
	set MaKhoa=null
	where MaKhoa=@mak

	--set null lớp chuyên ngành
	UPDaTE LopChuyenNganh
	set MaKhoa=null
	where MaKhoa=@mak

	--xóa khoa
	DELETE Khoa
	Where MaKhoa=@mak
END
--form quản lý học phần
CREATEalter PROC xemDSLHP

AS 
BEGIN
	select lhp.MaLHP as [Mã học phần], lhp.TenLHP as [Tên],lhp.TongSoSV as [Số sinh viên],
	lhp.NgayThi as [Ngày thi],lhp.PhongHoc as [Giảng đường],hp.TenHP as[Học phần],hk.HienThi as[Học kì],
	gv.HienThi as [Giảng viên]
	from LopHP lhp join HocKy hk on lhp.MaHK=hk.MaHK join HocPhan hp on lhp.MaHP=hp.MaHP join GiangVien gv on lhp.MaGV=gv.MaGV

END

--proc xóa lớp học phần
CREATE PROC xoaLHP
@malhp int
AS
BEGIN
	delete KetQuaLopHP
	where MaLHP=@malhp

	delete LopHP
	where MaLHP=@malhp
END
--xem danh sách môn học
CREATE PROC xemDSHP
@key nvarchar(100)
AS
BEGIN
	select MaHP as [Mã học phần], TenHP as [Tên học phần], SoTiet as [Số tiết học],SoTC as[Số tín chỉ],
	HinhThucThi as[Hình thức thi]
	from HocPhan
	where TenHP like '%'+@key+'%'
END
---xóa học phần
CREATE PROC xoaHP
@mahp int
AS
BEGIN
	--set  mã hp trong lớp học phần về null
	UPDATE LopHP
	set MaHP=null
	where MaHP=@mahp
	--xóa
	delete HocPhan
	where MaHP=@mahp
END

--form quản lý sinh viên lớp học phần
--proc xem danh sách sinh viên lớp học phần
CREATEalter PROC xemDSSVLHP
@malop int
AS
BEGIN
	select sv.MaSV as[Mã sinh viên],sv.HoTen as[Họ tên],sv.GioiTinh as [Giới tính],sv.NgaySinh as [Ngày sinh],
	lcn.TenLop as [Lớp]
	from KetQuaLopHP kq join SinhVien sv on kq.MaSV=sv.MaSV join LopChuyenNganh lcn on sv.MaLop=lcn.MaLop
	where kq.MaLHP=@malop
END
--proc xem danh sách sinh viên lớp học phần theo tên
CREATE PROC xemDSSVLHPTheoTen
@malop int,
@key nvarchar(100)
AS
BEGIN
	select sv.MaSV as[Mã sinh viên],sv.HoTen as[Họ tên],sv.GioiTinh as [Giới tính],sv.NgaySinh as [Ngày sinh],
	lcn.TenLop as [Lớp]
	from KetQuaLopHP kq join SinhVien sv on kq.MaSV=sv.MaSV join LopChuyenNganh lcn on sv.MaLop=lcn.MaLop
	where kq.MaLHP=@malop and sv.HoTen like '%'+@key+'%'
END
--prco thêm kết quả lớp học phần
CREATE PROC themKQLHP
@masv int,
@malhp int
AS
BEGIN
	--tìm mã học phần,số tín,mã học kỳ
	declare @mahp int,@sotc tinyint,@mahk int
	select @mahp=l.MaHP,@sotc=hp.SoTC,@mahk=l.MaHK
	from LopHP l join HocPhan hp on l.MaHP=hp.MaHP
	where l.MaLHP=@malhp
	--lần đã học học phần
	declare @count int
	select @count=COUNT(*)
	from KetQuaLopHP kq join LopHP l on kq.MaLHP=l.MaLHP join HocPhan hp on l.MaHP=hp.MaHP
	where hp.MaHP=@mahp and kq.MaSV=@masv
	
	--tăng số sinh viên trong lớp học phần
	UPDATE LopHP
	set TongSoSV=TongSoSV+1
	where MaLHP=@malhp

	--them kết quả lớp học phần
	INSERT INTO KetQuaLopHP(MaSV,MaLHP,DiemCC,DiemTX,DiemThi,DiemHe10,DiemHe4,DiemChu,LanHocLai)
	VALUES(@masv,@malhp,0,0,0,0,0,'F',@count+1)
END

--proc xóa kêt quả lhp
CREATE PROC xoaKQLHP
@masv int,
@malhp int
AS
BEGIN
	--giảm số sinh viên lớp học phần
	UPDATE LopHP
	set TongSoSV=TongSoSV-1
	where MaLHP=@malhp

	--xóa
	DELETE KetQuaLopHP
	where MaSV=@masv and MaLHP=@malhp
END

--proc xem danh sách điểm sinh viên trogn lớp
CREATEalter PROC xemDSDiemSV
@malhp int
AS
BEGIN
	select sv.MaSV as[Mã sinh viên],sv.HoTen as[họ tên],sv.NgaySinh as[Ngày sinh],sv.GioiTinh as[Giới tính],
	ROUND(kq.DiemCC,2) as [Điểm CC], ROUND(kq.DiemTX,2) as [Điểm TX],ROUND(kq.DiemThi,2) as[Điểm thi],ROUND(kq.DiemHe10,2) as [Hệ 10],
	ROUND(kq.DiemHe4,2) as [Hệ 4],kq.DiemChu as[Điểm chữ]
	from KetQuaLopHP kq join SinhVien sv on kq.MaSV=sv.MaSV
	where kq.MaLHP=@malhp
END
--xem dssv theo tên
CREATEalter PROC xemDSDiemSVTheoTen
@malhp int,
@key nvarchar(100)
AS
BEGIN
	select sv.MaSV as[Mã sinh viên],sv.HoTen as[họ tên],sv.NgaySinh as[Ngày sinh],sv.GioiTinh as[Giới tính],
	ROUND(kq.DiemCC,2) as [Điểm CC], ROUND(kq.DiemTX,2) as [Điểm TX],ROUND(kq.DiemThi,2) as[Điểm thi],ROUND(kq.DiemHe10,2) as [Hệ 10],
	ROUND(kq.DiemHe4,2) as [Hệ 4],kq.DiemChu as[Điểm chữ]
	from KetQuaLopHP kq join SinhVien sv on kq.MaSV=sv.MaSV
	where kq.MaLHP=@malhp and sv.HoTen like '%'+@key+'%' 
END
go
--proc sửa điểm học phần sinh viên
CREATE PROC suaKQLHP
@masv int,
@malhp int,
@diemcc float,
@diemtx float,
@diemthi float
AS
BEGIN
	declare @diem10 float
	set @diem10=@diemcc*0.1+@diemtx*0.3+@diemthi*0.6
	if(@diemthi<4)
	BEGIN
		UPDATE KetQuaLopHP
		SET DiemCC=@diemcc,DiemTX=@diemtx,DiemThi=@diemthi,DiemHe10=@diemthi,DiemHe4=0,DiemChu='F'
		WHERE MaLHP=@malhp and MaSV=@masv
	END
	else
	BEGIN
		UPDATE KetQuaLopHP
		SET DiemCC=@diemcc,DiemTX=@diemtx,DiemThi=@diemthi,DiemHe10=@diem10,
		DiemHe4=dbo.change4(@diem10),DiemChu=dbo.changeW(dbo.change4(@diem10))
		WHERE MaLHP=@malhp and MaSV=@masv
	END
END
go
--cập nhập điểm vào bẩng tổng kết kỳ
CREATEalter PROC capnhatdiemvasotinchi
@mahk int,
@masv int
AS
BEGIN
	declare @stcdk int,@diemtbc float
	select @stcdk=SUM(hp.SoTC),@diemtbc=SUM(kq.DiemHe10*hp.SoTC)/SUM(hp.SoTC)
	from KetQuaLopHP kq join LopHP lhp on kq.MaLHP=lhp.MaLHP join HocPhan hp on lhp.MaHP=hp.MaHP
	where kq.MaSV=@masv and lhp.MaHK=@mahk

	declare @stcdat int
	select @stcdk=SUM(hp.SoTC)
	from KetQuaLopHP kq join LopHP lhp on kq.MaLHP=lhp.MaLHP join HocPhan hp on lhp.MaHP=hp.MaHP
	where kq.MaSV=@masv and lhp.MaHK=@mahk and kq.DiemHe10>=4

	update TongKetKy
	SET STCDKy=@stcdk,
		STCD=@stcdat,
		DiemTBC=@diemtbc,
		XepLoai=dbo.changeXL(@diemtbc)
	WHERE MaHK=@mahk and MaSV=@masv


	--cập nhật ở bảng sinh viên
	declare @tongtcdk int,@tongtcdat int,@tongdiemtbc float

	select @tongtcdk=SUM(temp.SoTC),@diemtbc=SUM(temp.diem10*temp.SoTC)/SUM(temp.SoTC)
	from(
	select max(kq.DiemHe10) as diem10,hp.SoTC
	from KetQuaLopHP kq join LopHP lhp on kq.MaLHP=lhp.MaLHP join HocPhan hp on lhp.MaHP=hp.MaHP
	where kq.MaSV=@masv
	group by hp.MaHP,hp.SoTC
	) as temp

	select @tongtcdat=SUM(temp.SoTC)
	from(
	select max(kq.DiemHe10) as diem10,hp.SoTC
	from KetQuaLopHP kq join LopHP lhp on kq.MaLHP=lhp.MaLHP join HocPhan hp on lhp.MaHP=hp.MaHP
	where kq.MaSV=@masv
	group by hp.MaHP,hp.SoTC
	) temp
	where temp.diem10>=4

	UPDATE SinhVien
	SET STCDKy=@tongtcdk,
		STCD=@tongtcdat,
		DiemTichLuy=@tongdiemtbc
	Where MaSV=@masv
	


END
go
--proc xem danh sách  kết quả sinh viên trong học kỳ
CREATE PROC xemKQHT
@maL int,
@mahk int
AS
BEGIN
	select DENSE_RANK() over (order by tk.DiemTBC DESC) as [Xếp Hạng], sv.MaSV as [Mã sinh viên], sv.HoTen as [Họ tên], sv.NgaySinh as[Ngày sinh],sv.GioiTinh as [Giới tính],
	tk.STCDKy as [STCĐK],tk.STCD as [STC đạt], tk.DiemTBC [Điểm TB],tk.XepLoai as [Xếp loại]
	from SinhVien sv join TongKetKy tk on sv.MaSV=tk.MaSV
	where sv.MaLop=@maL and tk.MaHK=@mahk
END

CREATE PROC doiMK
@acc nchar(