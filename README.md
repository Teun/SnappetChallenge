# SnappetChallenge

This is the project I have writted in response to the challenge posed to me by Snappet.

## Getting started

To get started you will need to have access to a local version of MS Sql Express. Any version above 2010 will do.\
For simplicity sake, I have not used a Docker instance, but you are welcome to restore the backup file to a local Docker instance if you would like.

### Restoring the Sql Database

The backup of the database has been done on an early version of MS Sql Express (2014 / v11) to ensure backward compatability.\
The file path to the backup data is "/snappet-challenge/Snappet-challenge-api/Snappet-challenge-api/Database/". In this folder you will find a subfolder called "Database backup for restore" and a folder called "Scripted database". You can use either of these to restore the database in whichever way you prefer.

### Running the locally hosted API

In order to run the React app correctly, you will need to first run the API project located in the directory above named "/Snappet-challenge-api/Snappet-challenge-api/" and then run the command "dotnet run". This should start the API on your local machine. If not, please ensure that you have dotnet core 3.1 installed on your machine. In order to access the Sql database, you will need to ensure that you have provided the correct details for your MS Sql instance. This can be done by modifying the "appsettings.json" file within the aforementioned project directory. Once you have updated this file, you can stop and restart your instance of the API by pressing "Control + c" to stop it and running the command "dotnet run" once again.\

Take note of the port that the app is being hosted on above as you will need to enter this into the React project.

### Running the React.js project

Open the folder above called "snappet-challenge" in your terminal of choice and run the command "npm i". This will install any node packages required to run the app.\

Within the project folder, navigate to the "/src/libs/" folder and open the "general.js" file. Now update the baseApiUrl constant with the correct port mentioned above.

Once you have installed the above packages and updated your api path, in the same directory, run the command "npm start".
This will run the React app on port 3000 by default. Navigate to "http://localhost:3000" on your browser to view the app.

### Ensuring that everything is running correctly

If everything has gone smoothly above, you should see a dashboard layout with the summary data of the different students.
If you receive an error, please check that you have completed the above steps correctly.
