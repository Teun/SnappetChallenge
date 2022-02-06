# Snappet Challenge

## Requirements:
    - .net 6
    - node (built with v.14.17.0)
    - ng has to be installed (built with v. 12.2.14)
        npm install -g @angular/cli
        if same version: npm install -g @angular/cli@12.2.14
## Setup:
    - Build entire solution;
    - If for some reason the database is not at the path src\Database\SnappetChallenge.db
        - Run SnappetChallenge.ImporterService;
            - This is going to build the database, based on the work.json file;
            - The whole import takes between 5-10 min, depending on your hardware;
            
> Note: I have added the SnappetChallenge.db file into the repository to make it quicker for you, as otherwise you'd have to generate it as explained above(it takes some time to import all the data from the json file provided). Otherwise, ofc, no database would be seen in the repository. Also, to make it simpler, as the database is small I decided to not use Git LFS.
## Running:
    - Have both projects running at the same time, from Visual Studio
        - SnappetChallenge.Api
        - SnappetChallenge-Front
            - This one takes between 5-10 min the first time, depending on your hardware as it downloads all npm packages;
![Setup](img/startup.png?raw=true "Setup")

> Note: SnappetChallenge.Api runs by default at http://localhost:5099. If you change it, make sure the environment.ts file is also updated in the SnappetChallenge-Front project.

## The development:

While building this solution it was never my intention to create a production ready solution, therefoe, many minor details were intentionaly left uncovered due to the constraint of time as well as I believe the purpose of this challenge is not to seek for perfection but instead measure my skills and coding style.

## The deployment:
Unfortunatelly I dont have an active AWS account, therefore I built the solution in a simple way so that it can be run easily in a local environment.

Now, although I haven't developed with AWS deployment in mind, IF I were to do so, here's how I would do and deploy it:
    - Have the SPA served as a static page from a S3 bucket;
    - Have the Api served from a Lambda function;
    - The data, could come from a DynamoDb table;
    - Have them all deployed via a SAM template(Cloud Formation Template).

Now considering running localy was in mind, Im using SQLite as the database in order to make it easier to work with the data. For that, there`s a small console appication, that imports the data from the json file into a SQLite table.
No caching, validation, authentication, authorization, tests(unit & integration) and other details were considered for this simple project for the reasons afore mentioned, but Im more than open to discuss it during the interview, if you want.

## The Task:
Since there was no explicitly defined requirement on what/how to display the data - just suggestions - I have decided to show a comparison between Today's progress vs LastWeek's average(total progress / 5 days) progress, in 2 (grouped)Column charts: by Domain and by Subject.
![report](img/report.png?raw=true "Report")
