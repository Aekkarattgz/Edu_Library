USE [master]
GO
/****** Object:  Database [LibraryDB]    Script Date: 11/14/2024 12:37:47 PM ******/
CREATE DATABASE [LibraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraryDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraryDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibraryDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LibraryDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibraryDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibraryDB]
GO
/****** Object:  Table [dbo].[Book_tb]    Script Date: 11/14/2024 12:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_tb](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Detail] [nvarchar](max) NULL,
	[Author] [nvarchar](100) NULL,
	[CoverImage] [nvarchar](200) NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_tb]    Script Date: 11/14/2024 12:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_tb](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_tb]    Script Date: 11/14/2024 12:37:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_tb](
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book_tb] ON 

INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (20, N'To Kill a Mockingbird', N'A novel about the serious issues of rape and racial inequality.', N'Harper Lee', N'https://picsum.photos/200/300', 1)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (21, N'To Kill a Mockingbird', N'A novel about the serious issues of rape and racial inequality.', N'Harper Lee', N'https://picsum.photos/200', 1)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (22, N'1984', N'A dystopian social science fiction novel and cautionary tale.', N'George Orwell', N'https://picsum.photos/id/237/200/300', 1)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (23, N'Pride and Prejudice', N'A romantic novel that critiques the British landed gentry.', N'Jane Austen', N'https://picsum.photos/seed/picsum/200/300', 1)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (24, N'The Catcher in the Rye', N'A story about adolescent alienation and loss of innocence.', N'J.D. Salinger', N'https://picsum.photos/200/300?grayscale', 1)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (25, N'The Great Gatsby', N'A novel depicting the American Jazz Age.', N'F. Scott Fitzgerald', N'https://picsum.photos/200/300/?blur=2', 1)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (26, N'A Brief History of Time', N'An overview of cosmology and physics concepts.', N'Stephen Hawking', N'https://picsum.photos/id/870/200/300?grayscale&blur=2', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (27, N'The Selfish Gene', N'An influential book on evolutionary biology.', N'Richard Dawkins', N'https://picsum.photos/200/300.jpg', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (28, N'The Origin of Species', N'The foundational text on evolutionary biology.', N'Charles Darwin', N'https://picsum.photos/200/300.webp', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (29, N'Silent Spring', N'A book that led to the environmental movement.', N'Rachel Carson', N'https://picsum.photos/200', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (30, N'Cosmos', N'An exploration of science and the universe.', N'Carl Sagan', N'https://picsum.photos/id/237/200/300', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (31, N'Steve Jobs', N'A biography of the co-founder of Apple Inc.', N'Walter Isaacson', N'https://picsum.photos/200/300', 3)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (32, N'The Wright Brothers', N'The story of the inventors of the airplane.', N'David McCullough', N'https://picsum.photos/200/300?grayscale', 3)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (33, N'Einstein: His Life and Universe', N'A biography of the physicist Albert Einstein.', N'Walter Isaacson', N'https://picsum.photos/200/300/?blur=2', 3)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (34, N'Alexander Hamilton', N'A biography of the American founding father.', N'Ron Chernow', N'https://picsum.photos/200/300/?blur=2', 3)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (35, N'Becoming', N'A memoir by former First Lady Michelle Obama.', N'Michelle Obama', N'https://picsum.photos/id/870/200/300?grayscale&blur=2', 3)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (36, N'Sapiens: A Brief History of Humankind', N'A historical look at humanity.', N'Yuval Noah Harari', N'https://picsum.photos/200/300.webp', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (37, N'The Power of Habit', N'A book on the science of habit formation.', N'Charles Duhigg', N'https://picsum.photos/id/870/200/300?grayscale&blur=2', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (38, N'Thinking, Fast and Slow', N'Insights into human decision-making processes.', N'Daniel Kahneman', N'https://picsum.photos/200', 3)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (39, N'Atomic Habits', N'A guide to building good habits and breaking bad ones.', N'James Clear', N'https://picsum.photos/id/237/200/300', 2)
INSERT [dbo].[Book_tb] ([BookId], [Name], [Detail], [Author], [CoverImage], [CategoryId]) VALUES (40, N'Grit: The Power of Passion and Perseverance', N'A book about passion and persistence.', N'Angela Duckworth', N'https://picsum.photos/200/300', 1)
SET IDENTITY_INSERT [dbo].[Book_tb] OFF
GO
SET IDENTITY_INSERT [dbo].[Category_tb] ON 

INSERT [dbo].[Category_tb] ([CategoryId], [Name]) VALUES (1, N'Fiction')
INSERT [dbo].[Category_tb] ([CategoryId], [Name]) VALUES (2, N'Science')
INSERT [dbo].[Category_tb] ([CategoryId], [Name]) VALUES (3, N'Biography')
SET IDENTITY_INSERT [dbo].[Category_tb] OFF
GO
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123456, N'Admin1', N'admin1@example.com', N'password123')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123457, N'Admin2', N'admin2@example.com', N'password456')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123458, N'User1', N'user1@example.com', N'userpassword1')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123459, N'User2', N'user2@example.com', N'userpassword2')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123460, N'User3', N'user3@example.com', N'userpassword3')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123461, N'User4', N'user4@example.com', N'userpassword4')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123462, N'User5', N'user5@example.com', N'userpassword5')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123463, N'User6', N'user6@example.com', N'userpassword6')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123464, N'User7', N'user7@example.com', N'userpassword7')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123465, N'User8', N'user8@example.com', N'userpassword8')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123466, N'User9', N'user9@example.com', N'userpassword9')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123467, N'User10', N'user10@example.com', N'userpassword10')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123468, N'User11', N'user11@example.com', N'userpassword11')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123469, N'User12', N'user12@example.com', N'userpassword12')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123470, N'User13', N'user13@example.com', N'userpassword13')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123471, N'User14', N'user14@example.com', N'userpassword14')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123472, N'User15', N'user15@example.com', N'userpassword15')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123473, N'User16', N'user16@example.com', N'userpassword16')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123474, N'User17', N'user17@example.com', N'userpassword17')
INSERT [dbo].[User_tb] ([UserId], [UserName], [Email], [Password]) VALUES (123475, N'User18', N'user18@example.com', N'userpassword18')
GO
ALTER TABLE [dbo].[Book_tb]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category_tb] ([CategoryId])
GO
ALTER TABLE [dbo].[User_tb]  WITH CHECK ADD CHECK  ((len([UserId])=(6)))
GO
USE [master]
GO
ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO
