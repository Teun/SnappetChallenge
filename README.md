# SnappetChallenge

## Prerequisites
You will need .NET Core 2.1 and something to display Excel files.

## Running
It should be sufficient to execute run.cmd file from the root of the repository: 
```
run
```
It shall open the resulting Excel file automatically. If that doesn't happen, please try to open ClassActivity.xlsx manually.

If you want to play with other dates or input files, use the full syntax:
```
dotnet run --project src\Dashboard\Dashboard.csproj <input csv> <date in ISO8601> <output>
```
for example:
```
dotnet run --project src\Dashboard\Dashboard.csproj Data\work.csv "2015-03-24 11:30:00Z" ClassActivity.xlsx"
```
I've included the sample output (ClassActivity.xlsx) at the root of the repository, so you can look at its structure without running.

## What does it show
The report shows the class activity from the start of the day until the supplied date and time.

The included data is:
* Report period (from / to).
* Number of students participated in the lesson.
* Statistics by studied topic:
  * Number of exercises
  * Correct answers percentage
  * Percentage of students who did that topic.
* Statistics by student:
  * Number of finished exercises
  * Correct answers percentage
  * Exercises covered (to total exercises in the period).

The conditional formatting shows in red low correct answers ratio and low student per topic and exercises per student ratios.

The idea is to give an overview and highlight difficult topics and underperforming students.

The topic/students overlap is lower than expected, maybe the class is divided into several groups doing different tasks? Guessing without a domain expert is hard.

## Decisions
C#/.NET because I've worked in it the most.

.NET Core because it's newer stuff and cross-platform as well.

CSV over JSON because CSV is very common in data processing and can be naturally processed line by line.

No database because it would complicate the matters and time is precious. Looking at the slice and dice I've done, it might be a good idea to do it in memory anyway, using the database only to narrow the data to the specific day and class. Maybe.

No GUI because there are too many options to choose and generally the time effort would be much higher.

Excel output is a good fit in my opinion, because it supports tables and color highlighting, and they can edit the results to add/modify some data or do their own aggregation. The downside is that it should be available to the user, but it's quite common in my experience.

I didn't touch Difficulty and Progress fields because they are hard to interpret without a domain expert.

I didn't do any comparisons to the previous periods because it's too wide and out of the scope of "what my class worked on today", in my opinion.

## Original description
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
Deze opdracht is expres ruim geformuleerd. Je mag de technieken en tools gebruiken die je het liefst gebruikt. Je mag je tijd besteden aan de aspecten die je zelf het belangrijkst vindt. Er is geen tijd om alles te doen: maak een keuze. Bij Snappet werken we met C#, .NET, Typescript en Angular. Maar we denken dat een goede programmeur op een ander platform zich dat snel genoeg eigen maakt. 
Je mag frameworks en libraries gebruiken. Je mag de data in een ander formaat omzetten of importeren in databases. Dan wel in de readme uitleggen hoe een ander het werkend kan krijgen.
De minimale requirement in de opdracht is "waar heeft mijn klas vandaag aan gewerkt". Dat kan in een lijstje, in een grafisch vorm, het kan als getallen of kleuren. Je kan het vergelijken met vorige week of een gemiddelde score. Probeer te bedenken wat voor een leerkracht in de klas het belangrijkst is.
