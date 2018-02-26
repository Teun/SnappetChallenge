 
create procedure dbo.appsettings_findbyname
	 @settingsName nvarchar(500)
as 

Select  * from  snap_appsettings
    where Name = @settingsName