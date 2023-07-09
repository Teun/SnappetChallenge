# Snappet Challenge by Caio Della Libera

This has been a fun challenge to do! The challenges's description can be seen below. 

It took me about 16 hours to make.

For the solution, I tried using a few approaches:

- Use the job's stack as seen in the job description (AWS, Angular, TypeScript)
- Use IaC and CI/CD (CloudFormation and Github Actions) to have the project as automated, scalable, versionable, and consistent as possible
- Minimum configuration needed
- Using serverless (benefits of "inifite" scalability, less config, and no costs for idle time). I used Serverless Framework to facilitate the provisioning of resources, which is just an abstraction for CloudFormation

The result is you can run the project on your AWS account simply by configuring AWS secrets in your Github repo and doing a push to master branch.

## Usage 

1. Have an AWS account
2. Fork the repo
3. In the repo, go to Settings > Secrets and variables > Actions and add your `AWS_ACCESS_KEY_ID` and `AWS_SECRET_ACCESS_KEY` as repository secrets.
4. Push something to master branch. Within a few minutes your Angular project stored in your S3 bucket should be able to query your DynamoDB tables and show the students' answers
5. Get the app's URL on your client-app bucket's properties on AWS console.

## Solution Rationale

### Infra/backend

The problem starts with two files containing the same data, but in different formats: `.csv` and `.json`. For the sake of this challenge, `.json` was chosen. (Both could be implemented with a bit more time).

The data is an array of answers from a set of students in a month. Each Object is of the following format:

```json
{
  "SubmittedAnswerId":2395278,
  "SubmitDateTime":"2015-03-02T07:35:38.740",
  "Correct":1,
  "Progress":0,
  "UserId":40281,
  "ExerciseId":1038396,
  "Difficulty":"-200",
  "Subject":"Begrijpend Lezen",
  "Domain":"-",
  "LearningObjective":"Diverse leerdoelen Begrijpend Lezen"
}
```

I considered that this kind of data would be getting to the system in a high volume, since each student of each class submit lots of answers each day.

I had a few options of choice to which database to choose from: DynamoDB, Aurora, RDS.

Due to scalability benefits, and also because I didn't know the underlying relational model (if there was one) of the data, I chose DynamoDB.

I modeled the table in a way that results could be partitioned by date (and therefore efficiently queried by also by date). I used day as partition key.

All of the resources definitions are inside [serverless.yml](infra/serverless.yml). Here's the table definition:

```yaml
AnswersTable:
  Type: AWS::DynamoDB::Table
  Properties:
    TableName: ${self:custom.tables.answers}
    AttributeDefinitions:
      - AttributeName: yyyy-mm-dd
        AttributeType: S
      - AttributeName: SubmitDateTime
        AttributeType: S
    KeySchema:
      - AttributeName: yyyy-mm-dd
        KeyType: HASH
      - AttributeName: SubmitDateTime
        KeyType: RANGE
    BillingMode: PAY_PER_REQUEST
```

I also needed storage for the original `.json` file. I used an S3 bucket: `AnswersBucket`. The `PutObject` operation in that bucket triggers a [Lambda function](infra/src/create/answers.ts) execution, which would then populate the DynamoDB table.

Once the table is populated, the first step is to define a REST API from which the client app can get the answers items. The API is hooked to [another Lambda function](infra/src/read/answers.ts) with API Gateway. I decided to use API Gateway's caching as well, since running Lambdas and querying the DynamoDB table constantly could bring high costs. API Gateway's cache is charge by hour, which is not ideal for a serverless application, so this could further improved with more time. One simple yet not-optimal solution would be to use Lambda's `/tmp` storage instead, which would still have the costs of running Lambda, but now the costs of hitting DynamoDB.

### Frontend

With the infrastructure ready, it is time to build the Angular app. Having never worked with Angular before, I found very interesting to see how it is different from React. Apparently more robust, with more boiler plate code and a powerful CLI, it certainly was interesting to work with, and I hope I can develop myself even further with it at Snappet! :D

My app ended up being quite simple, with just a single component. I would have loved to work more on it but this is what I was able to achieve with limited time.

The app allows the teacher to choose to show results from today or the current week. The data is fetched inside `ngOnInit()` lifecycle hook. The app displays a list of students, which the respective Learning Objectives they had, and for each objective, the answers that were submitted. 

I figured the teacher would be most interest in seeing how each student are developing themselves within a certaing learning objective. Because mostly every student has their own needs. Surely, however, it would have been best to give the teacher more visualization options and features.

The app is hosted on another S3 bucket, defined on [serverless.yml](infra/serverless.yml).

S3 is a popular choice for hosting SPA on AWS, so this is why I chose it. It is also highly scalable and does not require a lot of configuration - following the choice of doing the challenge with serverless.

One stuggle that appeared was that the API Gateway REST API endpoint could not be inserted into the bucket when the resources were being created. So during de CD pipeline, I had to capture the endpoint address output from the CloudFormation deployment, insert it to the Angular project as an env variable, build the Angular project, and then put the build files into s3. Quite the ride but it ended well. This can be all seen in the [Github Actions CI/CD pipeline script](.github/workflows/deploy.yml).

Another S3 pain I had was that I couldn't define the buckets' names statically, because S3 bucket names are unique across different accounts. So I had to capture the API Gateway Id, which is generated dynamically for each deployment and use it to name the buckets. Without that, Snappets' engineers wouldn't be able to deploy the buckets to test my solution.

--------------------------------------
Original README.md below

--------------------------------------

### SnappetChallenge
At [Snappet](http://www.snappet.org), we care about data and we care about code. When we interview for development positions, we want to see code and we want to discuss code. That's why we want candidates to show some work on our challenge. This challenge is not meant to cost you tons of time. A few hours should be enough. The challenge is defined very broadly. You could spend weeks on it, or half an hour. We understand that in 2 hours, you can only do so much. Don't worry about completeness, work on something that works and shows your skills.

##### Language
From the next paragraph on, this challenge is worded in Dutch. Snappet is a Dutch organisation. We are present in several European countries and part of our development team is based in Russia, but still, most of the organisation is Dutch. We all speak English, standups, code and documentation are in English, but being able to operate in a Dutch environment is a required skill. So use whatever tools you can to make sense of the rest of the challenge if you are not a Dutch speaker. It is part of the exercise. :)

Edit: [Read this in English](README.en.md)

##### De opdracht
In deze repository vind je een folder Data met daarin work.csv en work.json. Beiden bevatten dezelfde data, je hoeft er maar één te gebruiken (wat jij handig vindt). In dit bestand zitten de werkresultaten van de kinderen in één klas over een maand. 

Maak een rapport of scherm of wat ook dat een leerkracht een overzicht geeft van hoe zijn klas vandaag heeft gewerkt en waaraan. Het is nu dinsdag 2015-03-24 11:30:00 UTC. De antwoorden van na dat tijdstip worden dus nog niet getoond.

Maak een pull request aan waarin je in ieder geval een readme hebt opgenomen die uitlegt wat je moet doen om het resultaat te kunnen bekijken.

##### Achtergrond informatie
- Alle tijden zijn in UTC
- Er is een attribuut Progress. Dit geeft de verandering in de inschatting van de vaardigheid van de leerling op een leerdoel. Daar zitten psychometrische modellen achter die rekening houden met de moeilijkheid van de opgave, of de opgave al eerder door deze leerling is gemaakt, etc. Er zijn meerdere situaties waarbij de Progress 0 is. Bijvoorbeeld als we nog geen goede calibratie van de moeilijkheid van de opgave hebben. Of als de leerling nog te weinig opgaven in een leerdoel heeft gemaakt om een goede schatting van de vaardigheid te maken.
- Aangezien deze dataset alleen wijzigingen laat zien en geen absolute waarde, kan je aan deze dataset niet zien wat de vaardigheid van iedere leerling is. Dat hoeft ook niet in de resultaten terug te komen.

#### Vrijheid
Deze opdracht is expres ruim geformuleerd. Je mag de technieken en tools gebruiken die je het liefst gebruikt. Je mag je tijd besteden aan de aspecten die je zelf het belangrijkst vindt. Er is geen tijd om alles te doen: maak een keuze. Bij Snappet werken we met C#, .NET, Typescript en Angular. Maar we denken dat een goede programmeur op een ander platform zich dat snel genoeg eigen maakt. 
Je mag frameworks en libraries gebruiken. Je mag de data in een ander formaat omzetten of importeren in databases. Dan wel in de readme uitleggen hoe een ander het werkend kan krijgen.
De minimale requirement in de opdracht is "waar heeft mijn klas vandaag aan gewerkt". Dat kan in een lijstje, in een grafisch vorm, het kan als getallen of kleuren. Je kan het vergelijken met vorige week of een gemiddelde score. Probeer te bedenken wat voor een leerkracht in de klas het belangrijkst is.
