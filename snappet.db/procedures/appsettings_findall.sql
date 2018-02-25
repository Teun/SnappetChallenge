
create procedure dbo.appsettings_findall
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
     From snap_appsettings
	 ) as a 
Where RowNum > @rowStart AND RowNum <= @rowEnd


Select count(1) as TotalRecords from snap_appsettings