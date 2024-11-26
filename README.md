# Snappet Coding Challenge

This is an example solution based on the snappet coding challenge.

The solution exposes an API allowing the teacher to retrieve progress information for a given classroom and date.

This solution is scaffolded based on the AWS Lambda ASP.NET Core Web API template, found on the Amazon.Lambda.Templates namespace.
The initial dataset is found in the Data folder, work.json.
The dataset is imported into an EF core InMemory database.

### Public API ###

The API is available publicly at the following URL:
https://n7d2hzb5th.execute-api.us-east-1.amazonaws.com/Prod/api/classroom/10/2015-03-19%2010%3A30%3A00
The date can be changed, it is currently set to "Tuesday 2015-03-24 11:30:00 UTC" as specified in the challenge

### Running Locally ###

1. In your terminal window, browse to src\SnappetChallenge.Classroom.Api directory.
2. Execute "dotnet run"
3. You can then open a browser and point to http://localhost:5000/api/classroom/10/2015-03-19%2010%3A30%3A00

### AWS CloudFormation Deployment ###
The cloudformation template can be found at src\SnappetChallenge.Classroom.Api\template.yaml
By installing AWS toolkit for either Visual Studio or Rider, you can right click this file and deploy with your setup credentials.