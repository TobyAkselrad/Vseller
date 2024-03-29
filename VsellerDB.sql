USE [master]
GO
/****** Object:  Database [VsellerDB]    Script Date: 3/12/2019 13:09:36 ******/
CREATE DATABASE [VsellerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VsellerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VsellerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VsellerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VsellerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VsellerDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VsellerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VsellerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VsellerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VsellerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VsellerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VsellerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [VsellerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VsellerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VsellerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VsellerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VsellerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VsellerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VsellerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VsellerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VsellerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VsellerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VsellerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VsellerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VsellerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VsellerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VsellerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VsellerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VsellerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VsellerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [VsellerDB] SET  MULTI_USER 
GO
ALTER DATABASE [VsellerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VsellerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VsellerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VsellerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VsellerDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'VsellerDB', N'ON'
GO
ALTER DATABASE [VsellerDB] SET QUERY_STORE = OFF
GO
USE [VsellerDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [VsellerDB]
GO
/****** Object:  User [alumno]    Script Date: 3/12/2019 13:09:36 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[DatosProducto]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosProducto](
	[fkProducto] [int] NOT NULL,
	[fkDetalle] [int] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[idDetalle] [int] IDENTITY(1,1) NOT NULL,
	[Descripción] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[fkTipo] [int] NOT NULL,
	[Foto] [varchar](500) NOT NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Precio] [int] NOT NULL,
	[fkUsuario] [varchar](50) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Imagen] [varchar](200) NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Nombre] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Admin] [bit] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 1, N'40')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 2, N'Nike')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 3, N'Negro')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 4, N'Cuero')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 5, N'Air Force 90')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 6, N'Unisex')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (2, 8, N'Nuevo')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 1, N'M')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 2, N'Nike')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 3, N'Blanco')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 4, N'Algodon')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 5, N'Nike Air')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 6, N'Masc')
INSERT [dbo].[DatosProducto] ([fkProducto], [fkDetalle], [Descripcion]) VALUES (3, 8, N'Nuevo')
SET IDENTITY_INSERT [dbo].[Detalle] ON 

INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (1, N'Talle')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (2, N'Marca')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (3, N'Color')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (4, N'Material')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (5, N'Modelo')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (6, N'Genero')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (7, N'Cortes')
INSERT [dbo].[Detalle] ([idDetalle], [Descripción]) VALUES (8, N'Condicion')
SET IDENTITY_INSERT [dbo].[Detalle] OFF
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([idProducto], [fkTipo], [Foto], [Nombre], [Precio], [fkUsuario]) VALUES (2, 1, N'remera.jpg', N'Nike Air Force', 6500, N'lucalong54')
INSERT [dbo].[Producto] ([idProducto], [fkTipo], [Foto], [Nombre], [Precio], [fkUsuario]) VALUES (3, 2, N'NikeAir.jpg', N'Buzo Nike Air', 5000, N'lucalong54')
SET IDENTITY_INSERT [dbo].[Producto] OFF
SET IDENTITY_INSERT [dbo].[Tipo] ON 

INSERT [dbo].[Tipo] ([idTipo], [Descripcion], [Imagen]) VALUES (1, N'Zapatillas', N'zapatilla1.jpg')
INSERT [dbo].[Tipo] ([idTipo], [Descripcion], [Imagen]) VALUES (2, N'Superior', N'buzo.jpg')
INSERT [dbo].[Tipo] ([idTipo], [Descripcion], [Imagen]) VALUES (3, N'Inferior', N'pantalon.jpg')
SET IDENTITY_INSERT [dbo].[Tipo] OFF
INSERT [dbo].[Usuario] ([Nombre], [Username], [Password], [Admin]) VALUES (N'Admin', N'Admin', N'toby', 1)
INSERT [dbo].[Usuario] ([Nombre], [Username], [Password], [Admin]) VALUES (N'Leo', N'LeoK200', N'v†0ì èøx®(ZÊX7‡', 0)
INSERT [dbo].[Usuario] ([Nombre], [Username], [Password], [Admin]) VALUES (N'Luca', N'lucalong54', N'ÒxÎÆ|W¸;ßÊ(‰mä‰', 1)
INSERT [dbo].[Usuario] ([Nombre], [Username], [Password], [Admin]) VALUES (N'Nahuel', N'nahuisuv', N'mochila', 0)
ALTER TABLE [dbo].[DatosProducto]  WITH CHECK ADD  CONSTRAINT [FK_DatosProducto_Detalle] FOREIGN KEY([fkDetalle])
REFERENCES [dbo].[Detalle] ([idDetalle])
GO
ALTER TABLE [dbo].[DatosProducto] CHECK CONSTRAINT [FK_DatosProducto_Detalle]
GO
ALTER TABLE [dbo].[DatosProducto]  WITH CHECK ADD  CONSTRAINT [FK_DatosProducto_Producto] FOREIGN KEY([fkProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DatosProducto] CHECK CONSTRAINT [FK_DatosProducto_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tipo] FOREIGN KEY([fkTipo])
REFERENCES [dbo].[Tipo] ([idTipo])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tipo]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Usuario] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[Usuario] ([Username])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[spCargarDatosProducto]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCargarDatosProducto]
@Produc int,
@Detalle int,
@Desc varchar(500)

AS
BEGIN

	insert into DatosProducto values(@Produc,@Detalle,@Desc)
END
GO
/****** Object:  StoredProcedure [dbo].[spCargarDetalle]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCargarDetalle]
@Desc varchar(500)

AS
BEGIN

	insert into Detalle values(@Desc)
END
GO
/****** Object:  StoredProcedure [dbo].[spCargarProducto]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCargarProducto]
@Tipo int,
@Foto varchar(500),
@Nombre varchar(500),
@Usuario varchar(50),
@Precio int

AS
BEGIN

	insert into Producto values(@Tipo,@Foto,@Nombre,@Precio, @Usuario)
END
GO
/****** Object:  StoredProcedure [dbo].[spCargarTipo]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCargarTipo]
@Desc varchar(500),
@img varchar(200)
AS
BEGIN

	insert into Tipo values(@Desc, @img)
END
GO
/****** Object:  StoredProcedure [dbo].[spCargarUsuario]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCargarUsuario]
@nom varchar(50),
@user varchar(50),
@pass varchar(50),
@adm bit

AS
BEGIN

	insert into Usuario values(@nom,@user, @pass ,@adm)
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarDatos]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarDatos]
@id int
AS
BEGIN
delete from DatosProducto where fkProducto = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spEliminarProducto]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEliminarProducto]
@id int

AS
BEGIN

delete from Producto where idProducto = @id

END
GO
/****** Object:  StoredProcedure [dbo].[spSelectUsuario]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSelectUsuario]
@username varchar(200),
@password varchar(200)

AS
BEGIN

select * from Usuario where Username = @username and Password = @password

END
GO
/****** Object:  StoredProcedure [dbo].[spspEditarProducto]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spspEditarProducto]
@id int,
@Tipo int,
@Foto varchar(500),
@Nombre varchar(500),
@Precio int,
@Usuario varchar(500)
AS
BEGIN
	update Producto set  fkTipo=@Tipo,Foto=@Foto,Nombre=@Nombre,Precio=@Precio,fkUsuario=@Usuario where idProducto = @id
END
GO
/****** Object:  StoredProcedure [dbo].[spTraerAdmin]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spTraerAdmin]
@username varchar(200),
@password varchar(200)
AS
BEGIN

select * from Usuario where Username = @username and Password = @password

END
GO
/****** Object:  StoredProcedure [dbo].[spTraerDatosPorId]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spTraerDatosPorId]
@idProd int

AS
BEGIN

select * from DatosProducto where DatosProducto.fkProducto = @idProd
END
GO
/****** Object:  StoredProcedure [dbo].[spTraerDetalles]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTraerDetalles]
	
AS
BEGIN

	SELECT * from Detalle
END
GO
/****** Object:  StoredProcedure [dbo].[spTraerDetallesxId>]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTraerDetallesxId>]
@id int	
AS
BEGIN
	select * from Detalle where idDetalle=@id
END
GO
/****** Object:  StoredProcedure [dbo].[spTraerProductoPorId]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spTraerProductoPorId]
@id int

AS
BEGIN

select * from producto where idProducto=@id
END
GO
/****** Object:  StoredProcedure [dbo].[spTraerProductoPorTipo]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spTraerProductoPorTipo] 
@tipo int
AS
BEGIN
select * from Producto where fkTipo = @tipo
END
GO
/****** Object:  StoredProcedure [dbo].[spTraerTipos]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTraerTipos]

AS
BEGIN
select * from Tipo

END
GO
/****** Object:  StoredProcedure [dbo].[spValidarUsuario]    Script Date: 3/12/2019 13:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spValidarUsuario]
@user varchar(200)
AS
BEGIN
select * from Usuario where Username = @user
END
GO
USE [master]
GO
ALTER DATABASE [VsellerDB] SET  READ_WRITE 
GO
