### SnappetChallenge ###


- Readme by Serdar BIYIK

- The project [StudyResultsAnalysis] is created with ASP.NET MVC in place. I have initally tried WEB API and knockoutjs however with the lack of knowledge on knockoutjs library, I have spend some time just to figure knockout libraries and bindings.

- All the necessary libraries are downloadble via NuGet. Just one information : I am using bootstrap 3.x not 4.0 which is just recently fully released. It caused some UI problems that I did not want to invest too much time in it.

- I focused mostly on the backend implementation as my grasp on the frontend needs somewhat catching up to do. I do not have visual charts/bars but I show the data in a simple grid via3 options:
	1- See the information on a specific date (at datetime level)
	2- See the information of a specific student via userID
	3- See the complete information.

- Unit testing covers up only the basic expected functionality as I have decided not to focus too much on ErrorPages and validations since user input is limited and there is no Create and Edit operations involved

- I am caching the data in memory. Initially I wanted to use a SQLLite database or localdb and use EntityFramework but I did not see the need for it for such simple model without table relations.

- I used my local git extensively but I am making a pull request with a fresh history.