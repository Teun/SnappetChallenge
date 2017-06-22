# Challenge Sander Meijer

##Angular-FrontEnd
###Required: 
1. NodeJs V6.11.0

###How to run:
In the Angular front folder run the following commands:
1. `NPM install`
2. `NPM start`
If you wish to see if it works, you can browse to `http://localhost:4200`, if the NetCore-BackEnd is running it will show the data, if not, only the student overview is shown. To load the data, make sure the NetCore-BackEnd is running and refresh.


###What did I do:
Using Angular CLI I created a simple front-end showing some of the data being send from the Web API created in the NetCore-BackEnd. The `UserComponent` asks the `WorkResultService` for data and then creates multiple tabs showing the number of correct answers as well as the number of exercises of each of the students (users).

##NetCore-BackEnd
###Required: 
1. .NET Core version 1.0.1
2. Visual studio 2015

###How to run:
Open the project in Visual studio and simply run it. It should open on `localhost:5000/api/workresults` and present you with all the work results from the data.json file, formatted in a different DTO.

###What did I do:
The work.json is parsed by a .NET Core (version 1.0.1) web application. A controller exposes a single HTTP Get call that will return a JSON with in it a list of work results. Using the Facade pattern we hide the logic in another layer. The facade uses a repository to retrieve the data and map it into a DTO. 