# SnappetChallenge

I have restricted myself to a maximum of around 3 hours for the implementation of the assignment. Due to the limited timeframe, I have only implemented a few features of which would be available in a full teacher dashboard.
 
### Architectural Design Decisions
- The current time is set in the application to the time specified in the assignment.
- I have assumed that the data supplied with the assignment is a small subset of a much larger data store. For the purposes of the assignment, I have structured the application so that it treats the JSON file supplied with the assignment as the result from a webservice call to this large data store, with the purpose of caching the data locally on the webserver. The reason for this is that in a real-world configuration, querying a massive datastore in the order of billions of records (which I can safely assume is the size of entire dataset - at least for the purposes of this assignment) to find averages, counts and other data analyses would be impractically slow if applied to the whole dataset. Therefore it seems logical that an efficient way to achieve this is to query a subset of data (in the case of this example - a month's worth of data for one class), and then keeping it in memory, we can quickly perform all kinds of analysis on the data, such as averages, totals, progress made, etc. Due to this, I have not made use of a database at all in the application, and keep the loaded data in a session. 
- Based on the structure of the supplied data, some of the fields (like UserId) are referenced by id, implying a foreign key to another table, but some fields, such as Subject, Domain and LearningObjective have actual values in them instead of ids. This means that we cannot infer whether or not an underlying table exists for this data, and therefore I am working on the assumption that these fields can contain arbitrary values.
- The data seems to indicate a relationship between Subject, Domain and LearningObjective, where a Subject contains one or more Domains (or a '-' indicating no set domain), and a domain contains one or more learning objectives. This assumption is used in the project in order to filter values based on the related field.
- Difficulty contains floating point values, but some records contain the value of -200. This looks like some kind of error code, or perhaps an undefined value. The task does not specify the meaning, so I will assume all negative values as being undefined in order to calculate values. 
- I have considered progress to be a cumulative figure. Therefore, like in the graph showing the progression per student, I have summed up all the progress values, so that for the period and tests selected, you can see the total progress the student has obtained for that selection, but as stated in the assignment, this is not a figure for the total progress of the student, since we do not have the past progress available.
- I do not have information on the class itself, so I have created a few hardcoded values for the class name and teachers name, more for aesthetic effect than any usefulness. These values are not used to analyse the data in any way.
- There are many places in the code which could probably be optimised, particularly in the answer analysis. I have not spent much time optimising the code, in favour of including more functionality for the sake of the assignment
- I have completely ignored user login and user tracking. The app assumes the user viewing the dashboard is a valid logged in user. I have instead focused on the presentation of data to the user. In the real-world, this dashboard would only be accessible after the user has logged in to the site.

### Implemented Features
- The dashboard is implemented as a responsive panel design
- the dashboard shows summarised data of the students answers. The implementation of detailed results has not been implemented, as it would be out of scope of a dashboard implementation.
- A panel with a series of dropdowns allows you to select the time period and filter the answers based on subject, domain and learning objective.
- A summary panel shows various statistics about the classwork in general, such as number of students who have answers, total number of answers, percent correct, average per student, highest, lowest and average difficulty.
- Seven panels showing several charts. 
	The charts included are: 
	- Number of students with answers per day
	- Number of answers submitted per student per day
	- Average percent correct answers per day by all students
	- Average percent correct ansers per student
	- Progress summed up for all answers in selection per student
	- Average difficulty of answers per student
	- Breakdown of answers based on subject, domain or learning objective, depending on which filters the user has selected


### Technologies Used
C#.NET 2015
MVC 6
jQuery 1.10.2
Chart.js
Bootstrap 3.0.0
Newtonsoft.Json 6.0.4



# Original Assignment
At [Snappet](http://www.snappet.org), we care about data and we care about code. When we interview for development positions, we want to see code and we want to discuss code. That's why we want candidates to show some work on our challenge. This challenge is not meant to cost you tons of time. A few hours should be enough. The challenge is defined very broadly. You could spend weeks on it, or half an hour. We understand that in 2 hours, you can only do so much. Don't worry about completeness, work on something that works and shows your skills.

### Language
From the next paragraph on, this challenge is worded in Dutch. Snappet is a Dutch organisation. We are present in several European countries and part of our development team is based in Russia, but still, most of the organisation is Dutch. We all speak English, standups, code and documentation are in English, but being able to operate in a Dutch environment is a required skill. So use whatever tools you can to make sense of the rest of the challenge if you are not a Dutch speaker. It is part of the exercise. :)

### De opdracht
In deze repository vind je een folder Data met daarin work.csv en work.json. Beiden bevatten dezelfde data, je hoeft er maar één te gebruiken (wat jij handig vindt). In dit bestand zitten de werkresultaten van de kinderen in één klas over een maand. 

Maak een rapport of scherm of wat ook dat een leerkracht een overzicht geeft van hoe zijn klas vandaag heeft gewerkt en waaraan. Het is nu dinsdag 2015-03-24 11:30:00 UTC. De antwoorden van na dat tijdstip worden dus nog niet getoond.

Maak een pull request aan waarin je in ieder geval een readme hebt opgenomen die uitlegt wat je moet doen om het resultaat te kunnen bekijken.

### Achtergrond informatie
- Alle tijden zijn in UTC
- Er is een attribuut Progress. Dit geeft de verandering in de inschatting van de vaardigheid van de leerling op een leerdoel. Daar zitten psychometrische modellen achter die rekening houden met de moeilijkheid van de opgave, of de opgave al eerder door deze leerling is gemaakt, etc. Er zijn meerdere situaties waarbij de Progress 0 is. Bijvoorbeeld als we nog geen goede calibratie van de moeilijkheid van de opgave hebben. Of als de leerling nog te weinig opgaven in een leerdoel heeft gemaakt om een goede schatting van de vaardigheid te maken.
- Aangezien deze dataset alleen wijzigingen laat zien en geen absolute waarde, kan je aan deze dataset niet zien wat de vaardigheid van iedere leerling is. Dat hoeft ook niet in de resultaten terug te komen.

### Vrijheid
Deze opdracht is expres ruim geformuleerd. Je mag de technieken en tools gebruiken die je het liefst gebruikt. Je mag je tijd besteden aan de aspecten die je zelf het belangrijkst vindt. Er is geen tijd om alles te doen: maak een keuze. Bij Snappet werken we met C#, .NET, Javascript, JQuery en Knockout.JS. Maar we denken dat een goede programmeur op een ander platform zich dat snel genoeg eigen maakt. 
Je mag frameworks en libraries gebruiken. Je mag de data in een ander formaat omzetten of importeren in databases. Dan wel in de readme uitleggen hoe een ander het werkend kan krijgen.
De minimale requirement in de opdracht is "waar heeft mijn klas vandaag aan gewerkt". Dat kan in een lijstje, in een grafisch vorm, het kan als getallen of kleuren. Je kan het vergelijken met vorige week of een gemiddelde score. Probeer te bedenken wat voor een leerkracht in de klas het belangrijkst is.
