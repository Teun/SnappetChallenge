# SnappetChallenge
The solution contains two small projects: the FrontEnd and the WebApi. The first one is a Angular project will a page that lets the user view the results for a specific date and subject.
The WebApi project serves as the backend, with methods to retrieve the subjects and the results for a specific date.

### Running the solution
Both projects will open and listen on their respective port. In case one of those two ports are already in use on your computer, they need to be changed. This can be done in Visual Studio: right-click on the project -> Debug -> App URL. In that case the Angular project needs to be aware of the port of the backend. Please change the value for 'API_BASE_URL' in ClientApp -> src -> main.ts and reload the application.