# bitcoin-transactions-BE
Team members
------------

Ueda Shehu
Gerta Duka
Klarisa Gjoka
Altea Maloku

Team leader
-----------

Ueda Shehu

Distribution of main roles and tasks
------------------------------------

Ueda Shehu - Sharing responsibilities within the team, make code review, work on Frontend part

Gerta Duka - Work on backend part, user authentication

Klarisa Gjoka - Crypto APIs research and analysis, work with Gerta to develop backend, Database schema (if needed) and setup

Altea Maloku - Check on best practices of designs, UI/UX, work together with Ueda to implement the frontend

Each of the team members have to work on documenting their respective development. Ueda as a team leader, makes a complete review of it.

Project description
-------------------

Goal

Create an app that helps to increase the productivity of end users of cryptocurrencies, financial institutions for the declaration of personal income or other stakeholders.

Objectives

 - Create frontend part of the app based on the requirements
 - Create backend part of the app based on the analysis of CoinAPI APIs
 - Integrate and analyse the available APIs related to cryptocurrency such as CoinAPI
 - Document the software engineering process
 
Description

Having in mind the strugle that cypto users face to have some user-friendly data and also financial institutions 
to provide easier way for individuals to declare their personal income from cryptocurrencies, we have this idea of the application.
This RESTful API software architecture integration application is implemented using Angular 12 and .NET Core technologies. 
Reads data from CoinApi Marketplace through endpoints that this API offers such as exchange rates, orders, sales, asset symbols of these currencies.
A user must successfully register and log in to access other interfaces. The user has profile, where he modifies his data. There are two user roles: administrator and simple. Admin view user list, delete/modify CoinApi key to authorize requests in this API. It has a main home page, which has clickable images that redirect to the interfaces application by facilitating the user experience. Application security is achieved through hashing password, but also JWT generation with some user data. We use JWT for that authorized almost any request in the backend part.

.Net Core 

Version: 7.0.302

How to set up the project locally

- Clone the project using git clone 
- Install the .NET Core SDK from its official website
- Open a command prompt or terminal and navigate to the directory where the project is located.
- Build the project by running "dotnet build"
- After the project is build successfully, run the command "dotnet run", which will launch the project and start listening for HTTP requests. You should see output indicating that the project is running.
- Install SQL server and make a successful connection with its local instance. Create a login with name "cryptocurrency_login" and password "1234".
- Run the following SQL script 
USE [master]
GO
/****** Object:  Database [cryptocurrency_integration]    Script Date: 5/21/2023 9:33:04 PM ******/
CREATE DATABASE [cryptocurrency_integration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cryptocurrency_integration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cryptocurrency_integration.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cryptocurrency_integration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\cryptocurrency_integration_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cryptocurrency_integration] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cryptocurrency_integration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cryptocurrency_integration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET ARITHABORT OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cryptocurrency_integration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cryptocurrency_integration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cryptocurrency_integration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cryptocurrency_integration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET RECOVERY FULL 
GO
ALTER DATABASE [cryptocurrency_integration] SET  MULTI_USER 
GO
ALTER DATABASE [cryptocurrency_integration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cryptocurrency_integration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cryptocurrency_integration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cryptocurrency_integration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cryptocurrency_integration] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cryptocurrency_integration] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'cryptocurrency_integration', N'ON'
GO
ALTER DATABASE [cryptocurrency_integration] SET QUERY_STORE = OFF
GO
USE [cryptocurrency_integration]
GO
/****** Object:  Table [dbo].[users]    Script Date: 5/21/2023 9:33:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[active] [tinyint] NOT NULL,
	[deleted] [tinyint] NOT NULL,
	[phone_number] [varchar](50) NOT NULL,
	[isNewUser] [int] NOT NULL,
	[password] [varchar](500) NULL,
	[dateExpirationToken] [datetime] NOT NULL,
	[access_token] [varchar](600) NOT NULL,
	[api_key] [varchar](400) NULL,
	[isAdmin] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((0)) FOR [isNewUser]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT (getdate()) FOR [dateExpirationToken]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ('') FOR [access_token]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((0)) FOR [isAdmin]
GO
USE [master]
GO
ALTER DATABASE [cryptocurrency_integration] SET  READ_WRITE 
GO

You are now able to test endpoints of this backend repository.

