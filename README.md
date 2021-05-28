# Overview

Solution to Snappet coding challenge using .NET and React.

## Components

Solution has following components:

- REST API
- Web App
- Database

## Technologies

Following technologies are used to build the solution.

- .NET 5
- React

## Architecture Diagram

<img src="./arch.png" style="margin:10px">

**Database** : An in-memory database using EF Core

**Stats Loader Service** : .NET Core Hosted Service that runs in background periodically, it reads data from work.json file and inserts the data in the database

**Snappet API** : Simple REST Api that serves stats/progress 

**Web Client** : React application that renders the stats/progress as a dashboard


## How to run

1. Run the .NET API from Visual Studio

2. Running the React project
    > cd Solution/Snappet.Web/snappet-app
    
    > npm install

    >npm start 