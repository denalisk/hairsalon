USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/24/2017 3:50:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stylist_id] [int] NULL,
	[name] [varchar](255) NULL,
	[hair_color] [varchar](50) NULL,
	[creation_date] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 2/24/2017 3:50:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
