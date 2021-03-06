USE [Test]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/1/2020 9:22:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
	[ProviderId] [int] NULL,
 CONSTRAINT [PK_Table_3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderItem]    Script Date: 11/1/2020 9:22:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Quantity] [decimal](18, 3) NULL,
	[Unit] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItem_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provider]    Script Date: 11/1/2020 9:22:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Table_2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (1, N'123654', CAST(N'2020-10-05T11:21:44.1500000' AS DateTime2), 1)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (2, N'123655', CAST(N'2020-10-05T12:21:44.1500000' AS DateTime2), 1)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (3, N'123656', CAST(N'2020-10-06T11:30:44.1500000' AS DateTime2), 2)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (4, N'123657', CAST(N'2020-10-06T11:40:44.1500000' AS DateTime2), 2)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (5, N'123658', CAST(N'2020-10-06T12:30:44.1500000' AS DateTime2), 3)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (6, N'123659', CAST(N'2020-10-06T13:00:44.1500000' AS DateTime2), 3)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (7, N'123660', CAST(N'2020-10-10T09:30:44.1500000' AS DateTime2), 4)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (8, N'123661', CAST(N'2020-10-07T10:30:44.1500000' AS DateTime2), 4)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (9, N'123662', CAST(N'2020-10-11T08:30:44.1500000' AS DateTime2), 5)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (10, N'123663', CAST(N'2020-10-10T15:30:44.1500000' AS DateTime2), 5)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (11, N'123664', CAST(N'2020-10-15T11:30:44.1500000' AS DateTime2), 6)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (12, N'123665', CAST(N'2020-10-01T14:30:44.1500000' AS DateTime2), 6)
INSERT [dbo].[Order] ([Id], [Number], [Date], [ProviderId]) VALUES (15, N'123444', CAST(N'2020-10-31T17:54:01.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderItem] ON 

INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (1, 1, N'bearing ', CAST(2.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (2, 1, N'machine oil', CAST(5.000 AS Decimal(18, 3)), N'liter')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (3, 1, N'Oil filter', CAST(1.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (4, 2, N'brake pad', CAST(4.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (5, 2, N'gasket', CAST(4.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (6, 3, N'timing chain', CAST(1.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (7, 4, N'timing belt', CAST(1.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (8, 5, N'windscreen', CAST(1.000 AS Decimal(18, 3)), N'piece')
INSERT [dbo].[OrderItem] ([Id], [OrderId], [Name], [Quantity], [Unit]) VALUES (9, 6, N'spare tire', CAST(4.000 AS Decimal(18, 3)), NULL)
SET IDENTITY_INSERT [dbo].[OrderItem] OFF
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([Id], [Name]) VALUES (1, N'AutoEuro')
INSERT [dbo].[Provider] ([Id], [Name]) VALUES (2, N'AutoDoc')
INSERT [dbo].[Provider] ([Id], [Name]) VALUES (3, N'AutoContinent')
INSERT [dbo].[Provider] ([Id], [Name]) VALUES (4, N'Alfa')
INSERT [dbo].[Provider] ([Id], [Name]) VALUES (5, N'Sigma')
INSERT [dbo].[Provider] ([Id], [Name]) VALUES (6, N'Exist')
SET IDENTITY_INSERT [dbo].[Provider] OFF
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Provider]
GO
ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Order]
GO
