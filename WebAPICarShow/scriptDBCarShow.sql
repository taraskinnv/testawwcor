/****** Object:  Table [dbo].[Car]    Script Date: 19.05.2020 13:49:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_CarBrand] [int] NULL,
	[id_TypeBody] [int] NULL,
	[id_Engine] [int] NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarBrand]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarBrand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brand] [nvarchar](max) NULL,
	[id_ModelCar] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarOrder]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarOrder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_Car] [int] NULL,
	[id_Client] [int] NULL,
	[id_PaymentType] [int] NULL,
	[dateBuyCar] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Engine]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Engine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeEngine] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelCar]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelCar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[model] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTypes]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[paymentType] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeBody]    Script Date: 19.05.2020 13:49:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeBody](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[body] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([id], [id_CarBrand], [id_TypeBody], [id_Engine], [price]) VALUES (1, 1, 2, 1, 30000.0000)
INSERT [dbo].[Car] ([id], [id_CarBrand], [id_TypeBody], [id_Engine], [price]) VALUES (2, 2, 2, 2, 45000.0000)
INSERT [dbo].[Car] ([id], [id_CarBrand], [id_TypeBody], [id_Engine], [price]) VALUES (3, 3, 1, 1, 50000.0000)
SET IDENTITY_INSERT [dbo].[Car] OFF
SET IDENTITY_INSERT [dbo].[CarBrand] ON 

INSERT [dbo].[CarBrand] ([id], [brand], [id_ModelCar]) VALUES (1, N'BMW', 1)
INSERT [dbo].[CarBrand] ([id], [brand], [id_ModelCar]) VALUES (2, N'BMW', 2)
INSERT [dbo].[CarBrand] ([id], [brand], [id_ModelCar]) VALUES (3, N'Audi', 3)
INSERT [dbo].[CarBrand] ([id], [brand], [id_ModelCar]) VALUES (4, N'Audi', 4)
SET IDENTITY_INSERT [dbo].[CarBrand] OFF
SET IDENTITY_INSERT [dbo].[CarOrder] ON 

INSERT [dbo].[CarOrder] ([id], [id_Car], [id_Client], [id_PaymentType], [dateBuyCar]) VALUES (1, 1, 1, 1, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[CarOrder] ([id], [id_Car], [id_Client], [id_PaymentType], [dateBuyCar]) VALUES (3, 2, 2, 2, CAST(N'2020-02-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[CarOrder] OFF
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([id], [FIO], [Adress], [Phone]) VALUES (1, N'Ivanov', N'Dnipro', N'01')
INSERT [dbo].[Client] ([id], [FIO], [Adress], [Phone]) VALUES (2, N'Petrov', N'Kyiv', N'02')
SET IDENTITY_INSERT [dbo].[Client] OFF
SET IDENTITY_INSERT [dbo].[Engine] ON 

INSERT [dbo].[Engine] ([id], [typeEngine]) VALUES (1, N'Petrol')
INSERT [dbo].[Engine] ([id], [typeEngine]) VALUES (2, N'Diesel')
INSERT [dbo].[Engine] ([id], [typeEngine]) VALUES (3, N'Electric
')
SET IDENTITY_INSERT [dbo].[Engine] OFF
SET IDENTITY_INSERT [dbo].[ModelCar] ON 

INSERT [dbo].[ModelCar] ([id], [model]) VALUES (1, N'X5')
INSERT [dbo].[ModelCar] ([id], [model]) VALUES (2, N'X7')
INSERT [dbo].[ModelCar] ([id], [model]) VALUES (3, N'A6')
INSERT [dbo].[ModelCar] ([id], [model]) VALUES (4, N'A8')
SET IDENTITY_INSERT [dbo].[ModelCar] OFF
SET IDENTITY_INSERT [dbo].[PaymentTypes] ON 

INSERT [dbo].[PaymentTypes] ([id], [paymentType]) VALUES (1, N'cash')
INSERT [dbo].[PaymentTypes] ([id], [paymentType]) VALUES (2, N'card')
SET IDENTITY_INSERT [dbo].[PaymentTypes] OFF
SET IDENTITY_INSERT [dbo].[TypeBody] ON 

INSERT [dbo].[TypeBody] ([id], [body]) VALUES (1, N'sedan')
INSERT [dbo].[TypeBody] ([id], [body]) VALUES (2, N'Off-road Vehicle')
SET IDENTITY_INSERT [dbo].[TypeBody] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_principal_name]    Script Date: 19.05.2020 13:50:03 ******/
ALTER TABLE [dbo].[sysdiagrams] ADD  CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD FOREIGN KEY([id_CarBrand])
REFERENCES [dbo].[CarBrand] ([id])
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD FOREIGN KEY([id_Engine])
REFERENCES [dbo].[Engine] ([id])
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD FOREIGN KEY([id_TypeBody])
REFERENCES [dbo].[TypeBody] ([id])
GO
ALTER TABLE [dbo].[CarBrand]  WITH CHECK ADD FOREIGN KEY([id_ModelCar])
REFERENCES [dbo].[ModelCar] ([id])
GO
ALTER TABLE [dbo].[CarOrder]  WITH CHECK ADD FOREIGN KEY([id_Car])
REFERENCES [dbo].[Car] ([id])
GO
ALTER TABLE [dbo].[CarOrder]  WITH CHECK ADD FOREIGN KEY([id_Client])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[CarOrder]  WITH CHECK ADD FOREIGN KEY([id_PaymentType])
REFERENCES [dbo].[PaymentTypes] ([id])
GO
