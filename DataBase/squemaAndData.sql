/****** Object:  Table [dbo].[Clientes]    Script Date: 7/10/2022 1:19:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[clienteId] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nvarchar](10) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[fechaNacimiento] [datetime2](7) NOT NULL,
	[celular] [nvarchar](10) NOT NULL,
	[correo] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[clienteId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 7/10/2022 1:19:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[compraId] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioPagado] [int] NOT NULL,
	[productoId] [int] NOT NULL,
	[facturaId] [int] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[compraId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 7/10/2022 1:19:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[facturaId] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[precioTotal] [int] NOT NULL,
	[clienteId] [int] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[facturaId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 7/10/2022 1:19:44 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[productoId] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](128) NOT NULL,
	[precio] [real] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[productoId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (1, N'1234567890', N'Jhon', N'Doe', CAST(N'1980-08-17T00:00:00.0000000' AS DateTime2), N'3010183650', N'jhon.doe@gmail.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (2, N'1092837465', N'Jane', N'Huston', CAST(N'1995-05-14T00:00:00.0000000' AS DateTime2), N'3009847353', N'jane.huston@gmail.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (3, N'3398327073', N'Mona', N'Thams', CAST(N'1951-06-04T00:00:00.0000000' AS DateTime2), N'3229553068', N'kemlyn2@google.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (4, N'5154036421', N'Bernardine', N'Lansdale', CAST(N'1989-08-19T00:00:00.0000000' AS DateTime2), N'3009816027', N'blansdale4@chronoengine.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (10, N'8728686047', N'Delmer', N'Capun', CAST(N'1944-08-23T10:20:41.8730000' AS DateTime2), N'3004430062', N'dcapun5@purevolume.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (11, N'799323930', N'Missy', N'Yarnold', CAST(N'1958-07-10T00:00:00.0000000' AS DateTime2), N'3006849416', N'myarnold0@abc.net.au')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (12, N'723086623', N'Evita', N'Cosbey', CAST(N'1980-07-30T00:00:00.0000000' AS DateTime2), N'3003379258', N'ecosbey1@mac.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (13, N'658847225', N'Nerti', N'Matelaitis', CAST(N'1942-07-26T13:12:19.8860000' AS DateTime2), N'4856999067', N'nmatelaitis7@tiny.cc')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (15, N'725116931', N'Marlyn', N'Wilden', CAST(N'1965-02-08T00:00:00.0000000' AS DateTime2), N'3676539883', N'mwilden3@dmoz.org')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (16, N'63485931', N'Omar', N'Santiago', CAST(N'2001-10-09T15:34:32.2060000' AS DateTime2), N'3004523678', N'omar.santiago@mail.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (17, N'string', N'string', N'string', CAST(N'2022-10-06T22:37:54.1180000' AS DateTime2), N'string', N'string')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (18, N'1234321', N'w', N'w', CAST(N'2022-09-08T00:00:00.0000000' AS DateTime2), N'3009876543', N'a')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (19, N'6348932703', N'Juana', N'Martin', CAST(N'1993-01-25T00:00:00.0000000' AS DateTime2), N'3103258943', N'juana.matin@gmail.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (20, N'7229954013', N'Raul', N'Alvarez', CAST(N'1982-10-10T00:00:00.0000000' AS DateTime2), N'3018475839', N'raul.alvarez@hotmail.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (21, N'8671952603', N'Sara', N'Ospina', CAST(N'1965-01-23T00:00:00.0000000' AS DateTime2), N'3115792949', N'sara.ospina@yahoo.com')
GO
INSERT [dbo].[Clientes] ([clienteId], [cedula], [nombre], [apellido], [fechaNacimiento], [celular], [correo]) VALUES (22, N'1093275036', N'Manuel', N'Morales', CAST(N'2000-06-15T00:00:00.0000000' AS DateTime2), N'3026581070', N'manuel.morales@hotmail.com')
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Compras] ON 
GO
INSERT [dbo].[Compras] ([compraId], [cantidad], [precioPagado], [productoId], [facturaId]) VALUES (1, 1, 47, 1, 1)
GO
INSERT [dbo].[Compras] ([compraId], [cantidad], [precioPagado], [productoId], [facturaId]) VALUES (2, 1, 120000, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Compras] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturas] ON 
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (1, CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), 200000, 1)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (2, CAST(N'2000-04-01T00:00:00.0000000' AS DateTime2), 247000, 2)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (4, CAST(N'2006-03-06T00:00:00.0000000' AS DateTime2), 650000, 1)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (5, CAST(N'2022-09-06T22:37:54.1180000' AS DateTime2), 10000, 17)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (14, CAST(N'2000-01-01T17:01:40.8030000' AS DateTime2), 168000, 16)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (15, CAST(N'2000-04-03T17:01:40.8030000' AS DateTime2), 168000, 19)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (16, CAST(N'2002-10-07T17:35:08.9010000' AS DateTime2), 10000, 1)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (17, CAST(N'2022-09-29T00:00:00.0000000' AS DateTime2), 200000, 2)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (18, CAST(N'2022-09-27T00:00:00.0000000' AS DateTime2), 300000, 2)
GO
INSERT [dbo].[Facturas] ([facturaId], [fecha], [precioTotal], [clienteId]) VALUES (19, CAST(N'2022-09-25T00:00:00.0000000' AS DateTime2), 50000, 4)
GO
SET IDENTITY_INSERT [dbo].[Facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (1, N'Undertale', 120000, 50)
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (2, N'FIFA23', 280000, 100)
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (3, N'FarCry6', 200000, 78)
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (6, N'SonicMania', 48000, 50)
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (7, N'ItFollowsYou', 114760, 5)
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (8, N'Bibots', 51300, 3)
GO
INSERT [dbo].[Productos] ([productoId], [nombre], [precio], [cantidad]) VALUES (9, N'a', 10, 4)
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Facturas_facturaId] FOREIGN KEY([facturaId])
REFERENCES [dbo].[Facturas] ([facturaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Facturas_facturaId]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Productos_productoId] FOREIGN KEY([productoId])
REFERENCES [dbo].[Productos] ([productoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Productos_productoId]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes_clienteId] FOREIGN KEY([clienteId])
REFERENCES [dbo].[Clientes] ([clienteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes_clienteId]
GO
