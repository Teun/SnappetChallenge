
CREATE TABLE [dbo].[DayOverview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 [TillDateTime] DATETIME NOT NULL, 
    [NumberOfSubmission] INT NOT NULL, 
    [SumOfProgress] INT NOT NULL, 
    [NumberOfWorkedPupil] INT NOT NULL, 
    [NumberOfProgresseddPupil] INT NOT NULL, 
    [Subject] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_DayOverview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


