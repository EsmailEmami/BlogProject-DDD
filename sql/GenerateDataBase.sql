USE [master]
GO
/****** Object:  Database [Blog_DB]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE DATABASE [Blog_DB]
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blog_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blog_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Blog_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Blog_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blog_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blog_DB] SET QUERY_STORE = OFF
GO
USE [Blog_DB]
GO
/****** Object:  Schema [Blog]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE SCHEMA [Blog]
GO
/****** Object:  Schema [Category]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE SCHEMA [Category]
GO
/****** Object:  Schema [Permission]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE SCHEMA [Permission]
GO
/****** Object:  Schema [Tag]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE SCHEMA [Tag]
GO
/****** Object:  Schema [User]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE SCHEMA [User]
GO
/****** Object:  Table [Blog].[Blogs]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Blog].[Blogs](
	[Id] [uniqueidentifier] NOT NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
	[BlogTitle] [nvarchar](150) NOT NULL,
	[Summary] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ImageFile] [nvarchar](50) NOT NULL,
	[WrittenAt] [datetime2](0) NOT NULL,
	[ReadTime] [nvarchar](10) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Category].[BlogCategories]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Category].[BlogCategories](
	[Id] [uniqueidentifier] NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_BlogCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Category].[Categories]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Category].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[CategoryTitle] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Permission].[Roles]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Permission].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Permission].[UserRoles]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Permission].[UserRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Tag].[BlogTags]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tag].[BlogTags](
	[Id] [uniqueidentifier] NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[TagId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_BlogTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Tag].[Tags]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Tag].[Tags](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[TagName] [nvarchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [User].[Comments]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [User].[Comments](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[CommentMessage] [nvarchar](1000) NOT NULL,
	[CommentDate] [datetime2](0) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [User].[Users]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [User].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [Blog].[Blogs] ([Id], [AuthorId], [BlogTitle], [Summary], [Description], [ImageFile], [WrittenAt], [ReadTime], [IsDeleted]) VALUES (N'7175763a-dab9-4317-bb15-3a198ee4b723', N'7de96742-2877-413c-a061-895db8bc0d23', N'ASA ASA SAS W', N'این یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی است', N'این یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی استاین یک مقاله تستی است', N'a083d6e97c53477d8d99195f788994c8.jpeg', CAST(N'2022-06-24T16:34:02.0000000' AS DateTime2), N'12:12', 0)
GO
INSERT [Category].[BlogCategories] ([Id], [BlogId], [CategoryId], [IsDeleted]) VALUES (N'9a6cbaed-6f70-4bf2-b5cb-bb858a91fe67', N'7175763a-dab9-4317-bb15-3a198ee4b723', N'cfba0eac-e434-46a0-ad5c-48ad366613d8', 0)
GO
INSERT [Category].[Categories] ([Id], [CategoryTitle], [IsDeleted]) VALUES (N'e0393123-d1a3-4fa9-a6eb-1bb43012d0cc', N'اقتصادی', 0)
GO
INSERT [Category].[Categories] ([Id], [CategoryTitle], [IsDeleted]) VALUES (N'cfba0eac-e434-46a0-ad5c-48ad366613d8', N'ورزشی', 0)
GO
INSERT [Category].[Categories] ([Id], [CategoryTitle], [IsDeleted]) VALUES (N'882ec2fd-ea0e-4123-9cc5-b4b7f2ef17ff', N'مجله', 0)
GO
INSERT [Category].[Categories] ([Id], [CategoryTitle], [IsDeleted]) VALUES (N'0509b2a3-cc24-4b55-99d3-e4abb73496cd', N'سیاسی', 0)
GO
INSERT [Permission].[Roles] ([Id], [RoleName], [IsDeleted]) VALUES (N'545d46d0-26ff-4428-9912-4a3c7ca6abe2', N'USERMANAGER', 0)
GO
INSERT [Permission].[Roles] ([Id], [RoleName], [IsDeleted]) VALUES (N'0a19dad5-1357-4737-bd64-c15a59c10482', N'ROLEMANAGER', 0)
GO
INSERT [Permission].[UserRoles] ([Id], [UserId], [RoleId], [IsDeleted]) VALUES (N'8033db1a-a17b-450c-ae0c-e09aa5b8057e', N'7de96742-2877-413c-a061-895db8bc0d23', N'545d46d0-26ff-4428-9912-4a3c7ca6abe2', 0)
GO
INSERT [Permission].[UserRoles] ([Id], [UserId], [RoleId], [IsDeleted]) VALUES (N'ce688714-d0a0-4e31-bae9-f878609fbb32', N'7de96742-2877-413c-a061-895db8bc0d23', N'0a19dad5-1357-4737-bd64-c15a59c10482', 0)
GO
INSERT [Tag].[BlogTags] ([Id], [BlogId], [TagId], [IsDeleted]) VALUES (N'ff34f11a-af0d-4c68-ada7-992eb334e977', N'7175763a-dab9-4317-bb15-3a198ee4b723', N'41eb7b46-a69a-4763-9eea-d96c73dbf0da', 0)
GO
INSERT [Tag].[BlogTags] ([Id], [BlogId], [TagId], [IsDeleted]) VALUES (N'e6102983-be26-483e-8307-f753b6fffddc', N'7175763a-dab9-4317-bb15-3a198ee4b723', N'4237de64-2304-462e-bd6e-8c873a483b59', 0)
GO
INSERT [Tag].[Tags] ([Id], [TagName], [IsDeleted]) VALUES (N'4237de64-2304-462e-bd6e-8c873a483b59', N'مجله خبری', 0)
GO
INSERT [Tag].[Tags] ([Id], [TagName], [IsDeleted]) VALUES (N'41eb7b46-a69a-4763-9eea-d96c73dbf0da', N'خبر', 0)
GO
INSERT [User].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsDeleted]) VALUES (N'7de96742-2877-413c-a061-895db8bc0d23', N'esmail', N'emami', N'esmailemami84@gmail.com', N'10000.zLrSg/oj0TwFSXjyRXqRGA==.M8i6n0rbLxAUKkmfqyPjmnj3NHwDbFPER5gwEGDCtcE=', 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Category_Title]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Category_Title] ON [Category].[Categories]
(
	[CategoryTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Roles_Name]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Roles_Name] ON [Permission].[Roles]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Tags_Name]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Tags_Name] ON [Tag].[Tags]
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comments_Title]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_Title] ON [User].[Comments]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Email]    Script Date: 7/3/2022 11:05:42 AM ******/
ALTER TABLE [User].[Users] ADD  CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_Deleted]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_Users_Deleted] ON [User].[Users]
(
	[IsDeleted] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_FirstName]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_Users_FirstName] ON [User].[Users]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_LastName]    Script Date: 7/3/2022 11:05:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_Users_LastName] ON [User].[Users]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Blog].[Blogs] ADD  CONSTRAINT [DF_Blogs_WrittenAt]  DEFAULT (getdate()) FOR [WrittenAt]
GO
ALTER TABLE [Blog].[Blogs] ADD  CONSTRAINT [DF_Blogs_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Category].[BlogCategories] ADD  CONSTRAINT [DF_BlogCategories_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Category].[BlogCategories] ADD  CONSTRAINT [DF_BlogCategories_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Category].[Categories] ADD  CONSTRAINT [DF_Category_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Category].[Categories] ADD  CONSTRAINT [DF_Categories_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Permission].[Roles] ADD  CONSTRAINT [DF_Roles_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Permission].[Roles] ADD  CONSTRAINT [DF_Roles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Permission].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Permission].[UserRoles] ADD  CONSTRAINT [DF_UserRoles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Tag].[BlogTags] ADD  CONSTRAINT [DF_BlogTags_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Tag].[BlogTags] ADD  CONSTRAINT [DF_BlogTags_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Tag].[Tags] ADD  CONSTRAINT [DF_Tags_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Tag].[Tags] ADD  CONSTRAINT [DF_Tags_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [User].[Comments] ADD  CONSTRAINT [DF_Comments_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [User].[Comments] ADD  CONSTRAINT [DF_Comments_CommentDate]  DEFAULT (getdate()) FOR [CommentDate]
GO
ALTER TABLE [User].[Comments] ADD  CONSTRAINT [DF_Comments_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [User].[Users] ADD  CONSTRAINT [DF_Users_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [User].[Users] ADD  CONSTRAINT [DF_Users_IsDelete]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [Blog].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_Blogs_Users] FOREIGN KEY([AuthorId])
REFERENCES [User].[Users] ([Id])
GO
ALTER TABLE [Blog].[Blogs] CHECK CONSTRAINT [FK_Blogs_Users]
GO
ALTER TABLE [Category].[BlogCategories]  WITH CHECK ADD  CONSTRAINT [FK_BlogCategories_Blogs] FOREIGN KEY([BlogId])
REFERENCES [Blog].[Blogs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Category].[BlogCategories] CHECK CONSTRAINT [FK_BlogCategories_Blogs]
GO
ALTER TABLE [Category].[BlogCategories]  WITH CHECK ADD  CONSTRAINT [FK_BlogCategories_Categories] FOREIGN KEY([CategoryId])
REFERENCES [Category].[Categories] ([Id])
GO
ALTER TABLE [Category].[BlogCategories] CHECK CONSTRAINT [FK_BlogCategories_Categories]
GO
ALTER TABLE [Permission].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [Permission].[Roles] ([Id])
GO
ALTER TABLE [Permission].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [Permission].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [User].[Users] ([Id])
GO
ALTER TABLE [Permission].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
ALTER TABLE [Tag].[BlogTags]  WITH CHECK ADD  CONSTRAINT [FK_BlogTags_Blogs] FOREIGN KEY([BlogId])
REFERENCES [Blog].[Blogs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Tag].[BlogTags] CHECK CONSTRAINT [FK_BlogTags_Blogs]
GO
ALTER TABLE [Tag].[BlogTags]  WITH CHECK ADD  CONSTRAINT [FK_BlogTags_Tags] FOREIGN KEY([TagId])
REFERENCES [Tag].[Tags] ([Id])
GO
ALTER TABLE [Tag].[BlogTags] CHECK CONSTRAINT [FK_BlogTags_Tags]
GO
ALTER TABLE [User].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Blogs] FOREIGN KEY([BlogId])
REFERENCES [Blog].[Blogs] ([Id])
GO
ALTER TABLE [User].[Comments] CHECK CONSTRAINT [FK_Comments_Blogs]
GO
ALTER TABLE [User].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserId])
REFERENCES [User].[Users] ([Id])
GO
ALTER TABLE [User].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [Blog].[Blogs]  WITH CHECK ADD  CONSTRAINT [CK_Blog_DescriptionMinLength] CHECK  ((len([Description])>=(2000)))
GO
ALTER TABLE [Blog].[Blogs] CHECK CONSTRAINT [CK_Blog_DescriptionMinLength]
GO
ALTER TABLE [Blog].[Blogs]  WITH CHECK ADD  CONSTRAINT [CK_Blog_SummaryMinLength] CHECK  ((len([Summary])>=(50)))
GO
ALTER TABLE [Blog].[Blogs] CHECK CONSTRAINT [CK_Blog_SummaryMinLength]
GO
ALTER TABLE [Blog].[Blogs]  WITH CHECK ADD  CONSTRAINT [CK_Blog_TitleMinLength] CHECK  ((len([BlogTitle])>=(5)))
GO
ALTER TABLE [Blog].[Blogs] CHECK CONSTRAINT [CK_Blog_TitleMinLength]
GO
ALTER TABLE [Category].[Categories]  WITH CHECK ADD  CONSTRAINT [CK_Category_TitleMinLength] CHECK  ((len([CategoryTitle])>=(3)))
GO
ALTER TABLE [Category].[Categories] CHECK CONSTRAINT [CK_Category_TitleMinLength]
GO
ALTER TABLE [Permission].[Roles]  WITH CHECK ADD  CONSTRAINT [CK_Roles_NameLength] CHECK  ((len([RoleName])>=(3)))
GO
ALTER TABLE [Permission].[Roles] CHECK CONSTRAINT [CK_Roles_NameLength]
GO
ALTER TABLE [Tag].[Tags]  WITH CHECK ADD  CONSTRAINT [CK_Tags_NameMinLength] CHECK  ((len([TagName])>=(3)))
GO
ALTER TABLE [Tag].[Tags] CHECK CONSTRAINT [CK_Tags_NameMinLength]
GO
ALTER TABLE [User].[Comments]  WITH CHECK ADD  CONSTRAINT [CK_Comments_Message_MinLength] CHECK  ((len([CommentMessage])>=(10)))
GO
ALTER TABLE [User].[Comments] CHECK CONSTRAINT [CK_Comments_Message_MinLength]
GO
ALTER TABLE [User].[Comments]  WITH CHECK ADD  CONSTRAINT [CK_Comments_Title_MinLength] CHECK  ((len([Title])>=(5)))
GO
ALTER TABLE [User].[Comments] CHECK CONSTRAINT [CK_Comments_Title_MinLength]
GO
ALTER TABLE [User].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users_FirstNameMinLength] CHECK  ((len([FirstName])>=(3)))
GO
ALTER TABLE [User].[Users] CHECK CONSTRAINT [CK_Users_FirstNameMinLength]
GO
ALTER TABLE [User].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users_LastNameMinLength] CHECK  ((len([LastName])>=(3)))
GO
ALTER TABLE [User].[Users] CHECK CONSTRAINT [CK_Users_LastNameMinLength]
GO
/****** Object:  StoredProcedure [User].[uspGetAdmins]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [User].[uspGetAdmins]
	@Skip INT = 0,
	@Take INT = 5,
	@Search NVARCHAR(25) = NULL
AS
BEGIN
SET NOCOUNT ON;

DECLARE @QUERY NVARCHAR(MAX) = "SELECT [Users].[Id] AS [UserId], CONCAT([Users].[FirstName], ' ' , [Users].[LastName]) AS [FullName], [Users].[Email] 
FROM [User].[Users] 
INNER JOIN [Permission].[UserRoles]
ON [User].[Users].[Id] = [Permission].[UserRoles].[UserId] ";

IF @Search IS NOT NULL
BEGIN 
SET @QUERY = @QUERY + "WHERE ([FirstName] LIKE N'%" + @Search + "%') 
	OR ([LastName] LIKE N'%" + @Search + "%')
	OR ([Email] LIKE N'%" + @Search + "%') ";
END

SET @QUERY  = @QUERY + "ORDER BY [FirstName] DESC, [LastName] DESC OFFSET " + CONVERT(nvarchar(MAX), @Skip) + " ROWS FETCH NEXT " + CONVERT(nvarchar(MAX), @Take) + " ROWS ONLY;";

EXEC (@QUERY);
END
GO
/****** Object:  StoredProcedure [User].[uspGetUsers]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [User].[uspGetUsers]
	@Skip INT = 0,
	@Take INT = 5,
	@Search NVARCHAR(25) = NULL
AS
BEGIN
SET NOCOUNT ON;

DECLARE @QUERY NVARCHAR(MAX) = "SELECT [Id] AS [UserId], CONCAT([FirstName], ' ' , [LastName]) AS [FullName], [Email] 
FROM [User].[Users] ";

IF @Search IS NOT NULL
BEGIN 
SET @QUERY = @QUERY + "WHERE ([FirstName] LIKE N'%" + @Search + "%') 
	OR ([LastName] LIKE N'%" + @Search + "%')
	OR ([Email] LIKE N'%" + @Search + "%') ";
END

SET @QUERY  = @QUERY + "ORDER BY [FirstName] DESC, [LastName] DESC OFFSET " + CONVERT(nvarchar(MAX), @Skip) + " ROWS FETCH NEXT " + CONVERT(nvarchar(MAX), @Take) + " ROWS ONLY;";

EXEC (@QUERY);
END
GO
/****** Object:  Trigger [Blog].[BlogUpdated]    Script Date: 7/3/2022 11:05:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Blog].[BlogUpdated]
ON [Blog].[Blogs]
AFTER UPDATE
AS 
SET NOCOUNT ON
DECLARE @BlogId AS UNIQUEIDENTIFIER = (SELECT [Id] FROM [Inserted]);
DELETE FROM [Tag].[BlogTags] WHERE [BlogId] = @BlogId;
DELETE FROM [Category].[BlogCategories] WHERE [BlogId] = @BlogId;
GO
ALTER TABLE [Blog].[Blogs] ENABLE TRIGGER [BlogUpdated]
GO
/****** Object:  Trigger [User].[CommentInserted]    Script Date: 7/3/2022 11:05:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   TRIGGER  [User].[CommentInserted]
ON [User].[Comments]
AFTER INSERT 
AS

SELECT [Inserted].[Id] AS [CommentId], 
	CONCAT([Users].[FirstName], ' ',[Users].[LastName]) AS [FullName],  
    [Inserted].[Title],  
    [Inserted].[CommentMessage],  
    [Inserted].[CommentDate]  
FROM [Inserted]
	INNER JOIN [User].[Users]  
    ON [Inserted].[UserId] = [User].[Users].[Id]  
GO
ALTER TABLE [User].[Comments] ENABLE TRIGGER [CommentInserted]
GO
/****** Object:  Trigger [User].[UserUpdated]    Script Date: 7/3/2022 11:05:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [User].[UserUpdated]
ON [User].[Users]
AFTER UPDATE
AS 
SET NOCOUNT ON
DECLARE @UserId AS UNIQUEIDENTIFIER = (SELECT [Id] FROM [Inserted]);
DELETE FROM [Permission].[UserRoles] WHERE [UserId] = @UserId;
GO
ALTER TABLE [User].[Users] ENABLE TRIGGER [UserUpdated]
GO
USE [master]
GO
ALTER DATABASE [Blog_DB] SET  READ_WRITE 
GO
