USE [TaskDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/23/2023 11:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/23/2023 11:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 6/23/2023 11:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [nvarchar](max) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[AcquisitionDate] [datetime2](7) NOT NULL,
	[SerialNo] [nvarchar](max) NOT NULL,
	[Memo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeviceProperties]    Script Date: 6/23/2023 11:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeviceProperties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceID] [int] NOT NULL,
	[PropertyID] [int] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DeviceProperties] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Property]    Script Date: 6/23/2023 11:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PropertysCategories]    Script Date: 6/23/2023 11:48:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertysCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_PropertysCategories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230623005028_CreateDB', N'7.0.7')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (1, N'Laptop')
INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (2, N'Printer')
INSERT [dbo].[Category] ([ID], [CategoryName]) VALUES (3, N'Switch')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Device] ON 

INSERT [dbo].[Device] ([ID], [DeviceName], [CategoryID], [AcquisitionDate], [SerialNo], [Memo]) VALUES (34, N'lenovo i9', 1, CAST(N'2023-06-24T00:00:00.0000000' AS DateTime2), N'123', N'memo')
SET IDENTITY_INSERT [dbo].[Device] OFF
GO
SET IDENTITY_INSERT [dbo].[DeviceProperties] ON 

INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (58, 34, 1, N'core i9')
INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (59, 34, 2, N'123456')
INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (60, 34, 3, N'500GB')
INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (61, 34, 7, N'Abdullah')
INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (62, 34, 11, N'8GB')
INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (63, 34, 12, N'17')
INSERT [dbo].[DeviceProperties] ([ID], [DeviceID], [PropertyID], [Value]) VALUES (64, 34, 13, N'Lenovo')
SET IDENTITY_INSERT [dbo].[DeviceProperties] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([ID], [Description]) VALUES (1, N'Processor')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (2, N'IP Address')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (3, N'HD')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (4, N'Dimensions')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (5, N'MAC Address')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (6, N'Allow USB')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (7, N'Current User')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (8, N'Network Speed')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (9, N'Operating System')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (10, N'Ports')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (11, N'Ram')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (12, N'Display')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (13, N'Brand')
INSERT [dbo].[Property] ([ID], [Description]) VALUES (14, N' Is Color')
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
SET IDENTITY_INSERT [dbo].[PropertysCategories] ON 

INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (1, 1, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (2, 2, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (3, 3, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (4, 7, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (5, 11, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (7, 12, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (8, 13, 1)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (9, 2, 2)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (10, 13, 2)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (11, 14, 2)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (12, 10, 3)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (13, 2, 3)
INSERT [dbo].[PropertysCategories] ([ID], [PropertyID], [CategoryID]) VALUES (14, 13, 3)
SET IDENTITY_INSERT [dbo].[PropertysCategories] OFF
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Category_CategoryID]
GO
ALTER TABLE [dbo].[DeviceProperties]  WITH CHECK ADD  CONSTRAINT [FK_DeviceProperties_Device_DeviceID] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Device] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeviceProperties] CHECK CONSTRAINT [FK_DeviceProperties_Device_DeviceID]
GO
ALTER TABLE [dbo].[DeviceProperties]  WITH CHECK ADD  CONSTRAINT [FK_DeviceProperties_Property_PropertyID] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[Property] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeviceProperties] CHECK CONSTRAINT [FK_DeviceProperties_Property_PropertyID]
GO
ALTER TABLE [dbo].[PropertysCategories]  WITH CHECK ADD  CONSTRAINT [FK_PropertysCategories_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertysCategories] CHECK CONSTRAINT [FK_PropertysCategories_Category_CategoryID]
GO
ALTER TABLE [dbo].[PropertysCategories]  WITH CHECK ADD  CONSTRAINT [FK_PropertysCategories_Property_PropertyID] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[Property] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PropertysCategories] CHECK CONSTRAINT [FK_PropertysCategories_Property_PropertyID]
GO
