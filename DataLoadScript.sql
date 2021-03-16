/*SELECT ReportRecord.*
	INTO dbo.ReportRecords 
 FROM OPENROWSET (BULK 'C:\PROJECTS\SnappetReports\work.json', SINGLE_CLOB) as j
 CROSS APPLY OPENJSON(BulkColumn)
 WITH( SubmittedAnswerId int, SubmitDateTime DateTime, Correct int,
 Progress int, UserId int, ExerciseId int, Difficulty  nvarchar(30),
 Subject nvarchar(200), Domain nvarchar(10), LearningObjective nvarchar(300)
 ) AS ReportRecord*/