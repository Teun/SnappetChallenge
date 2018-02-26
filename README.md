# SnappetChallenge Overview
Dependencies
FileHelpers.. used for processing large files 
Dapper .. Data mapper used for efficient database insertion and selection.
Bootstrap -- Responsive UI design
Fontawesome -- Icons and Fonts
File Format Processed - Work.csv

## Solution Structure

###Snappet (Website) 
Implementation of Web Application and  APIs. 
Depends on. 
* Core
* Repository 
* Services 

### Snappet.Core
Entities that will be used accross the entire solution are kept here.
they are also home to Utils, Enums and Constants. To avoid cyclic redundacy, I ensure this project doesnt depend on any sub project in the solution stack but may depend on external libaries.

### Snappet.Services
This layer focuses on Business logic, Crypto Services, File Parsing, API calls and generally Data Checks.
Depends on 
* Core 

### Snappet.Repository
This layer focuses on data manipulation, from and to the Data storage which in this case is SQL Server.
its very good to have this kind of arrangement because if there is a need to switch Datasource to say a non-sql or an Oracle.
the entire soltion will not be affected save for the this layer.
This project depends on 
* Core 

### Snappet.Test
this is very expenditent especially if one is using SOLID principle because it is expected that methods and services possess 
single responsibility alongside been potentially testable.
Depends on 
* Core 
* Services 
* Repository 

### DB Project
Most often times, custom stored procedures, functions, tables and generally DB object can poise alittle challenge during deployment
not as one isnt too sure if something wasnt checked or hasnt been deployed.
This is the reason I prefer to use this to manage all db resources and even more, all that is required to create all the db resources for a given
project is to publish selecting various profiles. ie. Test, Sandbox or Production including detachable dbs!
This project the is also very helpful as it scans for dependencies and alerts should something be missing before deployment.


### Data ETL 
Importation: Currently used SqlBulk Insert making the path to the stored file configurable should the
solution be shipped to a different server or OS all together.
Was intiially going to use Sql Server Integration Service(SSIS) to import the data using File Task and possibly C# script but 
discovered that the data was in pure form and will not require any transformation before insertion into the database.
Dapper is been used as it helps cut the time spent on parameter mapping, either during data insertion or retrieval.

### How to setup  the project and Import Our Data..
You are required to first run the schema migrations in the db project or better still publish the db project first.
Once you are done, you will have successfully deployed the db scripts and tables respectively.

I have created a Bulk Upload Integration Test in the Test Project.. 
This test is able to load and dump the data into the database using SqlBulk Insert.
Although the path to the file is configurable for this project, I have kept a copy in the App_Data folder (Main Web Flow),
and Another in a resource folder in the Test Project's Bin folder.

The file used is the work.csv version, I differ to this because it was lighter, and it woulnt require additional dressing especially
seen that I could get a library that could parse it nicely and very fast.
 
- You can now deploy it on IIS using the integrated pipeline application pool. 

### Some Extras:
- Application Logs
- Application Settings
- Caching
- Integration Test
 
### Few Constraints
 I didnt use knockout as earlier intend because its been a while I used it and seen that I didnt have enough time to revisit
 so I just used ASP MVC Razor views instead. 
  
  But the project is fully knockout.js ready. 
