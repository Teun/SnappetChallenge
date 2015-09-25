Hi,

Thank you for giving me the opportunity to join the challenge.
I did write a self hosting OWIN http client. The OWIN client is created by a simple console application. Run this console application 'WorkViewer.exe' to host the http client.
Next you can retrieve the webpage by typing the adress 'http://localhost:8080/overview.html' in your browser address bar and pressing GO.
The page first shows a waiting message while it is loading the data. The application will hide the overlay and draw a chart with the loaded progress data after loading the data.
Above the chart two select controls are added to select respectively the domain and the learning objective. The chart will be updated on changing the selection of the domain or learning objective.
I hope you enjoy the builded application. When you review the code you will notice the next techniques:
- Injection of different behaviors in the OWIN middleware stack including a custom handler to load the Http resources into the browser
- Share file read to avoid file open exceptions in the controller
- Caching the data with MemoryCache in the controller
- Client side caching (simple but effective)
- The filtering techniques
- The setup of client side controlllers and services
- The queueing of the async call with the self builded q method
- The usage of the DevExtreme charts with knockout binding
- The computed functions to fill the select controls
- The subscriptions to retrieve new data on changing the selection
I'm glad to show all this kind of techniques but it is not a exhaustive list. Because there are a lot of techniques I didn't use in this challenge like WCF, Work flow, ORM mappers, IoC with Autofac, Unit testing, Mock, Fixture, PostSharp exception handling, etcetera.
KR,

Frans Harinck