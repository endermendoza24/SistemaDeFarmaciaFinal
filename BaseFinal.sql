USE [master]
GO
/****** Object:  Database [DbFarmacia]    Script Date: 22/7/2021 22:11:59 ******/
CREATE DATABASE [DbFarmacia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbFarmacia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DbFarmacia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbFarmacia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DbFarmacia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DbFarmacia] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbFarmacia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbFarmacia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbFarmacia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbFarmacia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbFarmacia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbFarmacia] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbFarmacia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbFarmacia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbFarmacia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbFarmacia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbFarmacia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbFarmacia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbFarmacia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbFarmacia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbFarmacia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbFarmacia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbFarmacia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbFarmacia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbFarmacia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbFarmacia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbFarmacia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbFarmacia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbFarmacia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbFarmacia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbFarmacia] SET  MULTI_USER 
GO
ALTER DATABASE [DbFarmacia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbFarmacia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbFarmacia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbFarmacia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbFarmacia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbFarmacia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DbFarmacia', N'ON'
GO
ALTER DATABASE [DbFarmacia] SET QUERY_STORE = OFF
GO
USE [DbFarmacia]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/7/2021 22:12:01 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria_Medicamento]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria_Medicamento](
	[id_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Categoria] [varchar](50) NOT NULL,
	[descripcion_Categoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria_Medicamento] PRIMARY KEY CLUSTERED 
(
	[id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[cod_Compras] [int] IDENTITY(1,1) NOT NULL,
	[fecha_Compra] [datetime] NOT NULL,
	[Iva] [float] NOT NULL,
	[subtotal] [float] NOT NULL,
	[total] [float] NOT NULL,
	[Id_Laboratorio] [int] NOT NULL,
	[Id_Personal] [int] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[cod_Compras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_Compras]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_Compras](
	[id_DetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [float] NOT NULL,
	[precio] [float] NOT NULL,
	[costo] [float] NOT NULL,
	[descuento] [float] NOT NULL,
	[cod_Compras] [int] NOT NULL,
 CONSTRAINT [PK_Detalle_Compras] PRIMARY KEY CLUSTERED 
(
	[id_DetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_Venta]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_Venta](
	[cod_DetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [varchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[descuento] [float] NOT NULL,
	[cod_Ventas] [int] NOT NULL,
 CONSTRAINT [PK_detalle_Venta] PRIMARY KEY CLUSTERED 
(
	[cod_DetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[idInventario] [int] IDENTITY(1,1) NOT NULL,
	[fechaEntradaInventario] [date] NULL,
	[nombreComercial] [varchar](100) NOT NULL,
	[StockInicial] [int] NOT NULL,
	[Entradas] [int] NOT NULL,
	[Salidas] [int] NOT NULL,
	[StockActual] [int] NOT NULL,
	[PrecioPreventa] [float] NOT NULL,
	[CostoPreventa] [float] NOT NULL,
	[idPresentacionMed] [int] NOT NULL,
	[idLaboratorio] [int] NOT NULL,
	[idCompra] [int] NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[idInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Laboratorio]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laboratorio](
	[id_laboratorio] [int] IDENTITY(1,1) NOT NULL,
	[nombre_Laboratorio] [varchar](50) NOT NULL,
	[telefono_Laboratorio] [varchar](20) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[email_Lab] [varchar](50) NOT NULL,
	[politicasDeVencimiento] [varchar](300) NOT NULL,
 CONSTRAINT [PK_Laboratorio] PRIMARY KEY CLUSTERED 
(
	[id_laboratorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicamentos]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicamentos](
	[cod_Medicamentos] [int] IDENTITY(1,1) NOT NULL,
	[nombreGenerico] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[viaAdministracion] [varchar](50) NOT NULL,
	[id_Categoria] [int] NOT NULL,
	[id_Inventario] [int] NOT NULL,
 CONSTRAINT [PK_Medicamentos] PRIMARY KEY CLUSTERED 
(
	[cod_Medicamentos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[id_Personal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[primerApellido] [varchar](50) NOT NULL,
	[segundoApellido] [varchar](50) NULL,
	[direccion] [varchar](50) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[id_Personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentacion_Medicamento]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentacion_Medicamento](
	[id_PresentacionMed] [int] IDENTITY(1,1) NOT NULL,
	[unidadEnvasado] [varchar](50) NOT NULL,
	[formaPresentacion] [varchar](50) NOT NULL,
	[concentracion] [varchar](50) NULL,
	[unidadMedidaPresentacion] [varchar](50) NOT NULL,
	[Unidades] [varchar](50) NOT NULL,
	[subUnidades] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Presentacion_Medicamento] PRIMARY KEY CLUSTERED 
(
	[id_PresentacionMed] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[cod_Ventas] [int] IDENTITY(1,1) NOT NULL,
	[fecha_Ventas] [datetime] NOT NULL,
	[subtotal] [float] NOT NULL,
	[iva] [float] NOT NULL,
	[total] [float] NOT NULL,
	[id_Personal] [int] NOT NULL,
	[id_Inventario] [int] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[cod_Ventas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 22/7/2021 22:12:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 22/7/2021 22:12:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 22/7/2021 22:12:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 22/7/2021 22:12:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 22/7/2021 22:12:02 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 22/7/2021 22:12:02 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 22/7/2021 22:12:02 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Laboratorio] FOREIGN KEY([Id_Laboratorio])
REFERENCES [dbo].[Laboratorio] ([id_laboratorio])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Laboratorio]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Personal] FOREIGN KEY([Id_Personal])
REFERENCES [dbo].[Personal] ([id_Personal])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Personal]
GO
ALTER TABLE [dbo].[detalle_Compras]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Compras_Compras] FOREIGN KEY([cod_Compras])
REFERENCES [dbo].[Compras] ([cod_Compras])
GO
ALTER TABLE [dbo].[detalle_Compras] CHECK CONSTRAINT [FK_Detalle_Compras_Compras]
GO
ALTER TABLE [dbo].[detalle_Venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_Venta_Ventas] FOREIGN KEY([cod_Ventas])
REFERENCES [dbo].[Ventas] ([cod_Ventas])
GO
ALTER TABLE [dbo].[detalle_Venta] CHECK CONSTRAINT [FK_detalle_Venta_Ventas]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Compras] FOREIGN KEY([idCompra])
REFERENCES [dbo].[Compras] ([cod_Compras])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Compras]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Laboratorio] FOREIGN KEY([idLaboratorio])
REFERENCES [dbo].[Laboratorio] ([id_laboratorio])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Laboratorio]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Presentacion_Medicamento] FOREIGN KEY([idPresentacionMed])
REFERENCES [dbo].[Presentacion_Medicamento] ([id_PresentacionMed])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Presentacion_Medicamento]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_Categoria_Medicamento] FOREIGN KEY([id_Categoria])
REFERENCES [dbo].[Categoria_Medicamento] ([id_Categoria])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_Categoria_Medicamento]
GO
ALTER TABLE [dbo].[Medicamentos]  WITH CHECK ADD  CONSTRAINT [FK_Medicamentos_Inventario] FOREIGN KEY([id_Inventario])
REFERENCES [dbo].[Inventario] ([idInventario])
GO
ALTER TABLE [dbo].[Medicamentos] CHECK CONSTRAINT [FK_Medicamentos_Inventario]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Inventario] FOREIGN KEY([id_Inventario])
REFERENCES [dbo].[Inventario] ([idInventario])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Inventario]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Personal] FOREIGN KEY([id_Personal])
REFERENCES [dbo].[Personal] ([id_Personal])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Personal]
GO
/****** Object:  StoredProcedure [dbo].[CategoriaGuardar]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CategoriaGuardar](
@codigo int = null,
@nombre varchar(50),
@descripcion varchar(50)
)
AS
BEGIN
if not exists (select id_Categoria from Categoria_Medicamento where id_Categoria = @codigo)
BEGIN
INSERT INTO Categoria_Medicamento(nombre_Categoria, descripcion_Categoria) VALUES(@nombre, @descripcion)
END
ELSE
BEGIN
UPDATE Categoria_Medicamento SET nombre_Categoria = @nombre, descripcion_Categoria = @descripcion WHERE id_Categoria = @codigo
END
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[EliminarCategoria](
@id_Categoria int
)

as
begin

delete from Categoria_Medicamento   where id_Categoria = @id_Categoria
end

GO
/****** Object:  StoredProcedure [dbo].[EliminarCompras]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EliminarCompras](
@cod_Compra int
)

as
begin

delete from Compras   where cod_Compras = @cod_Compra
end

GO
/****** Object:  StoredProcedure [dbo].[EliminarInventario]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminarInventario](
@idInventario int
)

as
begin

delete from Inventario   where id_Inventario = @idInventario
end

GO
/****** Object:  StoredProcedure [dbo].[EliminarLaboratorio]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminarLaboratorio](
@idLaboratorio int
)

as
begin

delete from Laboratorio   where id_laboratorio = @idLaboratorio
end

GO
/****** Object:  StoredProcedure [dbo].[EliminarMedicamento]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminarMedicamento](
@codMedicamentos int
)

as
begin

delete from Medicamentos   where cod_Medicamentos = @codMedicamentos
end

GO
/****** Object:  StoredProcedure [dbo].[EliminarPersonal]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[EliminarPersonal](
  @idPersonal int
  )
  as
  begin
  delete from Personal where id_Personal = @idPersonal
  end
GO
/****** Object:  StoredProcedure [dbo].[EliminarPresentacionMed]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EliminarPresentacionMed](
@idPresentacion int
)

as
begin

delete from Presentacion_Medicamento where id_PresentacionMed = @idPresentacion
end
GO
/****** Object:  StoredProcedure [dbo].[InventarioGuardar]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[InventarioGuardar](
  @codigo int,
  @fecha date,
  @nombreComercial varchar(50),
  @stockInicial int,
  @entradas int,
  @salidas int,
  @stockActual int,
  @precio float,
  @costo float,
  @idPresentacion int,
  @idLaboratorio int,
  @idCompra int
  )
  as
  begin
    if not exists (select idInventario from Inventario where idInventario= @codigo)
	begin
	insert into Inventario(fechaEntradaInventario, nombreComercial, StockInicial,
	Entradas, Salidas, StockActual, PrecioPreventa, CostoPreventa, idPresentacionMed,
	idLaboratorio, idCompra) values( @fecha, @nombreComercial, @stockInicial,
	@entradas, @salidas, @stockActual, @precio, @costo, @idPresentacion, @idLaboratorio, @idCompra)
	end
	else
	begin
	update Inventario set fechaEntradaInventario = @fecha, nombreComercial = @nombreComercial,
	StockInicial = @stockInicial, Entradas = @entradas, Salidas = @salidas, StockActual = @stockActual,
	PrecioPreventa = @precio, CostoPreventa = @costo, idPresentacionMed = @idPresentacion,
	idLaboratorio = @idLaboratorio, idCompra = @idCompra where idInventario = @codigo
	end
	end
GO
/****** Object:  StoredProcedure [dbo].[InventarioxCodigo]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InventarioxCodigo](
  @idInventario int
  )
  as
  begin
  select * from Inventario where idInventario = @idInventario
  end
GO
/****** Object:  StoredProcedure [dbo].[LaboratorioGuardar]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[LaboratorioGuardar](
  @codigo int,
  @nombre varchar(50),
  @telefono varchar(50),
  @direccion varchar(50),
  @email varchar(50),
  @politicas varchar(300)
  )
  as
  begin
  if not exists (select id_laboratorio from Laboratorio where id_laboratorio = @codigo)
  begin
  insert into Laboratorio( nombre_Laboratorio, telefono_Laboratorio,
  direccion, email_Lab, politicasDeVencimiento) values(@nombre, 
  @telefono, @direccion, @email, @politicas)
  end
  else
  begin
  update Laboratorio set nombre_Laboratorio = @nombre, telefono_Laboratorio = @telefono,
  direccion = @direccion, email_Lab = @email, politicasDeVencimiento = @politicas where id_laboratorio = @codigo
  end
  end
GO
/****** Object:  StoredProcedure [dbo].[LaboratorioxCodigo]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LaboratorioxCodigo](
  @idLaboratorio int
  )
  as
  begin
  select * from Laboratorio where id_laboratorio = @idLaboratorio
  end
GO
/****** Object:  StoredProcedure [dbo].[MedicamentosGuardar]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MedicamentosGuardar](
  @codigo int,
  @nombreGenerico varchar(50),
  @estado varchar(50),
  @viaAdministracion varchar(50),
  @idCategoria int,
  @idInventario int
  )
  as
  begin
  if not exists (select cod_Medicamentos from Medicamentos where cod_Medicamentos = @codigo)
  begin
  insert into Medicamentos(nombreGenerico, estado, viaAdministracion, id_Categoria, id_Inventario)
  values(@nombreGenerico, @estado, @viaAdministracion, @idCategoria, @idInventario)
  end
  begin
  update Medicamentos set nombreGenerico = @nombreGenerico, estado = @estado, viaAdministracion = @viaAdministracion,
  id_Categoria = @idCategoria, id_Inventario = @idInventario where cod_Medicamentos = @codigo
  end
  end
GO
/****** Object:  StoredProcedure [dbo].[MedicamentoxCodigo]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[MedicamentoxCodigo](
  @codMedicamento int
  )
  as
  begin
  select * from Medicamentos where cod_Medicamentos = @codMedicamento
  end
GO
/****** Object:  StoredProcedure [dbo].[PersonalGuardar]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE proc [dbo].[PersonalGuardar](
  @codigo int,
  @nombre varchar(50),
  @primerApellido varchar(50),
  @segundoApellido varchar(50),
  @direccion varchar(100),
  @telefono varchar(30),
  @email varchar(50)
  )
  as
  begin
  if not exists (select id_Personal from Personal where id_Personal = @codigo)
  begin
  insert into Personal( nombre, primerApellido, segundoApellido,
  direccion, telefono, email) values( @nombre, @primerApellido, @segundoApellido,
  @direccion, @telefono, @email)
  end
  else
  begin
  update Personal set nombre = @nombre, primerApellido = @primerApellido, segundoApellido = @segundoApellido,
  direccion = @direccion, telefono = @telefono, email = @email where id_Personal = @codigo
  end
  end
GO
/****** Object:  StoredProcedure [dbo].[PersonalxCodigo]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PersonalxCodigo](
  @idPersonal int
  )
  as
  begin
  select * from Personal where id_Personal = @idPersonal
  end
GO
/****** Object:  StoredProcedure [dbo].[PresentacionGuardar]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE proc [dbo].[PresentacionGuardar](
	@codigo int,
	@unidadEnvasado varchar(50),
	@formaPresentacion varchar(50),
	@concentracion varchar(50),
	@unidadMedida varchar(50),
	@unidades varchar(50),
	@subUnidades varchar(50)
	)
	as
	begin 
	if not exists (select id_PresentacionMed from Presentacion_Medicamento where id_PresentacionMed = @codigo)
	begin
	insert into Presentacion_Medicamento( unidadEnvasado, formaPresentacion,
	concentracion, unidadMedidaPresentacion, Unidades, subUnidades) values(@unidadEnvasado,
	@formaPresentacion, @concentracion, @unidadMedida, @unidades, @subUnidades)
	end
	begin
	update Presentacion_Medicamento set unidadEnvasado = @unidadEnvasado, formaPresentacion = @formaPresentacion,
	concentracion = @concentracion, unidadMedidaPresentacion = @unidadMedida, Unidades = @unidades,
	subUnidades = @subUnidades where id_PresentacionMed = @codigo
	end
	end
GO
/****** Object:  StoredProcedure [dbo].[PresentacionxCodigo]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PresentacionxCodigo](
	@idpresentacion int
	)
	as
	begin
	select * from Presentacion_Medicamento where id_PresentacionMed = @idpresentacion
	end
GO
/****** Object:  StoredProcedure [dbo].[spCategoriaxCodigo]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[spCategoriaxCodigo](
  @idCategoria int
  )
  as
  begin 
  -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
  select * from Categoria_Medicamento where id_Categoria = @idCategoria;
  end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarInventario]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spMostrarInventario]
as
begin
select * from Inventario
end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarMedicamentos]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMostrarMedicamentos]
  as
  begin
  select * from Medicamentos
  end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarPresentaciones]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMostrarPresentaciones]
  as
  begin
  select * from Presentacion_Medicamento
  end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarTodasLasCategorias]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[spMostrarTodasLasCategorias]
   as
   begin
  select * from Categoria_Medicamento
  end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarTodoElPersonal]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[spMostrarTodoElPersonal]
  as
  begin
  select * from Personal
  end
GO
/****** Object:  StoredProcedure [dbo].[spMostrarTodoLosLaboratorios]    Script Date: 22/7/2021 22:12:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[spMostrarTodoLosLaboratorios]
  as
  begin
  select * from Laboratorio
  end
GO
USE [master]
GO
ALTER DATABASE [DbFarmacia] SET  READ_WRITE 
GO
