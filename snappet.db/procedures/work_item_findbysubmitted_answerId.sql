create procedure dbo.work_item_findbysubmitted_answerId
(
	@rowStart	int,
	@rowEnd		int,
	@submittedanswerId	int
)
as 

Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY SubmittedAnswerId) AS RowNum, 
		* 
     From work_item
	 Where SubmittedAnswerId = @submittedanswerId

	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from work_item
 where SubmittedAnswerId = @submittedanswerId