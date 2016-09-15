How to get this running:

What you'll need:

 - Visual Studio 2015 Update 3
 - .NET Core Preview 2
 - Node (With NPM)
 - Bower
 - Gulp
 
Open CMD from ./Snappet.Web/

 - Visual Studio 2015 Update 3
   You should already have this.
 - .NET Core Preview 2015
   Install from: https://www.microsoft.com/net/core#windows
 - Node:
   Install from: https://nodejs.org/en/
   Be sure to install the packet manager with it.
   A reboot will be needed to register everything properly.
 - Bower:
   > npm install -g bower
 - Gulp and other dependancies:
   > bower -install
   
So now we got everything we need. To start building out web-app just run the following from ./Snappet.Web/:

> gulp
> dotnet restore
> dotnet run

Browse to: http://localhost:26039/index.html#/huidig

Issues:

VS uses wrong version of Node.js

	Error:

	Error: Missing binding C:\DEV\_STORAGE\SnappetChallenge\src\Snappet.Web\node_modules\gulp-sass\node_modules\node-sass\vendor\win32-ia32-47\binding.node
	Node Sass could not find a binding for your current environment: Windows 32-bit with Node.js 5.x
	Found bindings for the following environments:
	  - Windows 64-bit with Node 0.12.x

	Fix:
	In VS:
	
	- Open Tools > Options > Project and Solutions > External Web Tools
	- Add "C:\Program Files\nodejs" to the top of the list
	  See: https://cloud.githubusercontent.com/assets/440031/15933886/becadf08-2e1e-11e6-827d-073f4ae91a35.PNG

Issues:

 - UTC Dates:
   Dates in the work.js are UTC, in the current setup nothing is done with this.
   
 - Grouping per student is incorrect:
   Not sure why this happens, in LearningObjectiveRepository.GetProgress(int classID, int userId) the group by over learning objective name and progress
   isn't honored. It seems to select the proper data but it isn't grouped, therefore the averages aren't averages.

Future:

Development is never done!

Due to time constraints, and more issues with .NET Core I'd hoped, not everything I had in mind is done.

 - Add a searchpage to slice through the available data:
   This way we can see what other school/students/classes are doing and compare progress/skill.
   Another cool thing by doing comparisons like this is that schools can better see what their student are good,
   and of course bad, at. Education can honed better like this.
   
 - Leerlingen view:
   See a overview of all students. View what they are doing and how they are doing.
   
 - Popular assignments:
   View what assignments are popular among students.
   I'm not sure if students can select assignments from a 'pool' or something like that. But if the can it would be informative to
   see what's popular.
   
 - Caching:
   Nothing is cached