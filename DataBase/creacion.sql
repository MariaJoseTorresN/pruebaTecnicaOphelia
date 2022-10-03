/****** Object:  Table [dbo].[Cliente]    Script Date: 2/10/2022 10:38:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cliente_id] [int] NOT NULL,
	[cedula] [varchar](10) NOT NULL,
	[nombre] [varchar](128) NOT NULL,
	[apellido] [varchar](128) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[celular] [varchar](10) NOT NULL,
	[correo] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[cliente_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 2/10/2022 10:38:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[compra_id] [int] NOT NULL,
	[factura_id] [int] NOT NULL,
	[producto_id] [int] NOT NULL,
	[precio] [numeric](10, 2) NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[compra_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 2/10/2022 10:38:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[factura_id] [int] NOT NULL,
	[cliente_id] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[precioTotal] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[factura_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/10/2022 10:38:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[producto_id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [numeric](10, 2) NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[producto_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Factura] FOREIGN KEY([factura_id])
REFERENCES [dbo].[Factura] ([factura_id])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Factura]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Producto] FOREIGN KEY([producto_id])
REFERENCES [dbo].[Producto] ([producto_id])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Producto]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([cliente_id])
REFERENCES [dbo].[Cliente] ([cliente_id])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
