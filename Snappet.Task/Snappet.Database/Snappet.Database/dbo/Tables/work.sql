CREATE TABLE [dbo].[work] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [SubmittedAnswerId] FLOAT (53)     NULL,
    [SubmitDateTime]    DATETIME NULL,
    [Correct]           BIT            NULL,
    [Progress]          FLOAT (53)     NULL,
    [UserId]            FLOAT (53)     NULL,
    [ExerciseId]        FLOAT (53)     NULL,
    [Difficulty]        FLOAT (53)     NULL,
    [Subject]           NVARCHAR (255) NULL,
    [Domain]            NVARCHAR (255) NULL,
    [LearningObjective] NVARCHAR (255) NULL,
    CONSTRAINT [PK_work] PRIMARY KEY CLUSTERED ([ID] ASC)
);

