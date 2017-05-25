CREATE TABLE tWork
(
	SubmittedAnswerId	INT NOT NULL PRIMARY KEY,
	SubmitDateTime		DATETIME NOT NULL,
	Correct				BIT NOT NULL,
	Progress			INT NOT NULL,
	UserId				INT NOT NULL,
	ExerciseId			INT NOT NULL,
	Difficulty			INT NOT NULL,
	Subject				VARCHAR(255) NULL,
	Domain				VARCHAR(255) NULL,
	LearningObjective	VARCHAR(255) NULL
)
GO
