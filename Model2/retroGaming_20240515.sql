USE [retro]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Id] [bigint] NOT NULL,
	[GameName] [nvarchar](255) NOT NULL,
	[GameImage] [nvarchar](255) NULL,
	[GenderId] [bigint] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [bigint] NOT NULL,
	[GenderName] [varchar](255) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Launch]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Launch](
	[Id] [bigint] NOT NULL,
	[GameId] [bigint] NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[Rating] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[SalesNumber] [bigint] NOT NULL,
	[PlatformId] [bigint] NOT NULL,
	[PublisherId] [bigint] NOT NULL,
 CONSTRAINT [PK_launches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platform]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platform](
	[Id] [bigint] NOT NULL,
	[PlatformName] [varchar](255) NULL,
 CONSTRAINT [PK_Platform] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[Id] [bigint] NOT NULL,
	[PublisherName] [varchar](255) NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Game] ([Id], [GameName], [GameImage], [GenderId]) VALUES (1, N'jogo_exemplo', N'Desktop/Imagens', 1)
GO
INSERT [dbo].[Gender] ([Id], [GenderName]) VALUES (1, N'Ação')
GO
INSERT [dbo].[Launch] ([Id], [GameId], [ReleaseDate], [Rating], [Price], [SalesNumber], [PlatformId], [PublisherId]) VALUES (1, 1, CAST(N'2001-03-24' AS Date), 3, 60, 10000, 1, 1)
INSERT [dbo].[Launch] ([Id], [GameId], [ReleaseDate], [Rating], [Price], [SalesNumber], [PlatformId], [PublisherId]) VALUES (2, 1, CAST(N'2003-04-21' AS Date), 2, 50, 2500, 1, 1)
INSERT [dbo].[Launch] ([Id], [GameId], [ReleaseDate], [Rating], [Price], [SalesNumber], [PlatformId], [PublisherId]) VALUES (3, 1, CAST(N'2001-11-21' AS Date), 2, 40, 2000, 1, 1)
GO
INSERT [dbo].[Platform] ([Id], [PlatformName]) VALUES (1, N'Playstation 1')
GO
INSERT [dbo].[Publisher] ([Id], [PublisherName]) VALUES (1, N'Eletronic Arts')
GO
/****** Object:  StoredProcedure [dbo].[GetGame]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetGame]
@Id BIGINT
AS
BEGIN
	SELECT * FROM Game WHERE Id=@Id
END




--TABELA LANCAMENTOS
--TABELA LANCAMENTOS
--TABELA LANCAMENTOS
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Launch]') AND type in (N'U'))
DROP TABLE [dbo].[Launch]
GO
/****** Object:  StoredProcedure [dbo].[GetGames]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetGames]
@id BIGINT
AS
BEGIN
	SELECT * FROM games WHERE id=@id
END




--TABELA LANCAMENTOS
--TABELA LANCAMENTOS
--TABELA LANCAMENTOS
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[launches]') AND type in (N'U'))
DROP TABLE [dbo].[launches]
GO
/****** Object:  StoredProcedure [dbo].[GetGender]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetGender]
@Id BIGINT
AS
BEGIN
	SELECT * FROM Gender WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[GetGenres]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetGenres]
@id BIGINT
AS
BEGIN
	SELECT * FROM genres WHERE id=@id
END


GO
/****** Object:  StoredProcedure [dbo].[GetLaunch]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLaunch]
@Id BIGINT
AS
BEGIN
	SELECT * FROM Launch WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetLaunches]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLaunches]
@id BIGINT
AS
BEGIN
	SELECT * FROM launches WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[GetPlatform]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPlatform]
@id BIGINT
AS
BEGIN
	SELECT * FROM Platform WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[GetPlatforms]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPlatforms]
@id BIGINT
AS
BEGIN
	SELECT * FROM platforms WHERE id=@id
END


GO
/****** Object:  StoredProcedure [dbo].[GetPublisher]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPublisher]
@Id BIGINT
AS
BEGIN
	SELECT * FROM Publisher WHERE Id=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[GetPublishers]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPublishers]
@id BIGINT
AS
BEGIN
	SELECT * FROM publishers WHERE id=@id
END


GO
/****** Object:  StoredProcedure [dbo].[GetReleases]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetReleases]
@id int
AS
BEGIN
	SELECT * FROM releases WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[ListGame]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListGame]
AS
BEGIN
	SELECT * FROM Game
END

GO
/****** Object:  StoredProcedure [dbo].[ListGames]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListGames]
AS
BEGIN
	SELECT * FROM games
END

GO
/****** Object:  StoredProcedure [dbo].[ListGender]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListGender]
AS
BEGIN
	SELECT * FROM Gender
END

GO
/****** Object:  StoredProcedure [dbo].[ListGenres]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListGenres]
AS
BEGIN
	SELECT * FROM genres
END

GO
/****** Object:  StoredProcedure [dbo].[ListLaunch]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListLaunch]
AS
BEGIN
	SELECT * FROM Launch
END

GO
/****** Object:  StoredProcedure [dbo].[ListLaunches]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListLaunches]
AS
BEGIN
	SELECT * FROM launches
END

GO
/****** Object:  StoredProcedure [dbo].[ListPlatform]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListPlatform]
AS
BEGIN
	SELECT * FROM Platform
END

GO
/****** Object:  StoredProcedure [dbo].[ListPlatforms]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListPlatforms]
AS
BEGIN
	SELECT * FROM platforms
END

GO
/****** Object:  StoredProcedure [dbo].[ListPublisher]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListPublisher]
AS
BEGIN
	SELECT * FROM Publisher
END

GO
/****** Object:  StoredProcedure [dbo].[ListPublishers]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListPublishers]
AS
BEGIN
	SELECT * FROM publishers
END

GO
/****** Object:  StoredProcedure [dbo].[ListReleases]    Script Date: 15/05/2024 21:34:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListReleases]
AS
BEGIN
	SELECT * FROM releases
END

GO
