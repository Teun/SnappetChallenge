-	Technologies and Tools : 
-	ASP.NET Core 2 
-	Entity Framework Core 2
-	AngularJs 1.6
-	Bootstrap 3.3
-	Jquery 2.2
-	NUnit 3.9
-	Moq 4.8
-	AutoMapper 6.2
-	Fluent Assertions 4.19
-	Visual Studio Community 2017
-	SQL Server 2012

How To :

1 - Change connection string to your local DB in appsettings.json
2-  Rebuild solution
3-  To migrate EF core code first follow those instructions https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations
4-  Run the DB-data.sql script to insert all data in tables
5-  Run all integrations tests to make sure that everything is up and running (change connection string in GlobalSetUp)
6-  Web App is ready.

