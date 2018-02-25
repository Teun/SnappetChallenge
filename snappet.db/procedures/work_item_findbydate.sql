create procedure dbo.work_item_findbydate
(
	@rowStart	int,
	@rowEnd		int,
	@from		datetime,
    @to			datetime
)
as 

Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY SubmittedAnswerId) AS RowNum, 
		* 
     From work_item
	 where SubmitDateTime >= @from and SubmitDateTime <= @to
	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from work_item
where SubmitDateTime >= @from and SubmitDateTime <= @to