 
create procedure dbo.appsettings_findallgroups
	 
as 

Select  DISTINCT GroupName
     From snap_appsettings 