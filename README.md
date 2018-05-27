# Design Consideration

 * I tightly restricted the application to not show any data after the current time (`2015-03-24 11:30:00 UTC`) which is mentioned in the challenge.
 * There was no lucid explanation regarding Difficulty field in the challenge, so I decided to exclude NULL values, but including the negative values, even they were somehow strange.
 * I used a DbContext only to demonstrate how a repository may need a data access provider.
Every services or providers dependency has been wired up, So there is no direct instantiation or dependencies on a concrete class.
 * I considered Snappet applications with lots of users and a heavy load of requests, so for demonstration purposes, I used async/await pattern in action methods, repository calls, and wherever literally an IO operation was involved to enhance the overall responsiveness of the application.

# Main Technologies Used

 * ASPNET Core 2.0
 * React and Redux
 * Typescript
 * Nodejs

# How To Build

Prerequisites:

* [.NET Core 2.0](https://www.microsoft.com/net/core) (or later) SDK
* [Node.js](https://nodejs.org/) version 6 (or later)

How to Build

 * Go to the folder `.\src`
 * Restore .NET Core dependencies by running `dotnet restore`
 * Restore Node dependencies by running `npm install`
 * Run the application using `dotnet run`
 * Browse to http://localhost:5000