# De Snappet Challenge

Bedankt voor de leuke opdracht. Het was interessant.

## Narrative and Planning

I wrote down a narrative of what I was thinking as I was planning for and implementing this assignment. I feel that the thinking, planning, and design is just has important (if not more so) than the implementation, so I not only recorded what I was thinking, but also what I was planning. You can find that information in the [Narrative and Planning document](NarrativePlan.md).

I also kept a [backlog](backlog.md) of tasks that I needed to do. That one of the great things about the Agile/Scrum process that I've adopted for this assignment. It helps me to stay focused on what I need to do and gives me a good sense of what's coming up.

The original assignment can be found [here](Opdracht.md).

## Current Status

I wrote a lot more in the narrative and planning document, but I'll summarize what I did here. I wrote a JSON file loader that loads the answer data into a queryable in-memory database (sounds impressive, but it's just a List that exposes an IQueryable). Then there is a repository layer that builds and runs the query to retrieve the data we need.

I make use of dependency injection and NUnit and Moq to implement unit tests. The web application loads the daily student summary data for the target moment and displays it on the screen in a bootstrap-styled table.

## Building and Running the Tests

Load the solution in the TeacherReport folder in Visual Studio 2017. The projects use .NET Core 2.0. Build the solution and then run the tests (Test -> Run -> All Tests or via the Test Explorer window). The tests should all pass. 

## Running the Web Application

Set the TeacherReport project as the startup project and then run it. When the web application starts up, you'll see a grid containing the daily student summary. 

The first column is the name of the student (the data is anonymous, so I substituted the user ID), the next several columns are the subject names and the average progress score in that subject. Then there's an average progress score over all subjects. The grid is sorted by the average progress score over all subjects.