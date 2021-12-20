USE [LearnResult]
GO

/****** Object:  Table [dbo].[Work]    Script Date: 18-12-2021 14:28:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Work](
	[SubmittedAnswerId] [int] NOT NULL,
	[SubmitDateTime] [datetime2](7) NOT NULL,
	[Correct] [bit] NULL,
	[Progress] [smallint] NOT NULL,
	[UserId] [int] NOT NULL,
	[ExerciseId] [int] NOT NULL,
	[Difficulty] [float] NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Domain] [nvarchar](50) NOT NULL,
	[LearningObjective] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[SubmittedAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


