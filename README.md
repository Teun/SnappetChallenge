# SnappetChallenge

The proposed solution is a serverless application built with AWS services (S3, Lambda, DynamoDb and API gateway).

### Scope
There is no front-end, only RESTful API
It only runs in the AWS cloud, currently not possible to run locally


### Architecture
The focus is query speed. Whatever is possilbe to pre-calculate is calculated as soon as data is available.
JSON file is considered the "raw" input. As soon as the file is uploaded to S3 it's processed by a C# lambda and the data is stored in DynamoDb optimized for reading/querying.
API gateway allows fetching of raw items as well as summary per date. It's connecting directly to DynamoDb without need of any compute logic in between.

![alt text](https://raw.githubusercontent.com/dennis3001/SnappetChallenge/master/Challenge.png)




### How to run it
It has to run in an AWS account. All the infra is implemented as infra-as-code so it can be installed in any account identically. 
See the video how: [https://www.youtube.com/watch?v=OYJPDYIErQ8](https://www.youtube.com/watch?v=OYJPDYIErQ8)

- Package the lambda function using *dotnet lambda package -f netcoreapp2.1* command when you are in Src/Snappet.TeachersPortal.DataImporter folder
- Upload the zip package to any S3 bucket in your account
- Create Cloudformation stack from template located in Infra/app.yaml. Specify the name of the bucket where lambda package is uploaded in the parameter
- Upload work.json data file to the S3 bucket that is part of the stack (snappet-report-upload-****)
- Verify that DynamoDb tables were populated
- Check the API endpoint by navigating to API Gateway -> snappet api -> stages -> api
- Open 3 URL types and check the result, e.g: [Get raw work item by id](https://wdjpiwun63.execute-api.eu-west-1.amazonaws.com/api/work-items/2396638), [Get raw work items by date](https://wdjpiwun63.execute-api.eu-west-1.amazonaws.com/api/work-items?date=2015-03-02), [Get summary data by date](https://wdjpiwun63.execute-api.eu-west-1.amazonaws.com/api/work-summaries/2015-03-02)


