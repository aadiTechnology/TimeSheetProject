USE [TimeSheet]
GO

/******************************** Table : [dbo].[Activity_Type]  ******************/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Activity_Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Activity] [nvarchar](200) NULL,
 CONSTRAINT [PK_Activity_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/************************************* End  *****************************************************/
/****************** Table [dbo].[TimeSheetsDetails]  ************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TimeSheetsDetails]') AND type in (N'U'))
DROP TABLE [dbo].[TimeSheetsDetails]
GO

/****** Object:  Table [dbo].[TimeSheetsDetails]    Script Date: 04-11-2020 13:08:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimeSheetsDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NULL,
	[TaskId] [int] NULL,
	[ActualStartDate] [date] NULL,
	[ActualEndDate] [date] NULL,
	[Efforts] [int] NULL,
	[ProductiveHrs] [int] NULL,
	[ActivityComment] [nvarchar](500) NULL,
	[ActId] [int] NULL,
 CONSTRAINT [PK_TimeSheetsDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


