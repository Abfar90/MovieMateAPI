USE [master]
GO

/****** Object:  Database [MovieMateDB]    Script Date: 27/01/2024 17:24:14 ******/
CREATE DATABASE [MovieMateDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieMateDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MovieMateDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieMateDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MovieMateDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieMateDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MovieMateDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MovieMateDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MovieMateDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MovieMateDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MovieMateDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [MovieMateDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MovieMateDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MovieMateDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MovieMateDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MovieMateDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MovieMateDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MovieMateDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MovieMateDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MovieMateDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MovieMateDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MovieMateDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MovieMateDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MovieMateDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MovieMateDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MovieMateDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MovieMateDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MovieMateDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MovieMateDB] SET RECOVERY FULL 
GO

ALTER DATABASE [MovieMateDB] SET  MULTI_USER 
GO

ALTER DATABASE [MovieMateDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MovieMateDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MovieMateDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MovieMateDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MovieMateDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MovieMateDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MovieMateDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MovieMateDB] SET  READ_WRITE 
GO
