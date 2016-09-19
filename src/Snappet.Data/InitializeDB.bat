del Migrations\*.cs
del snappet.db
dotnet ef migrations add MyFirstMigration
dotnet ef database update
::pause