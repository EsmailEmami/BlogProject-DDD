USE [master]
GO
/****** Object:  Database [Blog_DB]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Schema [Blog]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE SCHEMA [Blog]
GO
/****** Object:  Schema [Category]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE SCHEMA [Category]
GO
/****** Object:  Schema [Permission]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE SCHEMA [Permission]
GO
/****** Object:  Schema [Tag]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE SCHEMA [Tag]
GO
/****** Object:  Schema [User]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE SCHEMA [User]
GO
/****** Object:  Table [Blog].[Blogs]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [Category].[BlogCategories]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [Category].[Categories]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [Permission].[Roles]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [Permission].[UserRoles]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [Tag].[BlogTags]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [Tag].[Tags]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [User].[Comments]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Table [User].[Users]    Script Date: 6/24/2022 8:19:31 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Category_Title]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Category_Title] ON [Category].[Categories]
(
	[CategoryTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Roles_Name]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Roles_Name] ON [Permission].[Roles]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Tags_Name]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Tags_Name] ON [Tag].[Tags]
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comments_Title]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_Title] ON [User].[Comments]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_Deleted]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_Deleted] ON [User].[Users]
(
	[IsDeleted] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_FirstName]    Script Date: 6/24/2022 8:19:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_FirstName] ON [User].[Users]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_LastName]    Script Date: 6/24/2022 8:19:31 PM ******/
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
/****** Object:  Trigger [Blog].[BlogUpdated]    Script Date: 6/24/2022 8:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [Blog].[BlogUpdated]
ON [Blog].[Blogs]
AFTER UPDATE
AS 
SET NOCOUNT ON
DECLARE @UserId AS UNIQUEIDENTIFIER = (SELECT [Id] FROM [Inserted]);
DELETE FROM [Tag].[BlogTags] WHERE [BlogId] = @UserId;
DELETE FROM [Category].[BlogCategories] WHERE [BlogId] = @UserId;
GO
ALTER TABLE [Blog].[Blogs] ENABLE TRIGGER [BlogUpdated]
GO
/****** Object:  Trigger [User].[CommentInserted]    Script Date: 6/24/2022 8:19:31 PM ******/
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
USE [master]
GO
ALTER DATABASE [Blog_DB] SET  READ_WRITE 
GO
