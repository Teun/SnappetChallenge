# SnappetChallenge

This project fulfils the [SnappetChallenge](https://github.com/Teun/SnappetChallenge): where did my class work on today?

## The challenge
Use the work.json or work.csv file to display to a teacher how the children in his or her class performed. Today is 2015-03-24 11:30:00 UTC. There is no time to do everything, make a choice.

## Running the solution locally

Install MongoDB, e.g., via [Chocolately](https://chocolatey.org/):

    choco install mongodb

Start the database server:

    mongod --smallfiles
    
Clone the repository:

    git clone https://github.com/erooijak/SnappetChallenge
    
Change directory:

    cd SnappetChallenge 

Import the documents into the database snappetchallenge_db:

    mongoimport --jsonArray --db snappetchallenge_db --collection submitted_answers < Data/work.json

The application expects SubmitDateTime to be of type BsonDateTime. It is now a string. Convert it:

    mongo localhost:27017/snappetchallenge_db convert.js

Start Visual Studio 2015 and open the solution. Wait till `Bower` and `npm` have restored the required packages and the Gulp tasks are loaded. Then run the application.

## Things to explore
- [x] ASP.NET 5
- [x] MongoDB
- [x] Knockout.js
- [ ] Azure Desired State Configuration

## Resources used

##### ASP.NET 5  
[BUILD 2015 ASP.NET 5 Training Videos - Introduction and Deep Dive](http://www.hanselman.com/blog/BUILD2015ASPNET5TrainingVideosIntroductionAndDeepDive.aspx) 
[Pluralsight: JavaScript Build Automation With Gulp.js](http://www.pluralsight.com/courses/javascript-build-automation-gulpjs)

##### MongoDB  
[Pluralsight: Introduction to MongoDB](http://www.pluralsight.com/courses/mongodb-introduction)  
[Pluralsight: Using MongoDB with ASP.NET MVC](http://www.pluralsight.com/courses/using-mongodb-aspdotnet-mvc)  
[Building Web API using MVC 6 & MongoDB](http://tattoocoder.azurewebsites.net/building-vnext-web-api-using-mvc-6-mongodb-azure/)  
[Stackoverflow: ASP.NET with MongoDB](http://stackoverflow.com/questions/28484761/asp-net-5-with-mongodb)

##### Knockout.js
[Pluralsight: Loading Views with MVVM and Knockout of John Papa's Single Page Apps with HTML5, Web API, Knockout and jQuery](http://www.pluralsight.com/courses/spa)
