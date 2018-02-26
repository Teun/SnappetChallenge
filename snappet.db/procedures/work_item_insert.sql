 
create procedure dbo.work_item_insert
(
	@SubmittedAnswerId	int,
	@SubmitDateTime	datetime,
	@Correct			int,
	@Progress		int,
	@UserId			int,
	@ExerciseId		int,
	@Difficulty		nvarchar(500),
	@Subject		nvarchar(500),
	@Domain		nvarchar(200),
	@LearningObjective nvarchar(max) 
)
AS
INSERT INTO work_item(	
	SubmittedAnswerId,
	SubmitDateTime,
	Correct,
	Progress,
	UserId,
	ExerciseId,
	Difficulty,
	[Subject],
	[Domain],
	[LearningObjective]
	)
 VALUES(
	@SubmittedAnswerId,
	@SubmitDateTime	,
	@Correct,
	@Progress,
	@UserId,
	@ExerciseId,
	@Difficulty,
	@Subject,
	@Domain,
	@LearningObjective 
	)
GO


