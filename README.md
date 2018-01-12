# SnappetChallenge
The SnappetChallenge application is a Full Stack application consists of Back-end (ASP.NET MVC4 Web API) and a Front-end designed in AngulaJs1 and BootStrap. Back-end provides data to front-end in JSON format using REST API calls and MS-SQL to store data.

### Environment

- FrontEnd: AngularJS v1.6,  Bootstrap 3, JQuery
- Backend : ASP.NET MVC4 Web API,  EntityFramework 5.0, LINQ, NInject.
- Database: MS-SQL

### Solution Overview
The application provides a dashboard where Teacher can see the class's progress on Learning Objectives for a selected date in table format. For each of the  Learning objectives, teacher can see the following:
- Number of Students participated to work on a learning objective.
- Number of exercises that students worked on that day.
- Overall performance for the Learning objective like Good, Excellent or Poor.
- Percentage of students who mastered on those exercises. 

Teacher can also see a 'Report Summary' and 'Student progress' report (on the right) by clicking on any of the Learning Objectives link in main report.

![Report_Image](https://github.com/yadurajshakti/SnappetChallenge/blob/master/SourceCode/ReportDashboard.PNG)

### Run the Solution
The solution is designed in Visual Studio 2012 and uses EntityFramework Code First approach. 
The application will load data from 'work.json' located in App_Data folder, at the time of database migration. 
* Open the project in Visual Studio 2012.
* Restore dependencies from NuGet Package Manager.
* In Web.config, use "DataSetLimit" appsetting to set the limit of data you want to populate through data migration or leave empty to load all data from work.json presented in App_Data folder.
* Open NuGet package manager console and Run 'Update-Database'.
(Remember that  it may take a while to seed the data from work.json, use "DataSetLimit" to load less data).
* On successful database migration, a table 'dbo.Works' in your local database should be created with pre-populated data from 'work.json'.
* After setup and migration is completed, You can run both front-end and back-end application together in Visual Stduio 2012 using Start.

   - Frontend should be available on URL: http://localhost:1096/
   - BackEnd should be available on URL: http://localhost:2225/


*Note: The frontend app (Snappet.Client) uses back-end URL which is defined in a constant service called "appSettings" in ./common/common.js

### Thank you

