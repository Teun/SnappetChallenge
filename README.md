# SnappetChallenge
The SnappetChallenge application consists of a back-end (.NET) that serves the data to the front-end, which is a mobile application (Angular/Ionic) actually displaying the data.

### Running back-end
- Have VS installed
- Open the SnappetChallenge.WebAPI/Web.config file
- Set the appSettings > DataFile setting to the work.csv file
- Run the SnappetChallenge.WebAPI project

### Running front-end
- Have NodeJS installed
- Install Ionic [npm install -g cordova ionic]
- Go to folder containing mobile project [SnappetChallenge.Mobile]
- Serve the ionic app in browser [ionic serve]

The mobile app is best viewed as if running on a device

The 'Leerdoelen' page lets you explore the learning objectives of that day, or cycle to other days using the arrow buttons on either side of the date. Clicking on one of the learning objectives will give you some details about how well the class did on the objective, and what questions were particularly difficult

Use the hamburger icon at the top left (or swipe to the right) to bring up the menu and navigate to the 'Leerlingen' page. Click on one of the ids to get details on how that particular student did on the subjects and domains for that day. 