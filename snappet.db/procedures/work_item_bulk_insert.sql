 
create procedure dbo.work_item_bulk_insert
(
	 @message varchar(5000), 
	 @stacktrace nvarchar(max),
	 @logdate datetime
)
AS
INSERT INTO application_logs(	
	logmessage, 
	stacktrace, 
	logdate)
 VALUES(
	 @message, 
	 @stacktrace, 
	 @logdate)
GO


