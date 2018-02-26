
create procedure dbo.work_item_findall
(
	@rowStart	int,
	@rowEnd		int
)
as 

Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY SubmittedAnswerId) AS RowNum, 
		* 
     From work_item
	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from work_item