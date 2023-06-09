USE [Shop]
GO
/****** Object:  Table [dbo].[chitietdonhang]    Script Date: 6/16/2023 10:43:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietdonhang](
	[madon] [int] NOT NULL,
	[maSanpham] [int] NOT NULL,
	[soluong] [int] NULL,
	[gia] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[madon] ASC,
	[maSanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donhang]    Script Date: 6/16/2023 10:43:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donhang](
	[madon] [int] IDENTITY(1,1) NOT NULL,
	[thanhtoan] [bit] NULL,
	[ngaydat] [date] NULL,
	[ngaygiao] [date] NULL,
	[makh] [int] NULL,
	[Tongtien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[madon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang]    Script Date: 6/16/2023 10:43:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang](
	[makh] [int] IDENTITY(1,1) NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[tendangnhap] [varchar](20) NULL,
	[matkhau] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[diachi] [nvarchar](100) NULL,
	[dienthoai] [varchar](15) NULL,
	[ngaysinh] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaiSanPham]    Script Date: 6/16/2023 10:43:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiSanPham](
	[maloai] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/16/2023 10:43:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[maSanpham] [int] IDENTITY(1,1) NOT NULL,
	[maloai] [int] NULL,
	[tensanPham] [nvarchar](100) NOT NULL,
	[HinhChinh] [varchar](50) NULL,
	[giaban] [decimal](18, 0) NULL,
	[ngaycapnhat] [smalldatetime] NULL,
	[SoLuongTon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maSanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/16/2023 10:43:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4176, 9, 1, CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4177, 9, 2, CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4178, 10, 1, CAST(20000 AS Decimal(18, 0)))
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4179, 9, 1, CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4181, 19, 1, CAST(100000 AS Decimal(18, 0)))
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4182, 9, 1, CAST(10000 AS Decimal(18, 0)))
INSERT [dbo].[chitietdonhang] ([madon], [maSanpham], [soluong], [gia]) VALUES (4183, 9, 1, CAST(10000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[donhang] ON 

INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4176, NULL, CAST(N'2023-05-29' AS Date), CAST(N'2023-05-01' AS Date), 2, 10000)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4177, NULL, CAST(N'2023-05-29' AS Date), CAST(N'2023-05-01' AS Date), 2, 20000)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4178, NULL, CAST(N'2023-06-01' AS Date), CAST(N'2023-05-29' AS Date), 2, 20000)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4179, NULL, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-05' AS Date), 2, 10000)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4180, NULL, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-11' AS Date), 2, 0)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4181, NULL, CAST(N'2023-06-01' AS Date), CAST(N'2023-06-03' AS Date), 2, 100000)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4182, NULL, CAST(N'2023-06-08' AS Date), CAST(N'2023-06-06' AS Date), 2, 10000)
INSERT [dbo].[donhang] ([madon], [thanhtoan], [ngaydat], [ngaygiao], [makh], [Tongtien]) VALUES (4183, NULL, CAST(N'2023-06-10' AS Date), CAST(N'2023-06-05' AS Date), 2, 10000)
SET IDENTITY_INSERT [dbo].[donhang] OFF
GO
SET IDENTITY_INSERT [dbo].[khachhang] ON 

INSERT [dbo].[khachhang] ([makh], [hoten], [tendangnhap], [matkhau], [email], [diachi], [dienthoai], [ngaysinh]) VALUES (1, N'Trương Thành Luân', N'luan2', N'luan123', N'luanlol232002@gmail.com', N'cong hoa', N'0962765844', CAST(N'2002-01-01' AS Date))
INSERT [dbo].[khachhang] ([makh], [hoten], [tendangnhap], [matkhau], [email], [diachi], [dienthoai], [ngaysinh]) VALUES (2, N'Trà My', N'My', N'my123', N'my@gmail.com', N'Tân Phú', N'bbbbb', CAST(N'2019-02-02' AS Date))
INSERT [dbo].[khachhang] ([makh], [hoten], [tendangnhap], [matkhau], [email], [diachi], [dienthoai], [ngaysinh]) VALUES (3, N'Ngọc Trà My', N'Myme', N'my123', NULL, NULL, NULL, CAST(N'2002-04-04' AS Date))
INSERT [dbo].[khachhang] ([makh], [hoten], [tendangnhap], [matkhau], [email], [diachi], [dienthoai], [ngaysinh]) VALUES (4, N'Nguyen Ngoc Tra My', N'My123', N'my123', NULL, NULL, NULL, CAST(N'2002-04-04' AS Date))
INSERT [dbo].[khachhang] ([makh], [hoten], [tendangnhap], [matkhau], [email], [diachi], [dienthoai], [ngaysinh]) VALUES (5, N'thang', N'thang', N'1', NULL, NULL, NULL, CAST(N'2002-10-10' AS Date))
INSERT [dbo].[khachhang] ([makh], [hoten], [tendangnhap], [matkhau], [email], [diachi], [dienthoai], [ngaysinh]) VALUES (6, N'TruongThanhLuan', N'luan456', N'luan456', NULL, NULL, NULL, CAST(N'2001-04-03' AS Date))
SET IDENTITY_INSERT [dbo].[khachhang] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiSanPham] ON 

INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (1, N'Lacato')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (2, N'Black')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (3, N'Nade')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (4, N'Kate')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (5, N'Naul')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (6, N'Myul')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (7, N'MyNaUl')
INSERT [dbo].[loaiSanPham] ([maloai], [tenloai]) VALUES (8, N'Laost')
SET IDENTITY_INSERT [dbo].[loaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (9, 5, N'TWEN', N'/Content/assets/img/1.jpg', CAST(10000 AS Decimal(18, 0)), CAST(N'2009-05-06T00:00:00' AS SmallDateTime), -49)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (10, 6, N'Tone', N'/Content/assets/img/2.jpg', CAST(20000 AS Decimal(18, 0)), CAST(N'2017-09-12T00:00:00' AS SmallDateTime), -21)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (11, 7, N'Ekkko', N'/Content/assets/img/3.jpg', CAST(70000 AS Decimal(18, 0)), CAST(N'2019-12-12T00:00:00' AS SmallDateTime), -11)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (12, 8, N'ashe', N'/Content/assets/img/4.jpg', CAST(80000 AS Decimal(18, 0)), CAST(N'2020-11-11T00:00:00' AS SmallDateTime), 0)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (18, NULL, N'LeeTan', N'/Content/assets/img/7.jpg', CAST(90000 AS Decimal(18, 0)), CAST(N'2002-01-02T11:00:00' AS SmallDateTime), 0)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (19, NULL, N'Myukl', N'/Content/assets/img/8.jpg', CAST(100000 AS Decimal(18, 0)), CAST(N'2019-01-01T00:00:00' AS SmallDateTime), -2)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (20, NULL, N'NULA', N'/Content/assets/img/2.jpg', CAST(40000 AS Decimal(18, 0)), CAST(N'2023-01-02T00:00:00' AS SmallDateTime), -1)
INSERT [dbo].[SanPham] ([maSanpham], [maloai], [tensanPham], [HinhChinh], [giaban], [ngaycapnhat], [SoLuongTon]) VALUES (22, NULL, N'Titan', N'/Content/assets/img/9.jpg', CAST(60000 AS Decimal(18, 0)), CAST(N'2002-01-02T11:00:00' AS SmallDateTime), 3)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
INSERT [dbo].[User] ([UserName], [Password]) VALUES (N'admin', N'admin')
GO
ALTER TABLE [dbo].[chitietdonhang]  WITH CHECK ADD FOREIGN KEY([madon])
REFERENCES [dbo].[donhang] ([madon])
GO
ALTER TABLE [dbo].[chitietdonhang]  WITH CHECK ADD FOREIGN KEY([maSanpham])
REFERENCES [dbo].[SanPham] ([maSanpham])
GO
ALTER TABLE [dbo].[donhang]  WITH CHECK ADD FOREIGN KEY([makh])
REFERENCES [dbo].[khachhang] ([makh])
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([maloai])
REFERENCES [dbo].[loaiSanPham] ([maloai])
GO
