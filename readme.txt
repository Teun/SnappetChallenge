Description:
	I`ve created a solution with few projects inside. I decided to spend on this project 4-8 hours in average, in fact it had taken me 5 hours. And half an hour on this readme.txt.
	I stopped by the moment I had made it stable and more or less cleaned up with some useful functionality.
	I finished it on Monday (the 13th of Feb) and spent half an hour on reviewing today and minor improvements today (the 14th of Feb).
	I`ve chosen. json file as a source. In the solution, you`ll find 3 main projects: SnappetChallenge.DataAccessLayer, SnappetChallenge.BusinessLogicLayer, SnappetChallenge.
	Dependencies are: DAL <- BLL <- SnappetChallenge.
	For the last one I used predefined mvc project because I believe it saves me pretty much time. Also, there were created projects for UnitTests, but I skipped them because of time limits (it will be one of the improvement points).
	IQueriable was returned DAL to imitate EF calls.
	Each layer is wrapped with its own AutoFac module. 
	There are also some "todo" which I leave for now because they are not that much important, but there you could see some points for improvements.
	Extra libraries, tools and frameworks: newtonsoft.json, autofac (mvc integration), automapper, grid.mvc, chart.mvc (chart.js for mvc), a bit of bootstrap.
	3 pages were created besides I kept auth pages from default mvc application. Clean up is also one of the improvement points. You could navigate via top menu.
	1) SubmittedAnswer page with grid which shows the list of submitted answers with filtering and ordering.
	2) Charts page shows 3 statistic charts: 
		- correct and incorrect answers (I suppose that correct = 1 is a correct answer and there is no any undefined states, so only 0 and 1, but I`m not sure about it because I’m not that familiar with the business domain). 
		- progress by subject (sum by progress property, probably here more complex logic should be, but for this project I suppose it’s enough).
		- correct answers by domain.
	3) Top students allows to get users with the biggest progress sum and with the smallest one. You need to put subject there because it looks senseless to calculate top by all subjects. (You could use 'Spelling' to check actual data).
Instructions:
	You need to open the project, build it and launch it from visual studio. It uses db from app_data.
Credentials:
	test@test.com
	DIjob123!
Improvements:
	- UnitTests at least for BLL and DAL.
	- Mvc project cleanup from predefined stuff.
	- Make frontend more pretty (probably could apply angularjs, or knockout and requireJs it depends on your favour)
	- Database project.
	- Prepare settings per environment (dev, test, acc, live etc).
	- Add paging logic to BLL in case of big amount of data.
	- minor improvements are highlighted "todo:" in the code.
