# How to run the application
This project has two folders
1. SnappetApplication - Which is the frontend application using Angular 7. I have used AgGrid for grid and CanvasJs for showing the graphs.
2. SnappetServices - Which is the backend application using Dotnet Core 2.2. You need to install [Dotnet Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)

* To run frontend application please refer to readme in SnappetApplication dir. Note that all the commands are to be run in context of SnappetApplication directory
* To run backend application, open the solution (SnappetServices) in Visual Studio 2017 or above and run the solution. Although the port on the backend is set in the launch settings, if the backend runs on port other than 1204, then change the proxy.localhost.json in the frontend application to match the port and restart the frontend application.

# What is the purpose of the application?
1. This application focuses on the visualization of data over technical aspects like using a Database. Showing data in graphical view can be used in more analytical way for anyone looking at the data.
2. The default route of the application shows the summary of the students as of today to the teacher. When the teacher clicks on one of the bar graph lines it routes to results/:id which shows the details for that specific student.
3. On the summary the teacher can see the overall performance of the class, whereas in the detail screen, the teacher can see the performance of a student based upon subject. The teacher can also view the details of each exercise completed in the grid below and dig into details using the filters and sorting of the grid. 
4. A lot more can be done if more contextual data is provided, for e.g how does difficulty affect the data,  How does domain affect the data, how many exercise are available for the student, etc.

# Technical Aspects covered
## Frontend
1. Angular
2. Routing
3. Navigation
4. Bootstrap
5. Chart.js
6. Component, Service, Module, Directive
7. Basic Unit Testing

## Backend
1. WebApi
2. Controller/Repository/Service
3. Automapper
