				Assumptions:
1. Used Json Data on whole class level keeping “2015-03-24 11:30” to get the desired output.

				Solutions Details
1. Solution includes Assignment & ClassTestProjectProject.
2. It also Contains Unit Test Report in TestResult on the root folder which has two file which give test Report
   1. TestResult_ClassTest.Html
   2. TestResult_ClassTest.trx
		                     
 Steps to Test the Solution
1. Build the Solution.
2. Run the Program using IISExpress. Below URL will be launched.
	https://localhost:44310/
3. Screen will come which shows report of class of current day, current week and current month on basis of attributes such as total students, Average class progress, total Exercise done, Total responses received, Correct response received , in correct response received, List of subjects, Domain and Learning objectives
4. The solution is designed in MVC pattern to avoid any dependency of server and client.
5. Initial thought was to create an application using webapi and Angular, but in the interest of time and dependency, adopted a MVC in dot net which had backend as well as front end.





