USE [SnappetChallange]
GO
/****** Object:  StoredProcedure [dbo].[Reporting_OnWhatMyClassHaveWorkedOnToday]    Script Date: 5/25/2017 7:46:26 PM ******/
DROP PROCEDURE IF EXISTS [dbo].[Reporting_OnWhatMyClassHaveWorkedOnToday]
GO
/****** Object:  StoredProcedure [dbo].[Reporting_OnWhatMyClassHaveWorkedOnToday]    Script Date: 5/25/2017 7:46:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reporting_OnWhatMyClassHaveWorkedOnToday]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Reporting_OnWhatMyClassHaveWorkedOnToday] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Reporting_OnWhatMyClassHaveWorkedOnToday]
	-- Add the parameters for the stored procedure here
	@dateFrom DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT sa.Domain
	,sa.Subject
	,sa.LearningObjective
	,SUM(sa.Correct) CorrectAnswers
	,COUNT(sa.SubmittedAnswerId) SubmittedAnswers
	FROM SubmittedAnswers sa
	WHERE sa.SubmitDateTime > dateadd(second, 1, dateadd(day, datediff(day, 0, @dateFrom), 0))
		AND sa.SubmitDateTime <= @dateFrom
	GROUP BY
		sa.Domain
		,sa.Subject
		,sa.LearningObjective
	ORDER BY
		sa.Domain
		,sa.Subject
		,sa.LearningObjective
END
GO
