# SnappetChallenge

This is a simple .NET 5.0 & Angular 11 solution of the [SnappetChallenge](Challenge.md). The application may be accessed at [https://klipspringer.azurewebsites.net](https://klipspringer.azurewebsites.net). Note that this is deployed on the free tier of Azure App Services which has no SLA (i.e. there are no guarantees of uptime).

## Dependencies
* Angular 11
* .NET 5.0
* There are no DocumentDB/SQL dependencies (for a production level app this would obviously be a requirement). The repository is in-memory to simplify getting up and running for reviewers.

## Getting up and running

For the lazy, simply access [https://klipspringer.azurewebsites.net](https://klipspringer.azurewebsites.net) and browse the source code online in VSCode with [https://github1s.com/klipspringer/SnappetChallenge](https://github1s.com/klipspringer/SnappetChallenge).

If you'd prefer to run this on your development machine:
1. Clone the repo.
2. Navigate to `SnappetChallenge/ClientApp/` in your shell.
3. Run `npm install`
4. Run `npm run-script build`
5. Navigate to `SnappetChallenge/` in your shell.
6. Open the solution in VS2019 or VSCode.
7. Build/run the application.
