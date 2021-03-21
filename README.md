# SnappetChallenge
My focus was more on the Database and Back-End sections. I create a MS-SQL Server database and import work.csv into it. All the reports and authentications are based on the Database.

### Technologies
I used C# Dotnet Core 3.1 for developing Back-End and MS-SQL Server 14 as database.
For developing Back-End I used these technologies:
- NSwag
- JWT
- NLog
- AutoMapper
- Dapper
- NUnit
- Moq

### Database-First
Although I have mastered on on EF Core and Code-First, I preferred Database-First for developing this code challenge. Of Course we could discuss more about this choice.

### How to run?
For running the solution please follow these steps:
- Create the database by restoring the 'DB.bak' file saved at the Data folder OR execute 'DB Script.sql' file saved at the Data folder.
- Set the database connection string at Snappet.API\appsettings.json
- Execute 'POST api/dbo/Teachers/Login' to get JWT using swagger UI or Postman. I have already inserted 3 records as Teacher user that you can find username/password from the bellow table.
- Execute 'GET api/Rep/SubmittedAnswers/ClassProgress' and placed the 'Authorization' key at header with 'Bearer <JWT>' value.
- Execute 'GET api/Rep/SubmittedAnswers/CarelessStudents' and placed the 'Authorization' key at header with 'Bearer <JWT>' value.

### How I imported work.csv into database?
I have imported work.csv by T-SQL. First I designed normalized tables based on the problem concept. Then develop step by step read and import data from work.csv file. I attached 'import csv file.sql' file at Data folder for your attention.
