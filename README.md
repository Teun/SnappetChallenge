1. Clone repository using Git in Visual Studio; or use GitHub for Windows and Clone in Desktop from the Git project's web page. This will create a directory (repository) with the project files where you specify.

2. In visual studio, File->New->create a new project from existing code. From the wizard, select C# or C++ (whatever your choice it does not really matter)

3. The wizard requires a project file location: give the location of the Git folder that contains the project files (where you cloned the project's repository).

4. The Wizard requires a unique project name, for example you can use the name of the Git project with VisualStudio (or VS) appended to the end.

5. Git will now be in sync and you will be able to see all the git files. Making changes will check them out and allow you to push them to the project etc...

6. To know about challenge, please check this link: https://github.com/Teun/SnappetChallenge/blob/master/README.md

***** By default Git will want to check in the newly created .csproj file that Visual Studio creates to allow you to open the project in Visual Studio. You will just want to drag this into the excluded changes section because most likely the project in question will not be using Visual Studio.**

