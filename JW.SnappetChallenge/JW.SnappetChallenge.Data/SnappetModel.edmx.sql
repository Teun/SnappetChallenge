
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/04/2017 20:41:25
-- Generated from EDMX file: C:\development\local-dev\JW.SnappetChallenge\JW.SnappetChallenge.Data\SnappetModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SnappetDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AggregatedProgressData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AggregatedProgressData];
GO
IF OBJECT_ID(N'[dbo].[AggregatedProgressDataImport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AggregatedProgressDataImport];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AggregatedProgressData'
CREATE TABLE [dbo].[AggregatedProgressData] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubmittedAnswerId] int  NOT NULL,
    [SubmitDateTime] datetime  NOT NULL,
    [Correct] bit  NOT NULL,
    [Progress] int  NOT NULL,
    [UserId] int  NOT NULL,
    [ExerciseId] int  NOT NULL,
    [Difficulty] nvarchar(max)  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Domain] nvarchar(max)  NOT NULL,
    [LearningObjective] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AggregatedProgressDataImport'
CREATE TABLE [dbo].[AggregatedProgressDataImport] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubmittedAnswerId] int  NOT NULL,
    [SubmitDateTime] nvarchar(max)  NOT NULL,
    [Correct] bit  NOT NULL,
    [Progress] int  NOT NULL,
    [UserId] int  NOT NULL,
    [ExcerciseId] int  NOT NULL,
    [Difficulty] nvarchar(max)  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Domain] nvarchar(max)  NOT NULL,
    [LearningObjective] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AggregatedProgressData'
ALTER TABLE [dbo].[AggregatedProgressData]
ADD CONSTRAINT [PK_AggregatedProgressData]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AggregatedProgressDataImport'
ALTER TABLE [dbo].[AggregatedProgressDataImport]
ADD CONSTRAINT [PK_AggregatedProgressDataImport]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------