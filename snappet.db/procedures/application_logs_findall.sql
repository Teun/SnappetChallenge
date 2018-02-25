
create procedure dbo.application_logs_findall
(
	@rowStart	int,
	@rowEnd		int
)
as



Select 
	a.*
From 
	(Select 
		ROW_NUMBER() OVER (ORDER BY Id) AS RowNum, 
		* 
     From application_logs
	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from application_logs