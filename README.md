# SnappetChallenge

## Update by Abhishek Tripathi on 01-February-18
Created a *ASP.NET Core 2.0* solution. It is a simple application to demonstrate dotnet core skills and simple partitioning and filtering data and rendering it in an interactive graph.
The view shows the number of records in the dataset by subject. The inital view shows an aggregate of all subjects submissions by each day. Legend is clickable and hides or shows the line on click. 
The datepicker restricts the data to a particular day and shows following details
 - Total Correct Answers by subject. (Correct > 0)
 - Total Real Progress. (Progress > 0)
 - Total NonZero Difficulty (Difficulty > 0)
 - Total distinct submissions. (Total distinct user submissions by subject)

 # Screenshots
![alt "AllData"](/screenshot/AllData.jpg "All Data")

![alt "FilteredData"](/screenshot/filtereddata.jpg "Filtered Data")


---------------------
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
