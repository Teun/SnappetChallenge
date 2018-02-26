create procedure dbo.work_item_findbyuser
(
	@rowStart	int,
	@rowEnd		int,
	@userId	int
)
as 

Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY SubmittedAnswerId) AS RowNum, 
		* 
     From work_item
	 Where UserId = @userId

	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from work_item
 where UserId = @userId