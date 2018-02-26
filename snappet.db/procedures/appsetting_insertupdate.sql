
CREATE PROCEDURE [dbo].[appsetting_insertupdate]
	@Id smallint,
	@Name nvarchar(255) = NULL,
	@Value nvarchar(255) = NULL,
	@Description nvarchar(255) = NULL,
	@GroupName nvarchar(255) = 'appSettings'
AS

IF EXISTS(SELECT [Id] FROM [dbo].[snap_appsettings] WHERE [Id] = @Id)
	BEGIN
		UPDATE [dbo].[snap_appsettings] SET
			[Name] = @Name,
			[Value] = @Value,
			[Description] = @Description,
			[GroupName] = @GroupName
		WHERE
			[Id] = @Id
	END
ELSE
BEGIN

	INSERT INTO [dbo].[snap_appsettings] (
		[Name],
		[Value],
		[Description],
		[GroupName]
	) VALUES (
		@Name,
		@Value,
		@Description,
		@GroupName
	)

	SET @Id = SCOPE_IDENTITY()
	SELECT @Id

END

--endregion
