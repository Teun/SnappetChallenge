USE [SnappetChallenge]
GO

/****** Object:  StoredProcedure [dbo].[Get_Subjects]    Script Date: 2021-03-25 03:12:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Subjects]

(@SummaryDate DateTime)

AS

SELECT
	DISTINCT([Subject]) [SubjectName]
FROM
	SubmittedAnswers
WHERE
	CONVERT(VARCHAR(10),SubmitDateTime,120)
LIKE
	CONVERT(VARCHAR(10), @SummaryDate,120)
ORDER BY
	[SubjectName]
GO


