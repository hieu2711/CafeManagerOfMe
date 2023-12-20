CREATE DATABASE QuanLyQuanCafe
Go

--SanPham
--LoaiSanPham
--KhuyenMai
--ThongTinBan
--TaiKhoan
--NhanVien
--KhachHang
--KhachHangThanThiet
--HoaDon
--ChiTietHoaDon

Use QuanLyQuanCafe
Go

CREATE TABLE LoaiSanPham
(
	LoaiSanPhamID INT IDENTITY PRIMARY KEY,
	LoaiSanPham NVARCHAR(100)
)
Go

CREATE TABLE KhuyenMai
(
	KhuyenMaiID INT IDENTITY PRIMARY KEY,
	PhanTram FLOAT NOT NULL,
	NgayBatDau DATE,
	NgayKetThuc DATE
)
Go

CREATE TABLE SanPham
(
	SanPhamID INT IDENTITY PRIMARY KEY,
	TenSanPham NVARCHAR(100) NOT NULL,
	DonViTinh NVARCHAR(20) NOT NULL,
	DonGia FLOAT NOT NULL,
	HinhAnh NVARCHAR(1000),
	ID_LoaiSanPham INT NOT NULL,
	ID_KhuyenMai INT NOT NULL

	FOREIGN KEY (ID_LoaiSanPham) REFERENCES dbo.LoaiSanPham(LoaiSanPhamID),
	FOREIGN KEY (ID_KhuyenMai) REFERENCES dbo.KhuyenMai(KhuyenMaiID)
)
Go

CREATE TABLE ThongTinBan
(
	BanID INT IDENTITY PRIMARY KEY,
	SoBan INT NOT NULL,
	TrangThai NVARCHAR(100) DEFAULT N'Trống' --TRỐNG || CÓ NGƯỜI
)
Go

CREATE TABLE NhanVien
(
	NhanVienID INT IDENTITY PRIMARY KEY,
	HoVaTen NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	SoDienThoai NVARCHAR(15) NOT NULL,
	NgayVaoLam DATE NOT NULL,
	ChucVu INT NOT NULL DEFAULT 0 --1: admin || 0: NhanVien
	--ChucVu NVARCHAR(50) NOT NULL
)
Go

CREATE TABLE TaiKhoan 
(
	Username NVARCHAR(100) PRIMARY KEY,
	PassWord NVARCHAR(1000) NOT NULL,
	ID_NhanVien INT NOT NULL,
	ChucVu INT NOT NULL DEFAULT 0 --1: admin || 0: NhanVien

	--FOREIGN KEY (ID_NhanVien) REFERENCES dbo.NhanVien(NhanVienID)
)
Go

CREATE TABLE KhachHang
(
	KhachHangID INT IDENTITY PRIMARY KEY,
	HoVaTen NVARCHAR(50) NOT NULL,
	SoDienThoai NVARCHAR(15) NOT NULL,
	DiemTichLuy INT NOT NULL
)
Go

CREATE TABLE KhachHangThanThiet
(
	KhachHangID INT IDENTITY PRIMARY KEY,
	MucGiamGia FLOAT NOT NULL,
	ID_KhachHang INT NOT NULL,

	FOREIGN KEY (ID_KhachHang) REFERENCES dbo.KhachHang(KhachHangID)
)
Go

CREATE TABLE HoaDon
(
	HoaDonID INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE NOT NULL,
	SoBanDaDung INT NOT NULL,
	ID_KhachHang INT NOT NULL,
	ID_NhanVien INT NOT NULL,
	TrangThai INT NOT NULL DEFAULT 0 --Đã thanh toan || Chua thanh toán

	FOREIGN KEY (SoBanDaDung) REFERENCES dbo.ThongTinBan(BanID),
	FOREIGN KEY (ID_KhachHang) REFERENCES dbo.KhachHang(KhachHangID),
	FOREIGN KEY (ID_NhanVien) REFERENCES dbo.NhanVien(NhanVienID)
)
Go

CREATE TABLE ChiTietHoaDon
(
	ChiTietHoaDonID INT IDENTITY PRIMARY KEY,
	ID_HoaDon INT NOT NULL,
	ID_SanPham INT NOT NULL,
	TongSanPham INT NOT NULL DEFAULT 0

	FOREIGN KEY (ID_HoaDon) REFERENCES dbo.HoaDon(HoaDonID),
	FOREIGN KEY (ID_SanPham) REFERENCES dbo.SanPham(SanPhamID)
)
Drop Table ChiTietHoaDon
Go
Alter Table KhachHangThanThiet
IDENTITY_INSERT KhachHangThanThiet OFF

Insert into TaiKhoan(
Username ,
PassWord ,
ID_NhanVien,
ChucVu
)
values (N'hieu', '1',0, 1)

Set IDENTITY_INSERT SanPham ON
Insert into SanPham(
SanPhamID,
TenSanPham ,
DonViTinh,
DonGia,
HinhAnh,
ID_LoaiSanPham,
ID_KhuyenMai
)
values (01,N'Cafe Đá','Ly',15000,'IMG1',01,01);
Set IDENTITY_INSERT SanPham OFF

Set IDENTITY_INSERT LoaiSanPham ON
Insert into LoaiSanPham(
LoaiSanPhamID,
LoaiSanPham
)
values (1,'Cafe');
Set IDENTITY_INSERT LoaiSanPham OFF


Set IDENTITY_INSERT KhuyenMai ON
Insert into KhuyenMai(
KhuyenMaiID,
NgayBatDau,
NgayKetThuc,
PhanTram
)
values (2,'2023-02-10','2022-02-15',20);
Set IDENTITY_INSERT KhuyenMai OFF

Set IDENTITY_INSERT ThongTinBan ON
Insert into ThongTinBan(
BanID,
SoBan,
TrangThai
)
values (1,1,'Empty');

Insert into ThongTinBan(
BanID,
SoBan,
TrangThai
)
values (11,11,'Full');
Set IDENTITY_INSERT ThongTinBan OFF

create PROC USP_Login
@username nvarchar(100), @password nvarchar(100)
AS
Begin
Select * from TaiKhoan Where Username = @username AND PassWord = @password
End
Go

create PROC USP_GetTableList
AS
Select * from ThongTinBan
Go
exec USP_GetTableList

create PROC USP_GetFoodList
AS
Select * from SanPham
Go
exec USP_GetFoodList


create PROC USP_GetCatogoryList
AS
Select * from LoaiSanPham
Go
exec USP_GetCatogoryList

Select * from SanPham where ID_LoaiSanPham = 1

create PROC USP_GetNhanVienList
AS
Select * from NhanVien
Go
exec USP_GetNhanVienList

Insert into HoaDon(
HoaDonID,
DateCheckIn,
DateCheckOut,
SoBanDaDung,
ID_KhachHang,
ID_NhanVien,
TrangThai
)
values (1,'2002-02-10','2002-02-10',1,1,1,0);

Set IDENTITY_INSERT ChiTietHoaDon OFF
Set IDENTITY_INSERT ChiTietHoaDon ON
Insert into ChiTietHoaDon(
ChiTietHoaDonID,
ID_HoaDon,
ID_SanPham,
TongSanPham
)
values (4,3,6,8);

Insert into NhanVien(
NhanVienID,
HoVaTen,
NgaySinh,
GioiTinh,
SoDienThoai,
NgayVaoLam,
ChucVu
)
values (1,'Trần Văn A','2002-02-10','Nam',123,'2023-02-10',0);

Insert into KhachHang(
KhachHangID,
HoVaTen,
SoDienThoai,
DiemTichLuy
)

	create PROC USP_InsertBillInfo
	@idbill INT,@idfood INT,@count INT
	AS
	BEGIN
	Insert ChiTietHoaDon(ChiTietHoaDonID,ID_SanPham,TongSanPham)
	VALUES (@idbill,@idfood,@count)
	END
	Go
	EXEC USP_InsertBillInfo
	Select Max(HoaDonID) From HoaDon



values (1,'Lê thị A','012',1000);

Insert into KhachHangThanThiet(
KhachHangID,
MucGiamGia,
ID_KhachHang
)
values (11,11,'Full');

Select * from HoaDon where SoBanDaDung = 1 AND TrangThai = 0
Select * from ChiTietHoaDon where ID_HoaDon = 1

Select s.TenSanPham,c.TongSanPham,s.DonGia,(c.TongSanPham * s.DonGia) as "Thành tiền"
from ChiTietHoaDon as c,HoaDon as h,SanPham as s
where c.ID_SanPham = s.SanPhamID and h.HoaDonID = c.ID_HoaDon and h.SoBanDaDung = 3

Select s.TenSanPham,c.TongSanPham,s.DonGia,(c.TongSanPham * s.DonGia) as "Thành tiền"
from ChiTietHoaDon as c,HoaDon as h,SanPham as s
where c.ID_SanPham = s.SanPhamID and h.HoaDonID = c.ChiTietHoaDonID and h.SoBanDaDung = 3

Select * from ChiTietHoaDon
Select * from HoaDon
Select SoBan from ThongTinBan

	Alter PROC USP_InsertBillInfo
	@idbill INT,@idfood INT,@count INT
	AS
	BEGIN
	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	Select @isExitsBillInfo = ChiTietHoaDonID,@foodCount = b.TongSanPham
	From ChiTietHoaDon as b
	where ID_HoaDon = @idbill AND ID_SanPham = @idfood
	if(@isExitsBillInfo > 0)
	BEGIN
	DECLARE @newcount INT = @foodCount + @count
	if( @newcount > 0)
	Update ChiTietHoaDon set TongSanPham = @foodCount + @count where ID_SanPham = @idfood
	else
	Delete ChiTietHoaDon Where ID_HoaDon = @idbill and ID_SanPham = @idfood
	end
	else
	Begin 
	Insert ChiTietHoaDon(ID_HoaDon,ID_SanPham,TongSanPham)
	VALUES (@idbill,@idfood,@count)
	END
	end
	go

Create Trigger UTG_UpdateBillInfo
On dbo.ChiTietHoaDon For Insert,Update
As
Begin 
Declare @idbill INT
Select @idbill = ID_HoaDon from inserted
Declare @idtable INT
Select @idtable = SoBanDaDung From HoaDon Where HoaDonID = @idbill and TrangThai = 0
Update ThongTinBan Set TrangThai ='Full' Where BanID = @idtable
END
Go

Alter Trigger UTG_UpdateBill
On dbo.HoaDon For Update
As
Begin 
Declare @idbill INT
Select @idbill = HoaDonID from inserted
Declare @idtable INT
Select @idtable = SoBanDaDung From HoaDon Where HoaDonID = @idbill
Declare @count INT = 0
Select @count = COUNT(*) From HoaDon Where SoBanDaDung = @idtable and TrangThai = 0
if(@count = 0)
UPDATE ThongTinBan SET TrangThai ='Empty' where BanID =@idtable
END
Go
select * from HoaDon
select * from ThongTinBan
delete from HoaDon
delete from ChiTietHoaDon

create proc UpdateBill
@idTable INT,
@discount INT,
@totalPrice float
AS
BEGIN
UPDATE dbo.HoaDon
SET discount = @discount, totalPrice = @totalPrice
where SoBanDaDung = @idTable
END
Go
EXEC UpdateBill @idTable = 2, @discount = 10, @totalPrice = 300 
Alter PROC USP_GetListBillByDate1
@checkIn date,
@checkOut date,
@discount int
AS
BEGIN
	SELECT SoBanDaDung AS N'Tên Bàn', DateCheckIn AS N'Ngày vào', DateCheckOut AS N'Ngày ra', discount AS N'Giảm giá'
	FROM HoaDon 
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut  AND TrangThai = 1
END
GO
Exec USP_GetListBillByDate1 @checkIn ='2023/03/02' ,@checkOut ='2023/03/09', @discount = 20

Select * from HoaDon
select * from ThongTinBan
Select * from SanPham
Select * from ChitietHoaDon

Select a.HoaDonID,b.ChiTietHoaDonID , a.SoBanDaDung , a.discount, b.TongSanPham ,SUM(c.DonGia * b.TongSanPham) as TotalPrice
from HoaDon as a, ChiTietHoaDon as b , SanPham as c
where a.HoaDonID = b.ID_HoaDon and b.ID_SanPham = c.ID_LoaiSanPham and a.TrangThai = 1
Group by a.HoaDonID , a.SoBanDaDung , a.discount, b.TongSanPham ,c.SanPhamID,b.ChiTietHoaDonID 

delete ChiTietHoaDon
delete HoaDon

Select * from ChiTietHoaDon
Select * from HoaDon
Select NhanVienID,HoVaTen from NhanVien
Select s.TenSanPham,c.TongSanPham,s.DonGia,(c.TongSanPham * s.DonGia) as TotalPrice from ChiTietHoaDon as c,HoaDon as h,SanPham as s where c.ID_SanPham = s.SanPhamID and h.HoaDonID = c.ID_HoaDon and b.TrangThai = 0 and h.SoBanDaDung = " + id

Select* from SanPham 

Select s.TenSanPham,c.TongSanPham,s.DonGia,(c.TongSanPham * s.DonGia) as TotalPrice
from ChiTietHoaDon as c,HoaDon as h,SanPham as s 
where c.ID_SanPham = s.SanPhamID and h.HoaDonID = c.ID_HoaDon and h.TrangThai = 0 and h.SoBanDaDung = 3
Select * from HoaDon

ALTER TABLE HoaDon

ADD totalPrice float

Select TenHienThi,Username,ChucVu from TaiKhoan
SET IDENTITY_INSERT SanPham ON; 

INSERT INTO SanPham (SanPhamID,TenSanPham,DonViTinh,DonGia,ID_KhuyenMai,ID_LoaiSanPham)
VALUES (15,'Stavanger','Ly', 15,1,2);

Alter Table ChiTietHoaDon
Alter Column ID_HoaDon INT NOT NULL

Select * from SanPham where TenSanPham = '7 Up'
Select * from SanPham where SanPhamID = 2

EXEC USP_GetCatogoryList

Select* from SanPham where ID_LoaiSanPham = 1

Select * from ChiTietHoaDon

Alter PROC USP_InsertBill2
@idTable INT,
@discount INT,
@totalPrice float
AS
BEGIN
INSERT HoaDon
(
DateCheckIn,
DateCheckOut,
SoBanDaDung,
TrangThai,
discount,
totalPrice
)
VALUES 
(GETDATE(),
GETDATE(),
@idTable,
0,
@discount,
@totalPrice
)
END
Go
Exec USP_InsertBill2 @idTable = 2, @discount = 10,@totalPrice = 1000

	create PROC USP_InsertBillInfo
	@idbill INT,@idfood INT,@count INT
	AS
	BEGIN
	Insert ChiTietHoaDon(ChiTietHoaDonID,ID_SanPham,TongSanPham)
	VALUES (@idbill,@idfood,@count)
	END
	Go
	EXEC USP_InsertBillInfo
	Select Max(HoaDonID) From HoaDon

Alter PROC USP_InsertBillInfo
@idbill INT,@idfood INT,@count INT
AS
BEGIN
DECLARE @isExitsBillInfo INT
DECLARE @foodCount INT = 1
Select @isExitsBillInfo = ChiTietHoaDonID,@foodCount = b.TongSanPham
From ChiTietHoaDon as b
where ID_HoaDon = @idbill AND ID_SanPham = @idfood
if(@isExitsBillInfo > 0)
BEGIN
DECLARE @newcount INT = @foodCount + @count
if( @newcount > 0)
Update ChiTietHoaDon set TongSanPham = @foodCount + @count where ID_SanPham = @idfood
else
Delete ChiTietHoaDon Where ChiTietHoaDonID = @idbill and ID_SanPham = @idfood
end
else
Begin 
Insert ChiTietHoaDon(ChiTietHoaDonID,ID_SanPham,TongSanPham)
VALUES (@idbill,@idfood,@count)
END
end
go

select * from TaiKhoan

Alter Table dbo.ChiTietHoaDon
Alter Column ID_HoaDon INT NOT NULL;

go

Delete from dbo.HoaDon
Delete from dbo.ChiTietHoaDon

Select nv.HoVaTen, nv.NhanVienID, acc.ID_NhanVien
from NhanVien as nv,TaiKhoan as acc
where ID_NhanVien = NhanVienID

Create PROC USP_InsertBillInfo2
@idbill INT,@idfood INT,@count INT
AS
BEGIN
DECLARE @isExitsBillInfo INT
DECLARE @foodCount INT = 1
Select @isExitsBillInfo = ChiTietHoaDonID,@foodCount = b.TongSanPham
From ChiTietHoaDon as b
where ID_HoaDon = @idbill AND ID_SanPham = @idfood
if(@isExitsBillInfo > 0)
BEGIN
DECLARE @newcount INT = @foodCount + @count
if( @newcount > 0)
Update ChiTietHoaDon set TongSanPham = @foodCount + @count where ID_SanPham = @idfood
else
Delete ChiTietHoaDon Where ChiTietHoaDonID = @idbill and ID_SanPham = @idfood
end
else
Begin 
Insert ChiTietHoaDon(ChiTietHoaDonID,ID_SanPham,TongSanPham)
VALUES (@idbill,@idfood,@count)
END
end
go
delete  UpdateBill
create proc UpdateBill
@idTable INT,
@discount INT,
@totalPrice float
AS
BEGIN
UPDATE dbo.HoaDon
SET discount = @discount
SET totalPrice = @totalPrice
where SoBanDaDung = @idTable
END
Go
Select * from HoaDon

create proc UpdateBill2
@idTable INT,
@discount INT,
@totalPrice float
AS
BEGIN
UPDATE dbo.HoaDon
SET discount = @discount
SET totalPrice = @totalPrice
where SoBanDaDung = @idTable
END
Go

Select 
from HoaDon as a,ChiTietHoaDon as b
select * from HoaDon
Select * from ChiTietHoaDon

Create PROC USP_ThongKe
@checkIn date, @checkOut date
AS
BEGIN
	Select SoBanDaDung as N'Bàn số', DateCheckIn as N'Ngày vào', DateCheckOut as N'Ngày ra', discount as N'Giảm giá', totalPrice as N'Tổng tiền'
from HoaDon
where DateCheckIn >= @checkout and DateCheckOut <= @checkOut and TrangThai = 1
END
GO

Select SoBanDaDung as N'Tên Bàn', DateCheckIn as N'Ngày vào', DateCheckOut as N'Ngày ra', discount as N'Giảm giá', totalPrice as N'Tổng tiền'
from HoaDon
where DateCheckIn >= @checkout and DateCheckOut ><= @checkOut and TrangThai = 1