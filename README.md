# Snappet Challenge

For this challenge, I have first imported the csv database into a MongoDb collection by using mongoimport tool.
Then, I created a lean and fast WebAPI using dotnet core 2.2 to query the database and added swagger endpoint to make users' lives a little easier. See below instructions and comments about my implementation.

## Running the web application
- Go to the Src folder of the repository
- Execute dotnet build
- Execute dotnet run
- on the console output, you should see the startup debug messages, followed by something like: StudentsAPI.WebApi> Now listening on: http://127.0.0.1:22004. This is your api url

## Querying the API
- Go to [api_url]/swagger
- There is currently only 2 available endpoint: workitems and progress

### workitems endpoint
- Retrieves raw items from the database matching specific criteria
- url: [api_url]/workitems (GET)
- Multiple filters are supported: UserId, Domain, SubmittedDateTime. You can pass zero or more filters
- Paging is also supported. Page size is 100 items.
- Note: to get workitems related to the domain "-", use the word Dash on the querystring param

### progress endpoint
- Retrieves progress for a specific user in a specific month
- url: [api_url]/users/{userid}/progress (GET)
- Required parameters: UserId (route), Year (query), Month (query)
- Optional parameter: Domain (query)
- Note: to get progress related to the domain "-", use the word Dash on the querystring param

## Future improvements
- Write proper API documentation to be available on both the codebase and Swagger
- Add Unit tests / Integration tests
- Add Authentication/Authorization
