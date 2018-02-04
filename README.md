# SnappetChallenge

### Steps to run the solution.

1. Restore Nuget packages and build solution.
2. Set SnappetChallenge.WebApi project as startup project and run it without debugging. (Or using console)
3. Set SnappetChallenge.WebUI project as startup project and run it.
4. ???
5. Profit!

P.S. I used such definitions of default folders and file names to open such as
```
        private string rootFolderName = "SnappetChallenge";

        private string dataFolderName = "Data";

        private string fileName = "work.json";

        private readonly string fullFilePath;
```
instead of saving it in `appsettings.json`, because of the [problem of getting values from config file](https://stackoverflow.com/questions/48600901/getting-the-data-from-appsettings-json-doesnt-contain-values-during-integration/48610304#48610304)  in new .net core framework during integration testing.