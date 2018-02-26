 

CREATE TABLE [dbo].[snap_appsettings](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Value] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[GroupName] [nvarchar](255) NOT NULL CONSTRAINT [DF__tbl_snap_appsettings__group__3BCADD1B]  DEFAULT ('appSettings'),
 CONSTRAINT [PK__tbl_snap_appsettings_id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

