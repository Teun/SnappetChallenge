# Howto

# DataBase
First you need to create database on your local computer.

1 Configure connection string. By default it's (local) ms sql database.

2 Execute command `Update-DataBase` in Package Manager Console. It will create new DB and one table.

3 Start migration tool console application. It will migrate data from json to your application.


# Web solution

1 Run SnappetChallenge.Web

2 Set the date in the datetimepicker 2015-03-02

3 You should see the report

# Technology stack

VS2017 + MSSQL + .NET Core + React

# FE

Front end is based on create-react-app dev stack.

All files in folder reports-fe.

To start FE:

    npm start

To build FE files and copy to ASP Core:

    npm run build
