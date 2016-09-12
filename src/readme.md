How to get this running:

What you'll need:

 - Visual Studio 2015 Update 3
 - .NET Core Preview 2
 - Node (With NPM)
 - Bower
 - Gulp
 
Open CMD from ./Snappet.Web/

 - Visual Studio 2015 Update 3
   You should already have this
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
	  
