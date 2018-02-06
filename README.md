# Contents

 - Starting the Project
 - Project Structure
	 - API
	 - Core
	 - Frontend
 - Considerations/Notes
	 - Security
	 - Typescript
     - API Endpoints

# 1. Starting the Project

The app is set up to run from within Visual Studio (developed using Visual Studio 2017 Pro). You should pretty much be able to just hit run and it will import the work.json data file into a local instance of the database. If for some reason the API port chnages then the url in the index.html would have to be updated as well (search for "baseURL" in the index.html file of the frontend). 

# 2. Project Structure

## 2.1 API

The API exposes all the necessary endpoints for the web facing clients (frontends) and/or any mobile apps that 

## 2.2 Core
The "core" project builds to a dll that contains all the necessary interfaces, models and methods that the API uses. This is a shared project that can be re-used for any other projects that might need these core functionality. 

## 2.3 Frontend
The frontend is built leanly using Knockout, Bootstrap (mainly for basic css), ChartJS (for the charts) and SammyJS (for routing). Typescript could also have been used (see 3.2)

# 3. Considerations/Notes
## 3.1 Security
The API isn't secured for this sample project, though a token based authentication system would be best for this and can easily be added

## 3.2 Typescript
The frontend project isn't strongly typed - mainly to save time, for maintainability (and testing purposes) it would be best to use a combination of Knockout + Typescript or Angular +2 (personal preference at the moment)

## 3.3 API Endpoints
For this sample project the endpoints bunch up some of the returned datea, this would definitely be optimized in a production setting to return the "correct" amount of data required