USE [master]
GO
/****** Object:  Database [BookDb]    Script Date: 4/3/2023 11:40:56 AM ******/
CREATE DATABASE [BookDb]
GO
USE [BookDb]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 4/3/2023 11:40:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[author] [nvarchar](50) NOT NULL,
	[year] [int] NULL,
	[cover] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BookDb] SET  READ_WRITE 
GO

USE [BookDb]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (1, N'Nhà Giả Kim', N'Pauloo Coelho', 1988, N'img/dacnhantam.jpg')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (2, N'Truyện cổ tích', N'Vân Anh', 2012, N'img/truyencotich.webp')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (4, N'Bệnh dạ dày', N'NXB Hồng Đức', 2020, N'img/benhdaday.png')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (5, N'Gió lạnh đầu mùa', N'Thạch Lam', 2015, N'img/giolanhdaumua.jpg')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (7, N'2.0 Nha gia kim', N'Paulo Coelho', 2022, N'./img/nhagiakim.jpg')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (9, N'5.0 Nha gia kim', N'Paulo Coelho', 2022, N'./img/nhagiakim.jpg')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (10, N'22.0 Nha gia kim', N'Paulo Coelho', 2022, N'./img/nhagiakim.jpg')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (11, N'Hoàng Tử Bé', N'Nguyễn Thành Long', 2016, N'img/hoangtube.jpg')
GO
INSERT [dbo].[Book] ([id], [title], [author], [year], [cover]) VALUES (12, N'992.0 Nha gia kim', N'Paulo Coelho', 2022, N'./img/nhagiakim.jpg')
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
