# Snappet Challange

Its is a sample application build using 
* Asp.Net Core 3.1
* MySQL
* Dapper
* MediatR

The architecture and design of the project is explained below


## Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
* [MySQL](https://www.mysql.com)


## Setup
Follow these steps to get your development environment set up:

## Create Database and Tables
* At the `/db` directory, there is a `Initialize.sql` file. Execute `Initialize.sql`  script in any executable environment like Workbench, Mysql cli etc. It will create `student` database, `answers` table and fill table with data.


# Back-end
## To Make Ready Web API

* You should specify mysql server, uid and pwd information in `appsettings.json` file at `StudentDbConnection` section.

  ```
  "ConnectionStrings": {
    "StudentDbConnection": "Server=;Port=3306;Database=student;Uid=;Pwd=;"
  }
  ```

* At the `back-end/src/Api` directory, restore required packages by running:
 
     ```
     dotnet restore
     ```
	 
* Next, build the solution by running:
 
     ```
     dotnet build
     ```	 
	 
* Launch the Web API by running:
 
     ```
     dotnet run
     ```	 
	 
* It should be hosted at http://localhost:5000

* Api documentation can be found at http://localhost:5000/swagger/index.html


### Run Unit Tests

1. To run tests go to each following directories
	
	`back-end/test/Data.Tests`
	
	`back-end/test/Service.Tests`

	then execute the line code below. 

	```
	 dotnet test
	```

### Architectural overview (knowledge of distributed services)

Application mainly consist of 3 layers. 
* **Api Layer** : Responsible to communication with clients.
* **Service Layer** : Basically where all the business rules live, be a mediator between data and api layer.
* **Data Layer** : Responsible to store and present the data.

* **Sdk Nuget Package** : Includes common objects that every microservice may need it. Like exceptions, entities, helper etc.


### Explanation of solutions
Application build based on microservice architecture. It's very performance, easy to extend and lightweight.

There are multiple IMediatr request in the project. `...ServiceRequest` prefix represent the things happening in the service layer, `...DataRequest` represent data layer responsibility.

#### TeachersController
HttpGet `TeachersController/dashboard`
GetTeacherDashboard action creates an instance of GetTeacherDashboardServiceRequest. By using IMediatr interface's send metod it dispatch to GetTeacherDashboardServiceRequestHandler.
Every business logics perform here if everything goes well it communicate with data layer with anohter Mediatr request which is GetTeacherDashboardDataRequest. This request get handled by GetTeacherDashboardDataRequestHandler.
Sql queries executes by dapper extension metods as async and this handler returns data to service layer and than api layer.

#### StudentsController
HttpPost `StudentsController/overview`
GetStudentsOverview action creates an instance of GetStudentsOverviewServiceRequest. By using Mediatr's send metod it dispatch to GetStudentsOverviewServiceRequestHandler.
Currently there are not much business rules in service handler, in real life example we may wanted to perform business rules in this place. The service layer then talk with data layer receive required data conver to proper model and present to api later.

#### Test Strategy
In general there should be unit, integration, manual, automation, performance tests. I focused unit tests. Unit tests have been written for service and data layer.
For unit tests i used `AAA` approach and mocking.


#### Used tools and libraries

* Dapper 2.0.78
* FluentValidation 9.5.3
* FluentValidation.AspNetCore 9.5.3
* MediatR 9.0.0
* MediatR.Extensions.Microsoft.DependencyInjection 9.0.0
* Microsoft.Extensions.DependencyInjection 5.0.1
* MySql.Data 8.0.23
* Swashbuckle.AspNetCore 6.1.1
* Microsoft.NET.Test.Sdk 16.5.0
* xunit 2.4.0
* xunit.runner.visualstudio 2.4.0
* coverlet.collector 1.2.0


#### Key Concepts
* **Dapper** : I choose Dapper over Entity Framework or Nhibernate because of performance. Dapper is very usefull and lightwight.
* **Mediatr** : Supports request/response, commands, queries, notifications and events, synchronous and async with intelligent dispatching via C# generic variance.
* **RequestValidationPipelineBehavior** : It's a Mediatr pipeline behavior. It get executed while request is dispatching to handler. If any rule not satisfied then it throw exception.
* **CustomExceptionHandlerMiddleware** :  Global exception handler. It stands top of the Http request pipeline. Everything is operated inside it if any error happen it catch.
* **Sdk** : The intention of this layer is serve it as a nuget package in real life example. Thereby it can be used by other microservices. For simplicity I left it as a class library.
* **Swagger** : For api documentation I used swagger. It can be accessed at http://localhost:5000/swagger/index.html. Default page of api is bring you to swagger page.
* **Dependencies** : Each layer is responsible to register its dependencies by ServiceCollectionExtensions.

# Front-end
This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 10.0.7.
Perform following instructions at the root of the application directory which is: `/front-end`

## Development server

* At the `/front-end` directory, install node modules by running:
 
     ```
     npm install
     ```
   
* Launch the front-end application by running:
 
     ```
     ng serve
     ```   

* It should be hosted at http://localhost:4200


#### Used tools and libraries

* Angular Material 11.2.6
* Angular Cli 10.0.7


## Descoped features

The goal of the project to have topics for the discussion on an interview and to not implement full blown solution for a specific domain. That way some features are not implemented now, but should be applied for a real situation. This list could be used as a check list for a real project but not limited.

**Authentication** : `OAuth2`, or `JWT` is good candidate to implement authentication. And of course, we should not forget about authorization logic.

**Docker containers** : It's pretty easy to run UI and backend in a containers. Especially, if we use `.NET Core`.

**Route guards** - Angular feature that can warn a user that before doing important or irreparable actions.

**Configuration** : Sounds obvious, but I saw big projects with hard coded magical constants and it was sad.

**Message queues** : Commands and queries don't have to be processed in one backend process. Using [RPC](https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html) we can use messages even to request data.

**Dapper** : Very good micro ORM, good candidate to implement commands processing.

**Global exception handler** : No exception should stay untracked. I like log into `Kibana` using `Serilog`.

**Background Jobs** : Many project requires to use backgorund jobs. `Hangfire` would be great candidate for it.

**Monitoring & Alerts** : Every projects must have to monitoring, healt checks and alert managements. For this purpose I like to use `Datadog`, `Grafana`, `NewRelic`, `CloudWatch`
