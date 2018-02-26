create procedure dbo.work_item_report
(
	@rowStart	int,
	@rowEnd		int,
	@dateFrom datetime= nulll, 
    @dateTo datetime= nulll,

	@userId	int = nulll,
    @subject nvarchar(500)= nulll,
    @exerciseId int= nulll, 
    @difficulty nvarchar(500)= null
)
as 

Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY SubmittedAnswerId) AS RowNum, 
		* 
     From work_item
	 Where (UserId = @userId or @userId is  null) AND
	 (ExerciseId = @exerciseId or @exerciseId is  null) AND
	 (Difficulty = @difficulty or @difficulty is  null) AND
	 ([Subject] = @subject or @subject is  null) AND
	 (SubmitDateTime >= @dateFrom or  SubmitDateTime<= @dateTo)
	 

	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from work_item
 Where (UserId = @userId or @userId is  null) AND
	 (ExerciseId = @exerciseId or @exerciseId is  null) AND
	 (Difficulty = @difficulty or @difficulty is  null) AND
	 ([Subject] = @subject or @subject is  null) AND
	 (SubmitDateTime >= @dateFrom or  SubmitDateTime<= @dateTo)