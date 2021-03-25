USE [SnappetChallenge]
GO

/****** Object:  StoredProcedure [dbo].[Get_Summary_Data]    Script Date: 2021-03-25 03:12:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Summary_Data]

(@SummaryDate DateTime)

AS

SELECT
	SUM(CAST(Correct AS INT)) CorrectAnswers,
	COUNT(1) AnswersSubmitted,
	SUM(Progress) Progress,
	Subject,
	UserId
FROM 
	SubmittedAnswers
WHERE
	CONVERT(VARCHAR(10),SubmitDateTime,120)
LIKE
	CONVERT(VARCHAR(10), @SummaryDate,120)
GROUP BY
	UserId,
	Subject
ORDER BY
	UserId
GO


