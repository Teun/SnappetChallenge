
CREATE TABLE [dbo].[work_item]
( 
	SubmittedAnswerId	int,
	SubmitDateTime	datetime,
	Correct			int,
	Progress		int,
	UserId			int,
	ExerciseId		int,
	Difficulty		nvarchar(500),
	[Subject]		nvarchar(500),
	[Domain]		nvarchar(200),
	[LearningObjective] nvarchar(max) 
) 