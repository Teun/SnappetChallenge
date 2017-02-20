# README #

### What is this repository for? ###

* Snappet technical assignment

### Architecture description and notes ###

This is a sample application that processes a live feed of data generated based on the given data.json file. The data generator sends very quickly the past data until it arrives to
the "current date". From this point, the generator sends the data based on the time in each record in the sample data. As there are many old values, it is possible to choose to start 
the data stream just a few days before the current date. To do so, change SendPastDays in the app.config of the generator.host project.

The application has 2 microservices, for "simplicity", but there could be 3:
* Data recorder: this stores the data stream on a permanent store (not done for simplicity)
* TopStudents: 
   * This calculates the ranking of the students that achieved the maximum difficulty per day and per month
   * Day Summary. This stores a summary of data for the whole classroom every day. This could be on a separate microservice.
   
The TopStudents microservice provides a web api for querying data and a file server to serve a client application commponent. There is a very simple "application component", 
which is an html file with a small Knockout application which queries the DaySummary api every 3 seconds and displays the records.
The TopStudents api is prepared to implement push notifications to the client application with SignalR, based on domain events, but the SignalR part is not implemented.

The Data Recorder microservice doesn't provide an api. 

Events are used to communicate between microservices, except for the data generator which sends a command to the data recorder.
  
NOTE 1: clicking on the console windows pauses the processing of messages. This allows to read the logs. You need to press ENTER in order to resume the processing. As it's a queue
system, messages will accumulate and won't be lost if an endpoint is paused.

NOTE 2: If you want to stop and restart the application, you should recreate the DBs to start from empty db. Note that every time you start the generator it will start sending data from the beginning.

### How do I get set up? ###

* You'll need a valid NServiceBus license to run the application. Unfortunately, I cannot sent mine. The simplest way to get a license is to install the Particular Platform from https://particular.net/downloads 
* Create the databases. Use "Recreate Dbs.sql"
* Open the solution in VS
* Set up dbs:
	* Configure the 5 connection strings in the SharedConnectionStrings.config
		* Replace MACHINENAME for the actual name of your computer (this is to allow running the solution in multiple computers without overwritting each others connection strings)
		* Set the Data Source field to your SQL Server server name
	* Execute the following in the Package Manager Console: update-database -ProjectName snappet.test.topstudents.data -startupprojectname snappet.test.datagenerator.host
* Compile the whole solution
* Execute install.bat. This will run NServiceBus installers and create the queues and other tables in the databases
* Once the install has completed, close the window and execute Run.bat. This will run the 4 microservices in console applications. 
	* You will see the data generator endpoint sending past data very quickly and when the "current date" arrives, the data will be sent at the intervals specified in the data source
* Open the following in a web browser: http://localhost:60000/ This is meant to be a sample of a component served from the microservice that produces the data and to be injected into the main application
* Open the following in a web browser: http://localhost:60000/swagger
	* You will see the TopStudents api documentation where you can query the live data. Depending on the query, you can repeatedly execute it and you will see the data changing

### Who do I talk to? ###

* Francesc Castells
* fcastells@dgtexperts.com