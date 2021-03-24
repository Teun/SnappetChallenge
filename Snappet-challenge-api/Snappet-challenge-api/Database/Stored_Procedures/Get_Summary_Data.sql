USE [SnappetChallenge]
GO

/****** Object:  StoredProcedure [dbo].[Get_Summary_Data]    Script Date: 2021-03-24 10:15:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_Summary_Data]

AS

SELECT
	SUM(CAST(Correct AS INT)) CorrectAnswers,
	COUNT(1) AnswersSubmitted,
	SUM(Progress) Progress,
	Subject,
	UserId
FROM 
	SubmittedAnswers
GROUP BY
	UserId,
	Subject
ORDER BY
	UserId
GO