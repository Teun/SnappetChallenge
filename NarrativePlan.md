# Narrative and Planning Document

Since this is a coding challenge, I feel that there's more to it than just the output. I want to provide some insight regarding what I was thinking when I was doing the challenge and why I made the decisions that I made. The process is often as insightful as the product.

Not only will I write what I am thinking as I go along, but analyze the needs of the users and plan the features.

## The Initial Impression

I was excited to be invited to do a coding challenge. For Snappet, it's probably both a way to screen out people who talk well but can't code as well as providing a starting point for a conversation in the interview. For me, it's an opportunity to show who I am and what I can do as well as just an opportunity to solve an interesting problem. These sorts of challenges can sometimes be a lot of fun. 

In dit geval, het is ook een mogelijkheid Nederlands te oefenen. Ik zie weinig mogelijkheden in de Verenigte Staaten om Nederlands te oefenen. Ik zal waarschijnelijk meestal Engels schrijven maar ik wil ook een beetje Nederlands schrijven wanneer dat mogelijk is.

Ik was verheugd te zien dat de opdracht in Nederlands wordt geschreven. Dat was onverwacht maar heel interessant. Ik kon veel ervan verstaan maar niet alles. Door het lezen heb ik enige nieuwe woorden geleerd: "inschatting", "tijdstip", en "bestand" bijvoorbeeld.

De opdracht is ruim, en er zijn vele mogelijkheden hier. I must resist the temptation to spend too much time on this: it's only supposed to take a few hours.

## The Analysis

Software is written to solve the problems of its users, and in order to properly do so, we must talk to the users, learn what they do, and come up with something that meets their needs, iterating if possible. Dat is hier helaas niet mogelijk. Ik heb op het moment geen toegang aan een leerkracht. So I'm going to put myself in the position of a teacher and imagine what is important to them and what they want to know from looking at such a report.

As a teacher, I would want to see:

- Who is doing well and who is not, so that I can know who needs more of my attention
- What learning objectives the students (as a group) are doing well at and what they are doing poorly at, so that I can adjust what my lessons focus on
- A comparison of how they've been doing today with how they've been doing in the past so that I can see the trends
- The option to examine a particular student and see which subjects/domains they've been doing well at and which they need help with
- A chart showing the subject/domains that have been worked recently so that I can verify that my students are learning the correct ratio of subject/domains
- The date/time that this report was produced so that I know at what point in time this was in case I go back and look at it later

I'm sure that there is even more, but I think that this captures de belangrijkste behoeften van een leerkracht. The proper thing to do would be to verify with the users that this accurately reflects wat zij in een rapport willen, maar voor deze opdracht moet ik met deze lijst tevreden zijn.

In order to show who is doing well, we have to measure how well a student is doing. There appear to be two data attributes that indicate this: "correct" and "progress". From reading the README, it looks like the "progress" attribute would be the most useful to the teacher. It will be 0 when there isn't sufficient data, but it looks like it's a better way to track the progress of the student.

As it is, there's more do to here than I have time for. So I'm going to translate these needs into features that I can implement. 

## The Features

Nu dat ik heb gedacht aan wat een leerkracht wil, het is tijd om een lijst van features te maken.

The data will require several views. I'm going to list the views and the functionality each view should have.

- The daily summary view showing each student with today's data
	- This view will have the most frequently referenced information to be easily seen at a glance
	- Display a student summary in grid format
		- Each student is a row in the grid
		- Show the subjects on the grid as columns
		- Each subject column has the average progress score
		- A column contains the average progress score for all subjects
		- By default, the overview summary is ordered by the average progress score for all subjects in ascending order
		- A column contains the student's name (this will end up being a number for this anonymized data, but it would be a name for an actual report)
		- Clicking on the student's name will display the view for that student
		- The student name column can be sorted in alphabetically ascending and descending order
		- Each subject column can be sorted in ascending and descending order 
		- The column with the average progress score can be sorted in ascending and descending order
		- Grid footer with the average scores for the entire class
	- The daily summary view shows the date/time when it was generated
	- Display learning objective summaries in grid format (averages for the entire class)
		- Each learning objective has its own row in the grid
		- Columns are the learning objective name and the average score for the learning objective
	- Show a pie chart below the grids showing how many questions were answered by subject/domain for the entire class
- The student view with today's data
	- This view has information for each student
	- Display the subject/domain and learning objectives the student has done exercises for
	- Display average scores for subject/domain and average scores for each learning objective
	- The student's name should be displayed on the page (we'll use IDs since we don't have the name)
	- Display line graph or bar chart of progress over time. This should contain overall data and per subject/domain data. It's unlikely that I'll ever get to this, so I'll define it in more depth when necessary.


The daily summary view (except perhaps the pie chart) is where I believe the highest value lies. Dit is wat de leerkracht het meesten zou gebruiken. The student view would be of next-highest value. Ideally, I would run my value prioritization past the users (a product owner would likely be involved here) to ensure that I had it correct, but that won't be done here.
	
So I'm going reach for my Agile experience and create a backlog of features to implement in order of highest to lowest value. It will likely be more fine-grained that what you see here. See the [Snappet Challenge Backlog](backlog.md) to look at what I came up with.

I do not expect that I will even implement half of the features here. I will start with the highest-value items and go down the list until I feel I have spent the appropriate amount of time.

## Technical Implementation Plan

Nu dat ik beter versta, wat er moet gemaakt, kan ik aan de technische implementatie denken.

Snappet uses C#/.NET, and that's also something I'm familiar with as well, so I'm going with that technology stack. I don't foresee using a lot of Javascript here, mainly because it's a report without heavy user interaction. That's too bad because I enjoy using Javascript to implement smooth UI interactions.

When I do use Javascript, it will probably be for dynamically sorting data on the page without a bothersome postback. I may end up using Knockout because that's what Snappet uses (at least 3 years ago at the time the README was written) and that's something I'm familiar with. However, if I see something else that does the job for me, I may just go with that.

I could envision some fancy visualization work here using something like d3.js, which would be a lot of fun, but that's far beyond the scope of this exercise.

This is looking like a classic server-generated pages application. There isn't any user interaction that would require anything fancier. If there were, I would use a Javascript framework like Knockout, JQuery, or React and a REST API with Web API to communicate with the server in the background, but I don't see the need in this scope. Server-generated pages will do the job efficiently, are faster to set up, and will load much faster than a Javascript-driven page.

In order to implement sorting, I may end up rendering a Javascript structure on the server and manipulating it with Javascript in order to provide client-side sorting. We'll see how it goes.

Of course, there won't be any authentication or authorization here. No time for that and it's well beyond the scope of the project. 

In a full application, I would use a database to hold the data. I think that in this case I'll read the file into an single in-memory structure. This would normally cause concurrency problems with multiple requests messing with the same instance in memory except that this is read-only data in the context of this exercise. We don't need to worry about multiple request threads clobbering the data.

I always love dependency injection and unit tests so I'll try to fit them in here as well. In fact, I'd rather have a small amount of well-tested functionality than a large amount of poorly-tested functionality.

## Implementation

I generated a quick web application from the Visual Studio template. There's some tweaking I could do, but I'll just go with what's there. I want to spend time on the functionality.

I'm going to start out with the data repository layer. I'll have an answer repository with methods that retrieve the data we'll need for the pages and an answer database within the repository layer that deals with the details of loading the data and making it available. The answer database class will provide an IQueryable and the answer repository class will query the answer database to get the necessary data.

I'm going for a TDD approach where I write the tests before I implement the methods. I'm going with NUnit, since that's what I'm already familiar with.

My GetDailyStudentSummary tests will be fairly basic. I'm going to create test data, some of which will appear and some of which will not, containing multiple students, multiple subjects, and multiple answers for each subject, and verify that the test data that does appear in the daily student summary is calculated correctly. I don't see a need to delve into other scenarios in this exercise, since the real data will be static.

The daily student summary tests took a lot more time than I had intended and I don't have a lot of time left. I don't think I'll implement tests for the controller methods. I'd prefer to spend the time elsewhere because I feel that has more value, like showing something on the web page.

It looks like I'll just have enough time to put a quick grid on the page and that's about it.

I went ahead and used the build-in dependency injection in .NET Core, since that was already set up in the generated web project. Normally, I use Ninject for dependency injection. I found that the .NET Core dependency injection had a lot of similarities, so it wasn't difficult to adjust.

## Conclusion

I had enough time to put a quick grid on the page with some minimal bootstrap styles to make it look less ugly. The grid is sorted by the overall average progress score, which is the average of all the subjects. The subjects displayed in the grid columns are not hardcoded, but reflect the data that was retrieved. It could get a bit crowded if there were a lot of subjects to display.

I took some time to think about the problem, make some notes, and do some planning before I began coding. I estimate the coding part took about 3.5 hours, most of it spent on unit tests. I do value automated testing, so I feel that was a good use of time. I ended up being able to get the grid displaying on the page quickly and didn't encounter any errors.

I was a little disappointed that I wasn't able to get as far as I had hoped. I was hoping to use Javascript for client-side sorting, but I didn't think I could spend any more time on it without going against the terms of the assignment.

Dat was een leuke opgave en het was leuk om een beetje Nederlands kunnen te oefenen.