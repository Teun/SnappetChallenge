# Snappet reporting challenge

This repository contains a

  - Snappet.Reporting.Api - .Net Core Web Api 
  - Snappet.Reporting.Webapp - Angular 2 SPA to show the reports, making use of [this template](http://blog.stevensanderson.com/2016/05/02/angular2-react-knockout-apps-on-aspnet-core/).

### How to start

If you didn't install .Net Core yet, please do so: [Install .Net Core](https://www.microsoft.com/net/core). Also make sure node and npm is installed.

After this you can open the solution in the latest Visual Studio 2015 and press F5.

To use the command line, please follow these steps:

1. Run this command in the Snappet.Reporting.Api root to run the Api on http://localhost:5000 

```shell
dotnet restore
dotnet run
```

2. Open another command line window and run this command in the Snappet.Reporting.WebApp to tun the client app:

```shell
dotnet restore
dotnet run
```  

3. Start the app: http://localhost:5005

Quick walkthrough: On start the Api loads the data from work.json into memory via Entity Framework. The WebApp requests this data and shows it in a bar and in a table.

Not implemented:
- [ ] Authentication
- [ ] More student specific reports
- [ ] Deployment
- [ ] A lot more ;-)