
create procedure dbo.application_logs_findbyid
( 
	@Id	int
)
as 

Select * 
	From application_logs
		where id = @Id