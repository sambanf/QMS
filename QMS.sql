USE [master]
GO
/****** Object:  Database [QMS]    Script Date: 26/12/2018 11:02:01 ******/
CREATE DATABASE [QMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QMS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QMS] SET  MULTI_USER 
GO
ALTER DATABASE [QMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QMS] SET QUERY_STORE = OFF
GO
USE [QMS]
GO
/****** Object:  Table [dbo].[QDetail]    Script Date: 26/12/2018 11:02:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QDetail](
	[q_id] [int] IDENTITY(1,1) NOT NULL,
	[q_qh_id] [int] NOT NULL,
	[q_no] [varchar](12) NOT NULL,
	[q_question] [varchar](100) NOT NULL,
 CONSTRAINT [PK_QDetail] PRIMARY KEY CLUSTERED 
(
	[q_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QHeader]    Script Date: 26/12/2018 11:02:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QHeader](
	[q_id] [int] IDENTITY(1,1) NOT NULL,
	[q_code] [varchar](10) NOT NULL,
	[q_name] [varchar](50) NOT NULL,
	[q_type] [varchar](20) NOT NULL,
 CONSTRAINT [PK_QHeader] PRIMARY KEY CLUSTERED 
(
	[q_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[QDetail]  WITH CHECK ADD  CONSTRAINT [FK_QDetail_QHeader] FOREIGN KEY([q_qh_id])
REFERENCES [dbo].[QHeader] ([q_id])
GO
ALTER TABLE [dbo].[QDetail] CHECK CONSTRAINT [FK_QDetail_QHeader]
GO
USE [master]
GO
ALTER DATABASE [QMS] SET  READ_WRITE 
GO
