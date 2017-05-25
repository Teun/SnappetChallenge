# SnappetChallenge Mark van Miltenburg

### Instructions before running
The data file work.csv should be copied to the c:\temp\ on the pc where the solution will be started.

### Structure/Tools
After creating a SQL Server instance in AWS(private, but free account) but failing to do bulk inserts, I decided to use a nuget package to convert the cvs file to a datatable on the fly.

The solution contains a RESTful WCF service which will provide the data in JSON format.

The TutorOverview html page uses jquery to retrieve the required data from this WCF service.

The landing page shows a table with the sum of the progress per student(userid) per domain. This way the teacher has nice overview of the total progress a student has made in a certain domain.
After clicking on a table row the individual exercises of that domain will be shown.
The back button (bottom of page) is used to go back to the overview page.

