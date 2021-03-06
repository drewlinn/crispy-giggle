USE [university]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 6/13/2017 9:37:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[course_number] [varchar](255) NULL,
	[completion] [varchar](50) NULL,
	[grade] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[courses_students]    Script Date: 6/13/2017 9:37:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[students_id] [int] NULL,
	[courses_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments]    Script Date: 6/13/2017 9:37:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments_courses]    Script Date: 6/13/2017 9:37:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments_courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departments_id] [int] NULL,
	[courses_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments_students]    Script Date: 6/13/2017 9:37:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[departments_id] [int] NULL,
	[students_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 6/13/2017 9:37:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[enrollment] [date] NULL,
	[major] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[courses] ON 

INSERT [dbo].[courses] ([id], [name], [course_number], [completion], [grade]) VALUES (2, N'Sleepology', N'Sleepology 101', N'Nailed it', N'A')
INSERT [dbo].[courses] ([id], [name], [course_number], [completion], [grade]) VALUES (4, N'ago;hnoireha;gio', N'a;ogihsa;oerhg', N';oareihg;oeqh', N'A')
SET IDENTITY_INSERT [dbo].[courses] OFF
SET IDENTITY_INSERT [dbo].[courses_students] ON 

INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (1, 2, 2)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (2, 2, 2)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (3, 3, 2)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (4, 3, 2)
SET IDENTITY_INSERT [dbo].[courses_students] OFF
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [name], [enrollment], [major]) VALUES (2, N'asd', CAST(N'2017-06-13' AS Date), N'asd')
INSERT [dbo].[students] ([id], [name], [enrollment], [major]) VALUES (3, N'steven', CAST(N'2017-06-06' AS Date), N'sleep')
SET IDENTITY_INSERT [dbo].[students] OFF
