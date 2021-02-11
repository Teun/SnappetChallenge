# Project Info

I tried to keep the project as simple as possible to spend more time on code and project quality. I didn't spend lots of time on the project.

## Build

The project is created with Visual Studio 2019; feel free to open the solution file and run the whole solution with docker-compose inside Visual Studio.

*The front app is created in a different approach; you don't have it in the solution*

The docker-compose automatically build all containers (backend, frontend, DB) and run them.

** I recommend running the project and docker-compose with Visual Studio. **

You can run the docker-compose from the command-line as well:

```
cd ./SchoolMaster
docker-compose -f "./docker-compose.yml" -f "./docker-compose.override.yml" build
docker-compose -f "./docker-compose.yml" -f "./docker-compose.override.yml" up
```

I didn't implement [wait-for-sh](https://github.com/vishnubob/wait-for-it) to ensure the front-end and backend runs after SQL Server has started the service. So, please once you run the project (by compose-up in command line or vs), wait for less than a minute, and SQL Server start completely. 

### Service URLs

Frontend: http://localhost:8081
Backend: https://localhost:444/swagger

## Tools, Tech, Frameworks, etc.

Main tools and platforms:

1. .NET 5
2. SQL Server 2019 (docker, developer image)
3. VueJS

Libraries:
1. Automapepr
2. xUnit
3. FluentAssertions
4. EntityFramework Core

## Tests
I only managed to write unit tests for the backend. Unfortunately, it's limited to `UnitTests,` but this was my wish list for the testing part:

1. Integration Test
2. API Testing with Postman and Newman (part of the pipeline)
3. e2e testing with Cypress for the frontend

For the unit tests, you can find Fixtures and Tests inside the tests project.

## Database and data structure
I spent some time analyzing the data to try to make a conceptual and analytical model from Works data source. For example, the relation between difficulty and progress, the relationship between progress and correct. Due to lack of the time and lack of data (because it's just simple data with processed records), I decided to let the data and try to make some valuable report insight from it, to create a straightforward dashboard for the teacher.

* I imported the CSV file to SQL Server, and I defined the SubmittedDate column as DateTimeOffset with UTC timezone.
* To make the project a bit funny, I created a fake Users table with some random fake users with users extracted from Works data source.
* The database is a SQL Server 2019 database; to make running it simple for you, I did a dirty job (I hate to say that). I defined a volume folder of `data` and mapped it to SQL Server `data` directory in the Docker container and committed all databases such as system database master, tempdb, etc. **I know this is not correct way of doing this, this was just for make things easier**.
In the accurate word scneairos, I prefer to have import scripts, migrations, or even custom create `SQL Server` docker image that attach an image from a directory.

## Project structure and architecture
Project arch is simple and straighforward 3-layar. You can easily find repositories, datamodels, Dto's, services, controlelrs, etc inside the project.

Other ideas?

I had some ideas to do something cool with the `Works` data source, at first I considered it a source of events, and I thoguht to impelement the application with event sourcing. 

- A micro-service that: Simulate event sending from Works
- A micro-service that: Receives the messages, translate and anaylize them, store them in different storages for better use. I thoguht about some document based NoSQL data bases such as Cosmos or even RDBMS.
- A micro-service that: Feeds the client app from the proccessed data

Or a scenario close to what I described with MediatR pattern.

I also thought to re-model the data for document-based NoSQL, but still preferred RDBMS.

## Frontend App
I haven't been working with Angular (2+) for a while. There was a learning curve + some study time (which I would love to spend), but I didn't have enough time to use Vue (2) as my frontend library.

I usually create my own webpack configuration but save some time on other things I used Vue CLI (I didn't try to reinvent the wheel this time) to scaffold the frontend project with all webpack, babel, and loaders settings.

* The project is written with ECMAScript. 
* For UI compoment, I used Bootstrap VUE (because it's simple as stupid), but I prefer Vuetify (something close to Angular Material)
* I used Vuex (something like Redux), a single truth source for my small application.
* I used Axios for Http requests to make things simple stupid I stick to simple restful services. I thought about gRPC, GraphQL but I think those were overkill for my project.
* I splitted the application to many componenets, it's not perfect but I prefer to decouple things to have small working components.


## Wish List?

1. I was thinking to work on accessibility, because the current score from Chrome Lighthouse for Desktop is 88, which is not good enough. In terms of accessibility the minimum acceptble score should be 100.
2. I was thining to implement API testing with PostMan
3. I was thinking to deploy the project from GitHub actiosn to Azure
4. e2e testing with cypress
5. Testing vue components
6. Better docker-compose image to make the project less dependant to VS (I creted docker-compose with VS)






