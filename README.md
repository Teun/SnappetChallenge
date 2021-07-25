# SnappetChallenge
At [Snappet](http://www.snappet.org), we care about data and we care about code. When we interview for development positions, we want to see code and we want to discuss code. That's why we want candidates to show some work on our challenge. This challenge is not meant to cost you tons of time. A few hours should be enough. The challenge is defined very broadly. You could spend weeks on it, or half an hour. We understand that in 2 hours, you can only do so much. Don't worry about completeness, work on something that works and shows your skills.

### Language
From the next paragraph on, this challenge is worded in Dutch. Snappet is a Dutch organisation. We are present in several European countries and part of our development team is based in Russia, but still, most of the organisation is Dutch. We all speak English, standups, code and documentation are in English, but being able to operate in a Dutch environment is a required skill. So use whatever tools you can to make sense of the rest of the challenge if you are not a Dutch speaker. It is part of the exercise. :)

### The assignment
In this repository you will find a folder Data containing work.csv and work.json. Both contain the same data, you only need to use one (whichever is convenient for you). This file contains the work results of the children in one class over a month.

Create a report or screen or whatever that gives a teacher an overview of how his class has been working today and what. It is now Tuesday 2015-03-24 11:30:00 UTC. The answers after that time are therefore not shown yet.

Create a pull request in which you have included at least a readme that explains what you need to do to view the result.

### Background information
All times are in UTC
There is a Progress attribute. This represents the change in the learner's assessment of a learning objective. There are psychometric models behind this that take into account the difficulty of the problem, whether the problem has already been done by this student, etc. There are several situations where the Progress is 0. For example, if we do not yet have a good calibration of the difficulty of the problem. Or if the student has not yet completed enough exercises in a learning objective to make a good estimate of the skill.
Since this dataset only shows changes and not an absolute value, you can't tell from this dataset what the skill of each student is. That does not have to be reflected in the results either.

### Freedom
This assignment is deliberately broadly formulated. You may use the techniques and tools you prefer. You can spend your time on the aspects that are most important to you. There is no time to do everything: make a choice. At Snappet we work with C#, .NET, Typescript and Angular. But we think a good programmer on a different platform will learn that soon enough. You are allowed to use frameworks and libraries. You may convert the data into another format or import it into databases. Then explain in the readme how someone else can get it working. The minimum requirement in the assignment is "what did my class work on today". That can be in a list, in a graphic form, it can be as numbers or colors. You can compare it with last week or an average score. Try to think about what is most important to a teacher in the classroom.
