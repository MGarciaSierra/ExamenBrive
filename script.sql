USE [master]
GO
/****** Object:  Database [BriveSucursal]    Script Date: 22/05/2022 06:23:51 p. m. ******/
CREATE DATABASE [BriveSucursal]

GO
ALTER DATABASE [BriveSucursal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BriveSucursal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BriveSucursal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BriveSucursal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BriveSucursal] SET ARITHABORT OFF 
GO
ALTER DATABASE [BriveSucursal] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BriveSucursal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BriveSucursal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BriveSucursal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BriveSucursal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BriveSucursal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BriveSucursal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BriveSucursal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BriveSucursal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BriveSucursal] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BriveSucursal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BriveSucursal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BriveSucursal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BriveSucursal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BriveSucursal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BriveSucursal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BriveSucursal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BriveSucursal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BriveSucursal] SET  MULTI_USER 
GO
ALTER DATABASE [BriveSucursal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BriveSucursal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BriveSucursal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BriveSucursal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BriveSucursal] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BriveSucursal]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NULL,
	[IdSucursal] [int] NULL,
	[Cantidad] [int] NULL,
	[IdProducto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MetodoPago]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MetodoPago](
	[IdMetodoPago] [int] IDENTITY(1,1) NOT NULL,
	[Metodo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMetodoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[Precio] [money] NULL,
	[Imagen] [varbinary](max) NULL,
	[Stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SucursalProducto]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SucursalProducto](
	[IdSucursalProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursal] [int] NULL,
	[IdProducto] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdSucursalProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[Nombre] [varchar](100) NULL,
	[ApellidoPaterno] [varchar](100) NULL,
	[ApellidoMaterno] [varchar](100) NULL,
	[FechaNacimiento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[Total] [money] NULL,
	[IdMetodoPago] [int] NULL,
	[FechaVenta] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([IdSucursal])
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[SucursalProducto]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[SucursalProducto]  WITH CHECK ADD FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([IdSucursal])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdMetodoPago])
REFERENCES [dbo].[MetodoPago] ([IdMetodoPago])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
/****** Object:  StoredProcedure [dbo].[AgregarDetalleventa]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarDetalleventa]

@IdVenta INT,
@IdSucursal INT,
@Cantidad INT,
@IdProducto INT
AS

INSERT INTO [DetalleVenta]
           (IdVenta,
            [IdSucursal]
           ,[Cantidad]
           ,[IdProducto])
     VALUES
           (@IdVenta,
           @IdSucursal
           ,@Cantidad
           ,@IdProducto)

GO
/****** Object:  StoredProcedure [dbo].[AgregarVenta]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarVenta]


@IdUsuario INT,
@Total MONEY,
@IdMetodoPago INT,
@IdVenta INT OUTPUT



AS 

INSERT INTO Venta(IdUsuario,Total,IdMetodoPago,FechaVenta)


VALUES (@IdUsuario,@Total,@IdMetodoPago,GETDATE())


SET  @IdVenta = @@IDENTITY 
GO
/****** Object:  StoredProcedure [dbo].[DetalleVentaIdVenta]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DetalleVentaIdVenta]

@IdVenta INT

AS

SELECT IdDetalleVenta
      ,DetalleVenta.IdVenta
      ,IdSucursal
      ,Cantidad
      ,DetalleVenta.IdProducto
	  ,Producto.Nombre
	  ,Producto.Precio
	  ,Producto.Descripcion
	  ,Producto.Imagen
	  ,Venta.Total
  FROM DetalleVenta

  INNER JOIN Producto ON Producto.IdProducto = DetalleVenta.IdProducto
   INNER JOIN Venta ON Venta.IdVenta = DetalleVenta.IdVenta

WHERE DetalleVenta.IdVenta = @IdVenta
GO
/****** Object:  StoredProcedure [dbo].[ProductoActualizar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductoActualizar]

@IdProducto INT,
@Nombre VARCHAR (100),
@Descripcion VARCHAR (100),
@Precio MONEY,
@Imagen VARBINARY(MAX),
@Stock INT


AS

UPDATE Producto SET Nombre = @Nombre,
                    Descripcion = @Descripcion,
					Precio =@Precio,
					Imagen = @Imagen,
					Stock = @Stock

					WHERE IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[ProductoAgregar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductoAgregar]

 @Nombre VARCHAR (100),
 @Descripcion VARCHAR (100),
 @Precio MONEY,
 @Imagen VARBINARY (MAX),
 @Stock INT

 AS


 INSERT INTO Producto(Nombre,Descripcion,Precio,Imagen,Stock)

 VALUES (@Nombre,@Descripcion,@Precio,@Imagen,@Stock)


GO
/****** Object:  StoredProcedure [dbo].[ProductoEliminar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductoEliminar]

@IdProducto INT

AS


DELETE FROM Producto

WHERE IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[ProductoMostrarTodo]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ProductoMostrarTodo]


 AS

 SELECT [IdProducto]
      ,[Nombre]
      ,[Descripcion]
      ,[Precio]
      ,[Imagen]
      ,[Stock]
  FROM Producto

GO
/****** Object:  StoredProcedure [dbo].[ProductoMostrarUno]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[ProductoMostrarUno]

 @IdProducto INT

 AS

 SELECT [IdProducto]
      ,[Nombre]
      ,[Descripcion]
      ,[Precio]
      ,[Imagen]
      ,[Stock]
  FROM Producto

  WHERE IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[SucursalActualizar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SucursalActualizar]

@IdSucursal INT,
@Nombre VARCHAR(100),
@Direccion VARCHAR(100),
@Telefono VARCHAR(20)

AS

UPDATE Sucursal SET Nombre = @Nombre,Direccion = @Direccion,Telefono = @Telefono


WHERE IdSucursal = @IdSucursal
GO
/****** Object:  StoredProcedure [dbo].[SucursalAgregar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SucursalAgregar]

@Nombre VARCHAR(100),
@Direccion VARCHAR(100),
@Telefono VARCHAR(20)

AS

INSERT INTO Sucursal(Nombre,Direccion,Telefono)

    VALUES(@Nombre,@Direccion,@Telefono)

GO
/****** Object:  StoredProcedure [dbo].[SucursalEliminar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SucursalEliminar]

@IdSucursal INT

AS

    DELETE FROM Sucursal

	WHERE IdSucursal = @IdSucursal
GO
/****** Object:  StoredProcedure [dbo].[SucursalMostrar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SucursalMostrar]


AS

SELECT IdSucursal
      ,Nombre
      ,Direccion
      ,Telefono
  FROM Sucursal
GO
/****** Object:  StoredProcedure [dbo].[SucursalMostrarUno]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SucursalMostrarUno]

@IdSucursal INT

AS

SELECT IdSucursal
      ,Nombre
      ,Direccion
      ,Telefono
  FROM Sucursal

  WHERE IdSucursal = @IdSucursal
GO
/****** Object:  StoredProcedure [dbo].[UsuarioActualizar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioActualizar]

@IdUsuario INT,
@UserName VARCHAR (100),
@Nombre VARCHAR (100),
@ApellidoPaterno VARCHAR (100),
@ApellidoMaterno VARCHAR (100),
@FechaNacimiento VARCHAR(100)


AS


UPDATE Usuario SET UserName = @UserName,
                   Nombre = @Nombre,
				   ApellidoPaterno = @ApellidoPaterno,
				   ApellidoMaterno = @ApellidoMaterno,
				   FechaNacimiento = CONVERT (DATETIME,@FechaNacimiento,105)



				   WHERE IdUsuario = @IdUsuario

GO
/****** Object:  StoredProcedure [dbo].[UsuarioAdd]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioAdd]

 @UserName VARCHAR(100),
 @Nombre VARCHAR(100),
 @ApellidoPaterno VARCHAR(100),
 @ApellidoMaterno VARCHAR(100),
 @FechaNaciento VARCHAR(100)

 AS

 INSERT INTO Usuario(Username,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento)


 VALUES (@UserName,@Nombre,@ApellidoPaterno,@ApellidoMaterno,CONVERT(DATE,@FechaNaciento,105))

GO
/****** Object:  StoredProcedure [dbo].[UsuarioAgregar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[UsuarioAgregar]

 @UserName VARCHAR(100),
 @Nombre VARCHAR(100),
 @ApellidoPaterno VARCHAR(100),
 @ApellidoMaterno VARCHAR(100),
 @FechaNacimiento VARCHAR(100)

 AS

 INSERT INTO Usuario(Username,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento)


 VALUES (@UserName,@Nombre,@ApellidoPaterno,@ApellidoMaterno,CONVERT(datetime,@FechaNacimiento,103))

GO
/****** Object:  StoredProcedure [dbo].[UsuarioEliminar]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioEliminar]

@IdUsuario INT

AS

DELETE FROM Usuario 


 WHERE IdUsuario = @IdUsuario

GO
/****** Object:  StoredProcedure [dbo].[UsuarioMostrarTodo]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioMostrarTodo]

AS

SELECT [IdUsuario]
      ,[UserName]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,CONVERT(date,FechaNacimiento,105)
  FROM [Usuario]

GO
/****** Object:  StoredProcedure [dbo].[UsuarioMostrarUno]    Script Date: 22/05/2022 06:23:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioMostrarUno]

@IdUsuario INT 

AS

SELECT [IdUsuario]
      ,[UserName]
      ,[Nombre]
      ,ApellidoPaterno
      ,[ApellidoMaterno]
      ,[FechaNacimiento]
  FROM [Usuario]

  WHERE IdUsuario = @IdUsuario
GO
USE [master]
GO
ALTER DATABASE [BriveSucursal] SET  READ_WRITE 
GO
