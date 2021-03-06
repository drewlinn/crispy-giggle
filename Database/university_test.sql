USE [university_test]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 6/13/2017 9:38:56 PM ******/
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
/****** Object:  Table [dbo].[courses_students]    Script Date: 6/13/2017 9:38:56 PM ******/
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
/****** Object:  Table [dbo].[departments]    Script Date: 6/13/2017 9:38:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments_courses]    Script Date: 6/13/2017 9:38:56 PM ******/
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
/****** Object:  Table [dbo].[departments_students]    Script Date: 6/13/2017 9:38:56 PM ******/
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
/****** Object:  Table [dbo].[students]    Script Date: 6/13/2017 9:38:56 PM ******/
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
SET IDENTITY_INSERT [dbo].[courses_students] ON 

INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (1, 19, 7)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (2, 20, 7)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (3, 24, 11)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (4, 25, 11)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (5, 26, 13)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (6, 31, 16)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (7, 32, 16)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (8, 33, 18)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (9, 37, 21)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (10, 39, 23)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (11, 40, 23)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (12, 41, 25)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (13, 44, 28)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (14, 46, 29)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (15, 48, 31)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (16, 49, 31)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (17, 50, 33)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (18, 53, 36)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (20, 56, 38)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (21, 58, 40)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (22, 59, 40)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (24, 61, 43)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (25, 64, 46)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (27, 67, 48)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (28, 69, 50)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (29, 70, 50)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (31, 72, 53)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (32, 75, 56)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (34, 78, 58)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (35, 80, 60)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (36, 81, 60)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (38, 83, 63)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (39, 86, 66)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (41, 89, 68)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (42, 91, 70)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (43, 92, 70)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (45, 94, 73)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (46, 97, 76)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (48, 100, 78)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (49, 102, 80)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (50, 103, 80)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (52, 105, 83)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (53, 108, 86)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (56, 113, 90)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (57, 114, 90)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (59, 116, 93)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (60, 119, 96)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (62, 122, 98)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (63, 124, 100)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (64, 125, 100)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (66, 127, 103)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (67, 130, 110)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (69, 133, 112)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (70, 135, 114)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (71, 136, 114)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (73, 138, 117)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (74, 145, 124)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (76, 148, 126)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (77, 150, 128)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (78, 151, 128)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (80, 153, 131)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (81, 160, 138)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (83, 163, 140)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (84, 165, 142)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (85, 166, 142)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (87, 168, 145)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (88, 176, 153)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (90, 179, 155)
INSERT [dbo].[courses_students] ([id], [students_id], [courses_id]) VALUES (55, 111, 88)
SET IDENTITY_INSERT [dbo].[courses_students] OFF
SET IDENTITY_INSERT [dbo].[departments_courses] ON 

INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (1, 10, 106)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (2, 10, 107)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (3, 14, 108)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (4, 15, 120)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (5, 15, 121)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (6, 21, 122)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (7, 22, 134)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (8, 22, 135)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (9, 28, 136)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (10, 29, 148)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (11, 29, 149)
INSERT [dbo].[departments_courses] ([id], [departments_id], [courses_id]) VALUES (13, 36, 151)
SET IDENTITY_INSERT [dbo].[departments_courses] OFF
SET IDENTITY_INSERT [dbo].[departments_students] ON 

INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (1, 19, 140)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (2, 19, 141)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (3, 20, 142)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (4, 26, 155)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (5, 26, 156)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (6, 27, 157)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (8, 34, 171)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (9, 34, 172)
INSERT [dbo].[departments_students] ([id], [departments_id], [students_id]) VALUES (10, 35, 173)
SET IDENTITY_INSERT [dbo].[departments_students] OFF
