# SnappetChallenge

My idead for this challenge was to create an entire full stack application, so I developed from database to frontend. I've used for this project the following stack: MySql (Database), C# .Net Core 2.0 Web Api (Backend) and Angular 4 (Frontend).

## Project Overview

This project focus on presenting to teachers how well the students performed in a specific Subject or Class Domain. The teacher can filter through date, subject, domain and accuracy as well. The accuracy shows the hit percentage of each student in a subject and domain combination in that date.

![Angular 4 Frontend](./frontend-screen.png)

## Infrastructure

The project is divided into 3 main folders: *infrastructure*, *backend* and *frontend*

I created a table using the data inside the .csv file provided by the challenge and created a stored procedure to process the report query. To be able to run this project, you need to follow steps bellow:

- For the database, I used MySQL in a virtual environment using Vagrant. If you want to setup the same environment, you need to install vagrant first. Then just run:

```bash
cd infrastructure
vagrant up
```

You'll have a database configured and running.

- I copied and renamed the **work.csv** into new file called **Students.csv** (this will be the name of our Table)

- The second step is to run the setup_database.sql script that is located inside the infrastructure folder:

```bash
mysql -u root -p < setup_database.sql
```

- And just load the csv into our brand new table and delete the data after '2015-03-24 11:30' (was specified on the assignment that today is 24-03-2015 at 11:30).

```bash
mysqlimport --ignore-lines=1 --fields-terminated-by=, --local -u root -p Snappet Students.csv
mysql> Delete from Students where SubmitDateTime > '2015-03-24 11:30';
```

Now you have the database, table and stored procedure created

## Backend

The backend is based on .NET Core 2.0. You'll need to have it installed in order to run the backend. After installation process, just run:

```bash
cd backend
dotnet restore
dotnet build
dotnet run
```

You'll have the backend running on: http://localhost:5000/

## Frontend

The frontend part was developed using NPM and Angular 4, so you need to install Node.js in order to get all NPM packages. To install all its dependencies just run:

```bash
cd frontend
npm install
npm start
```

You'll have the frontend running on: http://localhost:4200/
