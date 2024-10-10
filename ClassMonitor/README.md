# SnappetChallenge
## Solution by Martin Sven Kovačić

In my solution to the SnappetChallege, I have taken an allround approach to incorporate some skills and insights I have learned throughout the years.
The stack I have used is:
- SQLite database
- .NET 8
- EntityFramework Core
- Razor Pages
- Bootstrap 5 / jquery / ApexCharts for the UI

Everything is tied up in a clean architecture.
The Core project holds the domain objects and business logic.
The Infrastructure project interacts with external services, eg. database.
And the Web project is the application layer which encapsulates everything.
Due to the time constraint, the dependency of the domain on the infrastructure was simplified (the DbContext is used as the Repository provider instead of IRepository interfaces).

### Building the solution
The prerequisites to building and running this are only having the .NET 8.0 SDK installed.

> dotnet build 

### Running the solution

> dotnet run

On initial startup, the database will be created and seeded from the data.json file (the paths are left hardcoded so it should be run from existing folders), this can take up to several minutes. 



### Future development
There are still many areas that could be improved in the future:
- new reports should be added which would be helpful to the teacher
    - domains/subjects/learning objectives in which the students struggle the most
    - exercises solved by the least amount of students
    - top/least performing students
- students overview Pages
    - grid with all students and thier personal info
    - subject and exercise scores
    - place to add remarks
- dashboard page for students to track their own progress
