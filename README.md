
## About the project
 ### Backend:
 - Asp.net core 2
 - Entity Framework Core 2
 
 ### Frontend:
 - Angular 4
 - Redux
 
 ### Patterns
 - SOLID
 - Unit Of Work
 - ~~TDD~~ (*Code prepared to TDD but not implemented in reason of Challenge time recomendation*)
 
 ### Database
 - SqLite
 
## How to run
 - Open the project in Visual Studio 2017 
 - Select the Nicollas Configuration Profile 
 > Right click on **Nicollas.Web** > Properties > Debug > Profile > Select **Nicollas**
 
 OR 
 
 > Beside the Debug, Any CPU, Change **IIS Express** to **Nicollas**
 - Run
 
## Extra
 - Default credentials: User **Admin** Password **$naPPe1**
 - I also did a video explaning the code here: https://youtu.be/Tve9RwECQBA (7 mins)
 - Custom Seeder implemented, called at *Nicollas.Web.Program.cs*, Implemented at *Nicollas.SqlServer.NicollasDbInitializer.cs* looking for seeders that implement the *ISeeder* at *Nicollas.SqlServer.Seeders*
 - the SqLite database was uploaded together in this repository to make it faster to test. If wanted, you can delete the file **snappet.db**, the system will detect the change and recreate and seed the database after restart.
 - you can maually recreate the database running `Update-Database` on Package Manager Console with default project set to *Nicollas.SqlServer*
 - The wwwroot was included in the git to make it faster to test, but you can rebuild the application running `npm Install` and then `ng build` inside the folder *Nicollas.Web/Angular* 
