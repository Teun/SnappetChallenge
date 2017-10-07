# Challenge Inayathullah Ameerjohn
##### Sample Chart
![Sample Bar chart](https://raw.githubusercontent.com/inayathullah/SnappetChallenge/master/Snappet.Challenge/bellcurve.PNG)

##### Technology Stack
1. Angular 1.5
2. .NET 4.6.1
3. WEB API
4. D3 (Chart)
5. .Bootstrap
6. Moq

##### NUGET PACKAGES
1. Accord.Statistics
2. Accord.Maths
3. Moq

##### How to run:

1. Install any lightweight HTTP server
2. `npm install live-server`
3. Open prompt and switch to Snappet.UI\app directory
4. trigger `c:\snappet.challenge\snappet.ui\app\>live-server` on the above directory

This will bring the life of the app into the browser. `http://127.0.0.1:8080/#!/charthandler`.

##### What did I do:
    
Used Angular seed project and created single page app with and data consumed from Web API created in the ASP.NET framework. The ChartHandler component using `DataService` for data and then it generated bell curve, bell curve with bar and scatter plot chart to asses over all performance of the students like how the subject been understood by students and how the complexity of subject affecting student performance etc., All visual elements created as re-usable component.

##### Required: 
1. .NET FRAMEWORK 4.6.1
2. Visual Studio 2015+

##### How to run:
Open the project in Visual studio and simply run it. It should open on `http://localhost:55315/`.

##### What did I do:
The work.json is parsed in web application. BellCurveGenerator controller exposes single HTTP Get call that will return a JSON with DataPoint.
Used Facade pattern to hide the complexity of transforming Student data into Chart data point. The facade applies mean, standard deviation and normal distribution to the student data and transforms into a data point.
ScatterPlotGenerator controller exposes single HTTP Get a call that will return a JSON with an array of x,y points. 

1. Used Facade pattern to hide the complexity of transforming Student data into Chart points. The facade applies summation, average to the student data and transforms into a data point.
2. Used repository pattern for data layers.
3. Applied SOLID principles.
4. Unit tested controllers and repository using moq framework.
Generic Exception handling mechanism implemented an appropriate HTTP status code is returned to request.

#####  The approach I took
The data is variable data on a regular interval for a month. Also, the data is more variation, so I took a statistical approach to construct bell chart and scatter plotter to assess the performance of the student. This charts will help the teacher to get better understanding about their students and how well the subject been accepted by student or whether any subject required more focus or any student group required more attention etc.,
