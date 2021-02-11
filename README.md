# Project Info

I tried to keep project as simple as possible to spend more time on code and project quality. I didn't spend lots of time on the project.

## Build

The project is created with Visual Studio 2019, feel free to open the solution file and run the whole solution with docker-compose in side Visual Studio.

*The front app is created in different approach, you don't have it in the solution*

The docker-compose automatically build all containers (backend, frontend, db) and run them.

** I recommand to run the project and docker-compose with Visual Studio. **

You can run the docker-compose from the command-line as well:

```
cd ./SchoolMaster
docker-compose -f "./docker-compose.yml" -f "./docker-compose.override.yml" build
docker-compose -f "./docker-compose.yml" -f "./docker-compose.override.yml" up
```

I didn't implementW [ait-for-sh](https://github.com/vishnubob/wait-for-it) to make sure the frontend and backend runs after SQL Server has started the service. So, please ocne you run the project (by dompose-up in command line or vs) wait for like less than a minute and SQL Server will start completely. 

### Service URLS

Frontend: http://localhost:8081
Backend: https://localhost:444/swagger

## Tools, Tech, Frameworks, etc.

Main tools and platforms:

1. .NET 5
2. SQL Server 2019 (docker, develoepr image)
3. VueJS

Libraries:
1. Automapepr
2. xUnit
3. FluentAssertions
4. EntityFramework Core

## Tests
I only managed to write unit tests for the backend, unfortunatelly it's limited to `UnitTests`, but this was my wish list for testing part:

1. Integration Test
2. API Testing with Postman and newman (part of the pipeline)
3. e2e testing with Cyprress for the frontend

For the unit tests, you can find Fixtures and Tests inside tests project.

## Database and data strucure
I spent some time to analyze the data to try to make a conceptual and analytical model from Works data source. For example the relation between difficulty and progress, relation between the progress and correct. Due to lack of the time and I think lack of the data (because it's just a simple data with processed records) I decided to let the data as is and try to make some useful report insight from it, to make a very simple dashboard for the teacher.

* I imported the CSV file to SQL Server and I defined the SubmittedDate column as DateTimeOffset with UTC timezone.
* To make the project a bit funny, I created a fake Users table that has some random fake users with userIds extraced from Works data source.
* The database is a SQL Server 2019 database, to make to running it simple for you I did a dirty job (hate to say that). I defined a volume folder of `data` and mapped it to SQL Server `data` directory in the docker container and commited all databases such as system database master, tempdb, etc. **I know this is not correct way of doing this, this was just for make things easier**.
In the real word scneairos, I prefer to have import scripts, migrations, or even custom create `SQL Server` docker image that attach an image from a directory.

## Project structure and architecture
Project arch is simple and straighforward 3-layar. You can easily find repositories, datamodels, Dto's, services, controlelrs, etc inside the project.

Other ideas?
I had some ideas to do something cool with the `Works` data source, at first I considered it as a source of events, and I thoguht to impelement the application with event sourcing. 

A micro-service that : Simulate event sending from Works
A micro-service that : Receives the messages, translate and anaylize them, store them in different storages for better use. I thoguht about some document based NoSQL data bases such as Cosmos or even RDBMS.
A micro-service that : Feeds the client app from the proccessed data

Or a scenario close to what I described with MediatR pattern.

I also thought to re-model the data for document-based NoSQL, but still prefered RDBMS.

## Frontend App
I haven't beend working with Angular (2+) for a while. There was a learning curve + some study time (which I would love to spend) but I didn't have enough time so I used Vue (2) as my frontend library.

I usually create my own webpack configuration but to save some time on other things I used Vue CLI (didn't try to reinvent the wheel this time) to scaffold the frontend project with all webpack, babel and loaders settings.

* The project is written with ECMAScript. 
* For UI compoment, I used Bootstrap VUE (because it's simple as stupid), but I prefer Vuetify (something close to Angular Material)
* I used Vuex (something like Redux), a single source of truth for my small application.
* I used Axios for Http requests, still to make things simple stupid I stick to simple restful services. I thought about gRPC, GraphQL but I think those were overkill for my project.
* I splitted the application to many componenets, it's not perfect but I prefer to decouple things to have small working components.


## Wish List?

1. I was thinking to work on accessibility, because the current score from Chrome Lighthouse for Desktop is 88, which is not good enough. In terms of accessibility the minimum acceptble score should be 100.
2. I was thining to implement API testing with PostMan
3. I was thinking to deploy the project from GitHub actiosn to Azure
4. e2e testing with cypress
5. Testing vue components
6. Better docker-compose image to make the project less dependant to VS (I creted docker-compose with VS)






