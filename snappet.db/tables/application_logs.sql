CREATE TABLE [dbo].[application_logs]
(
	[Id]		int identity NOT NULL PRIMARY KEY,
	LogMessage	nvarchar(max),
	StackTrace	nvarchar(max),
	LogDate		datetime
)
