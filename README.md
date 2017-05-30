# SnappetChallenge
### So, What is in here?
This is Angular2 SPA app on ASP.NET Core.

### What you will need to run this solution
1. dotnet core
1. node
1. SQL Server or SQL Express

### Setup (Windows)
1. Install dotnet core sdk https://www.microsoft.com/net/core#windowscmd
1. Install NodeJs 7 https://nodejs.org/en/download/current/ 
1. Install SQL Express https://www.microsoft.com/en-us/sql-server/sql-server-editions-express
1. Install SSMS https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms, if you dont have visual studio
1. Clone this repo
1. Go to ```src/Snappet.Web``` and open powershell with path this folder.
1. Run ```dotnet restore```.
1. Run ```npm i ```.
1. Run ```npm i -g webpack```.
1. Run ```webpack --config webpack.config.vendor.js```.
1. Extract content from ```backup.zip``` which is located in ```backup``` folder.
1. If you have SQL Server on your machine, that's fantastic. Grab a backup from ```backup``` folder and restore database from ```SnappetChallange.bak``` file and run ```dotnet run```. If not, continue with next steps.
1. Run ```dotnet ef database update``` from the same path as at step 6.
1. Import all storage procedures into SnappetChallange database from ```StorageProcedures``` folder,  which you extracted from ```backup.zip```. If you have Visual Studio installed with SQL tools or SMSS installed, connect to the database and execute storage procedure file content as normal queries.
1. Finally. Run the app. ```dotnet run```. It will seed some data into database at the startup, be patient.
1. Browse http://localhost:5000
