Hi, there are two parameters in the appsettings.json,  

{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "ServiceSettings": {
    "DataPath": "Data\\work.json",
    "ServiceAddress": "http://localhost:35460"
  }
}

DataPath is constant, i guess it will be same for everyone, only the launch address with port is required for ServiceAddress attribute for UI 
to reach backend url. For my configuration it is localhost:35460.

Then just hit F5

Thanks for the exercise, regards