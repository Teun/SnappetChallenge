create procedure dbo.work_item_findbysubject
(
	@rowStart	int,
	@rowEnd		int,
	@subject	nvarchar(500)
)
as 

Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY SubmittedAnswerId) AS RowNum, 
		* 
     From work_item
	 where [Subject] = @subject
	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from work_item
 where [Subject] = @subject