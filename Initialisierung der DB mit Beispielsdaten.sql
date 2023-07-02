USE [master]
GO

/****** Object:  Database [MeineDB]    Script Date: 02.07.2023 23:36:07 ******/
DROP DATABASE [MeineDB]
GO

/****** Object:  Database [MeineDB]    Script Date: 02.07.2023 23:36:07 ******/
CREATE DATABASE [MeineDB]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MeineDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MeineDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MeineDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MeineDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MeineDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MeineDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [MeineDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MeineDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MeineDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MeineDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MeineDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MeineDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MeineDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MeineDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MeineDB] SET RECURSIVE_TRIGGERS ON 
GO

ALTER DATABASE [MeineDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MeineDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MeineDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MeineDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MeineDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MeineDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MeineDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MeineDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MeineDB] SET RECOVERY FULL 
GO

ALTER DATABASE [MeineDB] SET  MULTI_USER 
GO

ALTER DATABASE [MeineDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MeineDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MeineDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MeineDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MeineDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MeineDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MeineDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MeineDB] SET  READ_WRITE 
GO

USE [MeineDB]
GO

CREATE TABLE Fussballspieler
(
   Id INT IDENTITY(1,1) NOT NULL,
   Nachname NVARCHAR(255),
   Vorname NVARCHAR(255),
   Strasse NVARCHAR(255),
   PLZ NVARCHAR(255),
   Ort NVARCHAR(255),
   Telefonnummer NVARCHAR(255),
   Hoehe decimal(19,4),
   Geburtsdatum datetime,
   Nummer int,
   Position NVARCHAR(255),
   AnzahlSpiele int,
   AnzahlTore int,
   TeamID int
)  ON [PRIMARY]
GO
CREATE TABLE Teams
(
   Id INT IDENTITY(1,1) NOT NULL,
   Name NVARCHAR(255),
   Strasse NVARCHAR(255),
   PLZ NVARCHAR(255),
   Ort NVARCHAR(255),
   Telefonnummer NVARCHAR(255)
)  ON [PRIMARY]
GO

INSERT INTO Teams (Name, Strasse, PLZ, Ort, Telefonnummer) VALUES ('Teastteam1', 'Teststrasse 1', '8050', 'Zürich', '044 444 44 44')
INSERT INTO Teams (Name, Strasse, PLZ, Ort, Telefonnummer) VALUES ('Teastteam2', 'Teststrasse 2', '8051', 'Zürich', '033 333 33 33')

INSERT INTO Fussballspieler 
   (Nachname,
   Vorname,
   Strasse,
   PLZ,
   Ort,
   Telefonnummer,
   Hoehe,
   Geburtsdatum,
   Nummer,
   Position,
   AnzahlSpiele, AnzahlTore,
   TeamID)
VALUES
   ('Müller',
   'Peter',
   'Mustergasse 1',
   '8053',
   'Zürich',
   '044 333 33 22',
   '1.85',
   Getdate()-33162,
   1,
   'Mittelfeld',
   35, 2,
   1),
   ('Muster',
   'Hans',
   'Musterstrasse 1',
   '8052',
   'Zürich',
   '044 333 33 33',
   '1.80',
   Getdate()-33562,
   1,
   'Torwart',
   55, 0,
   1),
   ('Meier',
   'Fredi',
   'Musterplatz 1',
   '8053',
   'Zürich',
   '044 333 33 22',
   '1.65',
   Getdate()-31062,
   1,
   'Stürmer',
   80, 20,
   1),
   ('Mister',
   'Rick',
   'Musterecke 1',
   '8055',
   'Zürich',
   '044 333 11 33',
   '1.90',
   Getdate()-33562,
   2,
   'Stürmer',
   55, 0,
   1),
   ('Misses',
   'Frida',
   'Garten 1',
   '8059',
   'Zürich',
   '044 111 33 33',
   '1.40',
   Getdate()-30562,
   1,
   'Torwart',
   55, 0,
   2)






--SELECT * FROM Teams
--SELECT * FROM Fussballspieler
