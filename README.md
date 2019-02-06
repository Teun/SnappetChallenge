# Data Analysis
    To have better understanding of the dataset I used AWS QuickSight to analyze, below are 2 screenshots; 
    - ![QuickSight Screenshot 1](https://s3.eu-central-1.amazonaws.com/snappetquicksight/QuickSight_1.jpg)
    - ![QuickSight Screenshot 2](https://s3.eu-central-1.amazonaws.com/snappetquicksight/QuickSight_2.jpg)

# Run the app 

- Simply run the asp.net core WebApi, the default settings should be ok to have everything running including data seeding, but you choose to change the settings in appsettings.json, for example to change the DB location.
- SQLite EF core are used in this app.
- Unit tests are just a sample.
- DotNetCore 2.2 is the framework used.
- The client is built using angular 7, *ng serve --open* should do the trick.
- The API Url is hardcoded in *app/services/insightservice.ts* 



