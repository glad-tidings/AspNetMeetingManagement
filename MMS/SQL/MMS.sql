USE [MMS]
GO
/****** Object:  Table [dbo].[IndexList]    Script Date: 11/24/2013 8:27:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndexList](
	[IndexID] [bigint] NOT NULL,
	[MID] [bigint] NOT NULL,
	[MeID] [bigint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MeetingMembers]    Script Date: 11/24/2013 8:27:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingMembers](
	[MID] [bigint] NOT NULL,
	[MeID] [bigint] NOT NULL,
	[MePresent] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meetings]    Script Date: 11/24/2013 8:27:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meetings](
	[MID] [bigint] NOT NULL,
	[MTitle] [nvarchar](max) NOT NULL,
	[MDate] [datetime] NOT NULL,
	[MDo] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Members]    Script Date: 11/24/2013 8:27:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MeID] [bigint] NOT NULL,
	[MeName] [nvarchar](max) NOT NULL,
	[MTel] [nvarchar](20) NOT NULL,
	[MMobile] [nvarchar](20) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
