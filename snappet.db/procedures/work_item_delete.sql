 
create procedure dbo.work_item_delete
(
	 @id int
)
AS
DELETE work_item
WHERE SubmittedAnswerId = @id

