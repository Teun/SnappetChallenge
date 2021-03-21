truncate table WorkTemp
BULK INSERT WorkTemp
FROM 'C:\Github\SnappetChallenge\Data\work.csv'
WITH
(
	FORMAT = 'CSV',
	FIRSTROW = 2,
	FIELDTERMINATOR = ',',
	--ROWTERMINATOR = '0x0a'
	ROWTERMINATOR = '\n'
)
		

truncate table SubmittedAnswers
delete from Exercises	

delete from [Domains]
insert into [Domains](Title) 
select distinct Domain from WorkTemp 
where isnull(Domain, '') <> '' or Domain <> 'NULL'
		

delete from [Subjects]
insert into [Subjects](Title) 
select distinct [Subject] from WorkTemp 
where isnull([Subject], '') <> '' or [Subject] <> 'NULL'

delete from LearningObjectives
insert into LearningObjectives(Title) 
select distinct LearningObjective from WorkTemp 
where isnull(LearningObjective, '') <> '' or LearningObjective <> 'NULL'


insert into dbo.Exercises
(
	ExerciseId,
	SubjectId, 
	DomainId, 
	LearningObjectiveId, 
	Difficulty
)
select distinct
	ExerciseId,
	SubjectId, 
	DomainId, 
	LearningObjectiveId, 
	case when ISNUMERIC(w.Difficulty) = 0 then null else cast(Difficulty as decimal(18, 10)) end
from WorkTemp w
	inner join Subjects s on w.[Subject] = s.Title
	inner join [Domains] d on w.Domain = d.Title
	inner join LearningObjectives o on w.LearningObjective = o.Title
		

insert into SubmittedAnswers
(
	SubmittedAnswerId, 
	UserId, 
	ExerciseId, 
	SubmitDateTime, 
	Correct, 
	Progress
)
select 
	SubmittedAnswerId, 
	UserId, 
	ExerciseId, 
	SubmitDateTime, 
	Correct, 
	Progress
from WorkTemp w
	inner join Subjects s on w.[Subject] = s.Title
	inner join [Domains] d on w.Domain = d.Title
	inner join LearningObjectives o on w.LearningObjective = o.Title
