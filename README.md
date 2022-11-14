# SnappetChallenge
This project was generated with Xamarin form for frontend and ASP.NET Core Web API for backend. In this solution there is a general report that shows a bar chart demonstrating the count of students who have answered the exercises correctly and incorrect at the last day of the collected data, and another page to filter student by domain or subject and get the data  "pagination api" when reach the end get another 20 items.

Clone the solution to Starting the Backend project or the FrontEnd "Xamarin form" 
# Backend project
Starting the backend project you need  to open the solution "SnappetChallengAPI.sln" 
Launch http://localhost:5226/swagger/index.html in your browser to view the Web UI. If you have Visual Studio after cloning Open solution with your IDE, AspnetRun.Web should be the start-up project. Directly run this project on Visual Studio with F5 or Ctrl+F5. You will see index page of project.

here you can see all used endpoints
![image](https://user-images.githubusercontent.com/42088706/201560512-ccbd51b7-8564-46c6-8f8a-ed56df4c95dd.png)

# Frontend project
Starting the backend project you need  to open the solution "SnappetChallengeFrontEnd.sln" 
you need to rebuild the solution and restore nuget packge.
to test the app on windows OS select on the top uwp project as start app project
![image](https://user-images.githubusercontent.com/42088706/201560899-4ec3cec4-7776-4f22-80f0-5d618cd682ff.png)


after starting the uwp app you get 
![image](https://user-images.githubusercontent.com/42088706/201561042-f82f570b-2520-4485-9407-1dafe0c69720.png)
you can select which environment you want to run the app on Azure production or development 
the backend deplyed on Azure app service 
ProductionEnvironmentBaseUrl = "https://snappetchallenge.azurewebsites.net/api/"; 




