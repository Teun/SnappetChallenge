using Persistence;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CsvImport
{
	class Program
	{
		private const string Connection = @"Server=(localdb)\mssqllocaldb;Database=School;Trusted_Connection=True;";

		static int Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine("Argument missing: input file.");
				PrintUsage();
				return 1;
			}
			if (args[0] == "--drop")
			{
				DropDatabase();
				return 0;
			}
			string file = args[0];
			if (!File.Exists(file))
			{
				Console.WriteLine("The specified file was not found.");
				PrintUsage();
				return 1;
			}

			try
			{
				Console.WriteLine($"Importing from '{Path.GetFullPath(file)}'...");
				string tempFile = ReplaceNulls(file);
				Import(tempFile);
				File.Delete(tempFile);
				Console.WriteLine($"Done.");
				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"\nError: {ex}");
				return 2;
			}
		}

		private static void DropDatabase()
		{
			var builder = new DbContextOptionsBuilder<SchoolContext>();
			builder.UseSqlServer(Connection);
			using (var uow = new SchoolContext(builder.Options))
			{
				Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade db = uow.Database;
				Console.WriteLine($"Dropping DB if it exists.");
				db.EnsureDeleted();
				Console.WriteLine($"Done.");
			}
		}

		private static string ReplaceNulls(string file)
		{
			string output = Path.GetTempFileName();
			Console.WriteLine($"Preparing temporary file '{output}'.");
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Encoding e = Encoding.GetEncoding(1252);
			using (Stream s = File.OpenWrite(output))
			using (StreamWriter sw = new StreamWriter(s, e))
			{
				foreach (string line in File.ReadLines(file, e))
				{
					sw.WriteLine(line.Replace("NULL", ""));
				}
				sw.Flush();
			}
			Console.WriteLine($"File prepared.");
			return output;
		}

		private static void PrintUsage()
		{
			string usage = @"
Usage:
dotnet CsvImport.dll path/to/file.csv

-or-

dotnet CsvImport.dll --drop
This command deletes the database.
";
			Console.WriteLine(usage);
		}

		private static void Import(string file)
		{
			var builder = new DbContextOptionsBuilder<SchoolContext>();
			builder.UseSqlServer(Connection);
			using (var uow = new SchoolContext(builder.Options))
			{
				Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade db = uow.Database;
				Console.WriteLine($"Creating DB if it doesn't exist.");
				db.EnsureCreated();
				Console.WriteLine($"Creating temp table 'RawAnswers'.");
				db.ExecuteSqlCommand(@"
IF (SELECT OBJECT_ID('RawAnswers')) IS NOT NULL DROP TABLE RawAnswers;
CREATE TABLE RawAnswers
(
	[SubmittedAnswerId] INT NOT NULL PRIMARY KEY,
	[SubmitDateTime] DATETIME2(3) NOT NULL,
	[Correct] INT NOT NULL,
	[Progress] INT NULL,
	[UserId] INT NOT NULL,
	[ExerciseId] INT NOT NULL,
	[Difficulty] FLOAT NULL,
	[Subject] NVARCHAR(MAX) NULL,
	[Domain] NVARCHAR(MAX) NOT NULL,
	[LearningObjective] NVARCHAR(MAX) NOT NULL
);
");
				Console.WriteLine($"Importing data from CSV into RawAnswers.");
				// Don't care about the SQL-injection here.
				// It could be avoided via dynamic SQL.
				db.ExecuteSqlCommand($@"
-- NB. Must replace NULL values with empty strings before importing.
BULK INSERT RawAnswers
FROM '{file}'
WITH
(
	FIRSTROW = 2,
	CODEPAGE = 'ACP',
	FIELDTERMINATOR = ',',  --CSV field delimiter
	ROWTERMINATOR = '\n',   --Use to shift the control to next row
	TABLOCK,
	KEEPNULLS
)
");
				db.ExecuteSqlCommand(@"
-- SQL Server imports quoted strings with quotes. Trim manually.
UPDATE RawAnswers
SET LearningObjective=SUBSTRING(LearningObjective, 2, LEN(LearningObjective)-2)
WHERE LEFT(LearningObjective,1)='""' AND RIGHT(LearningObjective,1)='""'
");
				Console.WriteLine($"Importing KnowledgeDomains.");
				db.ExecuteSqlCommand(@"
INSERT INTO dbo.KnowledgeDomains ([Name])
SELECT DISTINCT Domain
FROM RawAnswers
");
				Console.WriteLine($"Importing Subjects.");
				db.ExecuteSqlCommand(@"
INSERT INTO dbo.[Subjects] ([Name])
SELECT DISTINCT [Subject]
FROM RawAnswers
");
				Console.WriteLine($"Importing LearningObjectives.");
				db.ExecuteSqlCommand(@"
INSERT INTO dbo.LearningObjectives ([Name], SubjectId, DomainId)
SELECT DISTINCT LearningObjective as [Name], s.Id as SubjectId, d.Id as DomainId
FROM RawAnswers ra
INNER JOIN dbo.Subjects s ON ra.[Subject] = s.[Name]
INNER JOIN dbo.KnowledgeDomains d ON ra.[Domain] = d.[Name]
");
				Console.WriteLine($"Importing Exercises.");
				db.ExecuteSqlCommand(@"
SET IDENTITY_INSERT Exercises ON

INSERT INTO Exercises (Id, Difficulty, LearningObjectiveId)
SELECT DISTINCT ExerciseId, Difficulty, o.Id
FROM RawAnswers ra
INNER JOIN dbo.LearningObjectives o ON ra.[LearningObjective] = o.[Name]

SET IDENTITY_INSERT Exercises OFF
");
				Console.WriteLine($"Importing Users. Assigning random names.");
				db.ExecuteSqlCommand(@"
SET IDENTITY_INSERT Users ON

INSERT INTO Users (Id)
SELECT DISTINCT UserId
FROM RawAnswers

SET IDENTITY_INSERT Users OFF

UPDATE Users
SET [Name] = 'User ' + LEFT(NEWID(),5)
");
				Console.WriteLine($"Importing SubmittedAnswers.");
				db.ExecuteSqlCommand(@"
SET IDENTITY_INSERT SubmittedAnswers ON

INSERT INTO SubmittedAnswers (
	Id, Correct, ExerciseId, Progress, SubmittedAt, UserId)
SELECT
	SubmittedAnswerId,
	IIF(Correct = 1, 1, 0) as Correct, -- Treat garbage like 3 as incorrect.
	ExerciseId,
	Progress,
	ToDateTimeOffset(SubmitDateTime, 0) as SubmittedAt,
	UserId
FROM RawAnswers ra

SET IDENTITY_INSERT SubmittedAnswers OFF
");
				Console.WriteLine($"Dropping temp table.");
				db.ExecuteSqlCommand(@"
DROP TABLE RawAnswers
");
			}
		}
	}
}