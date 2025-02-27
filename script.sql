USE [CreditCardControl]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 01/07/2021 13:40:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[documento] [nvarchar](50) NOT NULL,
	[id_tarjeta] [bigint] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compra]    Script Date: 01/07/2021 13:40:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[id_detalle] [bigint] NULL,
 CONSTRAINT [PK_compra] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle]    Script Date: 01/07/2021 13:40:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NULL,
	[valor] [decimal](16, 2) NULL,
	[descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_detalle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pago]    Script Date: 01/07/2021 13:40:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pago](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[pagoMinimo] [decimal](16, 2) NULL,
	[pagoTotal] [decimal](16, 2) NULL,
 CONSTRAINT [PK_pago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarjeta]    Script Date: 01/07/2021 13:40:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarjeta](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[numeroTarjeta] [nvarchar](50) NOT NULL,
	[cupoDisponible] [decimal](16, 2) NOT NULL,
	[cupoAvance] [decimal](16, 2) NOT NULL,
	[fechaCorte] [datetime] NOT NULL,
	[fechaCobro] [datetime] NOT NULL,
	[id_compra] [bigint] NOT NULL,
	[id_pago] [bigint] NOT NULL,
 CONSTRAINT [PK_tarjeta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD  CONSTRAINT [FK_compra_detalle] FOREIGN KEY([id_detalle])
REFERENCES [dbo].[detalle] ([id])
GO
ALTER TABLE [dbo].[compra] CHECK CONSTRAINT [FK_compra_detalle]
GO
ALTER TABLE [dbo].[tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_tarjeta_compra] FOREIGN KEY([id_compra])
REFERENCES [dbo].[compra] ([id])
GO
ALTER TABLE [dbo].[tarjeta] CHECK CONSTRAINT [FK_tarjeta_compra]
GO
ALTER TABLE [dbo].[tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_tarjeta_pago] FOREIGN KEY([id_pago])
REFERENCES [dbo].[pago] ([id])
GO
ALTER TABLE [dbo].[tarjeta] CHECK CONSTRAINT [FK_tarjeta_pago]
GO
