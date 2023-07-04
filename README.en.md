# SnappetChallenge
At [Snappet](http://www.snappet.org), we care about data and we care about code. When we interview for development positions, we want to see code and we want to discuss code. That's why we want candidates to show some work on our challenge. This challenge is not meant to cost you tons of time. A few hours should be enough. The challenge is defined very broadly. You could spend weeks on it, or half an hour. We understand that in 2 hours, you can only do so much. Don't worry about completeness, work on something that works and shows your skills.

### Language
From the next paragraph on, this challenge is worded in Dutch. Snappet is a Dutch organisation. We are present in several European countries and part of our development team is based in Russia, but still, most of the organisation is Dutch. We all speak English, standups, code and documentation are in English, but being able to operate in a Dutch environment is a required skill. So use whatever tools you can to make sense of the rest of the challenge if you are not a Dutch speaker. It is part of the exercise. :)

### The Task
In this repository, you will find a folder named "Data" containing "work.csv" and "work.json." Both files contain the same data, so you only need to use one of them (whichever you find convenient). This file contains the work results of the children in a single class over a month.

Create a report, screen, or any other form of presentation that provides a teacher with an overview of how their class has worked today and on what tasks. The current date and time are Tuesday, March 24, 2015, 11:30:00 UTC. Therefore, any answers submitted after this timestamp should not be displayed.

Create a pull request that includes, at the very least, a README explaining how to view the result.

### Background Information
- All times are in UTC.
- There is an attribute called "Progress" that indicates the change in the estimation of a student's skill level regarding a learning objective. Behind this attribute, there are psychometric models that take into account factors such as the difficulty of the task or whether the student has previously attempted the task. There are several situations where the Progress value is 0. For example, when we haven't calibrated the difficulty of the task accurately or when the student hasn't attempted enough tasks related to a learning objective to provide a reliable estimation of their skill level.
- Since this dataset only shows changes and not absolute values, you cannot determine the skill level of each student from this dataset. It is not necessary to include that information in the results.

### Freedom
This task has intentionally been loosely formulated. You are free to use the techniques and tools that you prefer. You can allocate your time to the aspects that you consider most important. It's impossible to do everything, so make a choice. At Snappet, we work with C#, .NET, TypeScript, and Angular. However, we believe that a skilled programmer can quickly adapt to a different platform. You can use frameworks and libraries. You can convert the data into a different format or import it into databases, but please explain in the README how others can make it work. The minimum requirement for this task is to determine "what tasks my class worked on today." It can be presented as a list, a graphical representation, numerical values, or colors. You can compare it to the previous week or an average score. Try to think about what is most important for a teacher in the classroom.
