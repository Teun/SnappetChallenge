USE [SnappetChallenge]
GO

/****** Object:  StoredProcedure [dbo].[Get_Students]    Script Date: 2021-03-25 03:12:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Get_Students]

AS

SELECT
	DISTINCT(UserId) UserId
FROM
	SubmittedAnswers
ORDER BY
	UserId
GO


