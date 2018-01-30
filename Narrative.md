# Narrative and Planning Document

Since this is a coding challenge, I feel that there's more to it than just the output. I want to provide some insight regarding what I was thinking when I was doing the challenge and why I made the decisions that I made. The process is often as insightful as the product.

Not only will I write what I am thinking as I go along, but analyze the needs of the users and plan the features.

## The Initial Impression

I was excited to be invited to do a coding challenge. For Snappet, it's probably both a way to screen out people who talk well but can't code as well as providing a starting point for a conversation in the interview. For me, it's an opportunity to show who I am and what I can do as well as just an opportunity to solve an interesting problem. These sorts of challenges can sometimes be a lot of fun. 

In dit geval, het is ook een mogelijkheid Nederlands te oefenen. Ik zie weinig mogelijkheden in de Verenigte Staaten om Nederlands te oefenen. Ik zal waarschijnelijk meestal Engels schrijven maar ik wil ook een beetje Nederlands schrijven wanneer dat mogelijk is.

Ik was verheugd te zien dat de opdracht in Nederlands wordt geschreven. Dat was onverwacht maar heel interessant. Ik kon veel ervan verstaan maar niet alles. Door het lezen heb ik enige nieuwe woorden geleerd: "inschatting", "tijdstip", en "bestand" bijvoorbeeld.

De opdracht is ruim, en er zijn vele mogelijkheden hier. I must resist the temptation to spend to much time on this: it's only supposed to take a few hours.

## The Analysis

Software is written to solve the problems of its users, and in order to properly do so, we must talk to the users, learn what they do, and come up with something that meets their needs, iterating if possible. Dat is hier helass niet mogelijk. Ik heb op het moment geen toegang aan een leerkracht. So I'm going to put myself in the position of a teacher and imagine what is important to them and what they want to know from looking at such a report.

As a teacher, I would want to see:

- Who is doing well and who is not, so that I can know who needs more of my attention
- What lessons/domains/subjects the students (as a group) are doing well at and what they are doing poorly at, so that I can adjust what my lessons focus on
- What lessons/domains/subjects the poorly-performing students need help with, so that I can better help them
- A comparison of how they've been doing today with how they've been doing in the past so that I can see the trends
- The option to examine a particular student and see which subjects/domains they've been doing well at and which they need help with
- A chart showing the subjects that have been worked recently so that I can verify that my students are learning the correct ratio of subjects
- The date/time that this report was produced so that I know at what point in time this was in case I go back and look at it later
- The option to zoom into the lessons and the lesson details so that I can look at the details of how the student did on any individual lesson. This won't be used for every student, but it would be useful to get more information when I need to focus on the particular student 

I'm sure that there is even more, but I think that this captures de belangrijkste behoeften van een leerkracht. The proper thing to do would be to verify with the users that this accurately reflects was zij in een rapport willen, maar voor deze opdracht moet ik met deze lijst tevreden zijn.

In order to show who is doing well, we have to measure how well a student is doing. There appear to be two data attributes that indicate this: "correct" and "progress". From reading the README, it looks like the "progress" attribute would be the most useful to the teacher. It will be 0 when there isn't sufficient data, but it looks like it's a better way to track the progress of the student.

As it is, there's more do to here than I have time for. So I'm going to translate these needs into features that I can implement. 

## The Features

Nu dat ik gedacht heb aan wat een leerkracht wil, het is tijd om een lijst van features te maken.

The data will require several views. I'm going to list the views and the functionality each view should have.

- The daily summary view showing each student with today's data
	- This view will have the most frequently referenced information to be easily seen at a glance
	- Display a student summary in grid format
		- Each student is a row in the grid
		- Show the subjects on the grid as columns
		- Each subject column has the average progress score
		- A column contains the average progress score for all subjects
		- By default, the overview summary is ascending order by the average progress score for all subjects
		- A column contains the student's name (this will end up being a number for this anonymized data, but it would be a name for an actual report)
		- Clicking on the student's name will display the view for that student
		- The student name column can be sorted in alphabetically ascending and descending order
		- Each subject column can be sorted in ascending and descending order 
		- The column with the average progress score can be sorted in ascending and descending order
		- Grid footer as the average scores for the entire class
	- The daily summary view shows the date/time when it was generated
	- Display subject summaries in grid format (averages for the entire class)
		- Each subject/domain combination has its own grid
		- Lessons for the domain are rows in the grid
		- Columns are the lesson and the average score for the lesson
		- Grid footer has the average score for the entire class		
		- We may be able to do this with one grid and different levels of indentation. Some UI thinking is necessary here.
	- Show a pie chart below the grids showing how many questions were answered by domain for the entire class
- The student view with today's data
	- This view has information for each student
	- Display the subject/domain combinations the student has done lessons for and the individual lessons for the domain
	- This may be done with multiple grids or a single grid with different levels of indentation
	- Display average scores for domain and average scores for each lesson
	- Clicking on a lesson will display the lesson view
	- The student's name should be displayed on the page
	- Display line graph or bar chart of progress over time. This should contain overall data and per subject/domain data. It's unlikely that I'll ever get to this, so I'll define it in more depth when necessary.
- The lesson view with today's data 
	- Display the subject/domain combination and lesson name
	- Display the student's name
	- Display a grid with answer details: answer ID, date/time, correct, progress
	- The difficulty value doesn't look like it's something that is useful for humans to look at, so I won't display that

The daily summary view (except perhaps the pie chart) is where I believe the highest value lies. Dit is wat de leerkracht het meesten gebruikten zou. The student view would be of next-highest value and the lesson view would be the lowest value item. I think the lesson view would not be used that often. Ideally, I would run my value prioritization past the users (a product owner would likely be involved here) to ensure that I had it correct, but that won't be done here.
	
So I'm going reach for my Agile experience and create a backlog of features to implement in order of highest to lowest value. It will likely be more fine-grained that what you see here. See the [Snappet Challenge Backlog](backlog.md) to look at what I came up with.

I do not expect that I will even implement half of the features here. I will start with the highest-value items and go down the list until I feel I have spent the appropriate amount of time.

## Technical Implementation Plan

Nu dat ik beter versta, wat er moet gemaakt, kan ik aan de technische implementatie denken.

Snappet uses C#/.NET, and that's also something I'm familiar with as well, so I'm going with that technology stack. I don't foresee using a lot of Javascript here, mainly because it's a report without heavy user interaction. That's too bad because I enjoy using Javascript to implementing smooth UI interactions.

When I do use Javascript, it will probably be for dynamically sorting data on the page without a bothersome postback. I may end up using Knockout because that's what Snappet uses (at least 3 years ago at the time the README was written) and that's something I'm familiar with. However, if I see something else that does the job for me, I may just go with that.

I could envision some fancy visualization work here using something like d3.js, which would be a lot of fun, but that's far beyond the scope of this exercise.

This is looking like a classic server-generated pages application. There isn't a lot of user interaction that would require anything fancier. If there were, I would use something like Knockout, JQuery, and a REST API with Web API to communicate with the server in the background, but I don't see the need in this scope. Server-generated pages will do the job efficiently, are simpler to implement, and will load much faster than a Javascript-driven page.

In order to implement sorting, I may end up rendering a Javascript structure on the server and manipulating it with Javascript in order to provide client-side sorting. We'll see how it goes.

Of course, there won't be any authentication or authorization here. No time for that and it's well beyond the scope of the project. 

In a full application, I would use a database to hold the data. I think that in this case I'll read the file into an single in-memory structure. This would normally cause concurrency problems with multiple requests messing with the same instance in memory except that this is read-only data in the context of this exercise. So we don't need to worry about multiple request threads clobbering the data.

I always love dependency injection and unit tests. I'll try to fit them in here as well. In fact, I'd rather have a small amount of well-tested functionality than a large amount of poorly-tested functionality.