# SnappetChallenge
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

# Solution readme:

### Description:
I have created a solution with few projects inside. I decided to spend on this project 4-8 hours in average, in fact it had taken me 5 hours. And half an hour on this readme.txt.
I stopped by the moment I had made it stable and more or less cleaned up with some useful functionality.
I finished it on Monday (the 13th of Feb) and spent half an hour on reviewing today and minor improvements today (the 14th of Feb).
I have chosen. json file as a source. 
In the solution, you will find 3 main projects: SnappetChallenge.DataAccessLayer, SnappetChallenge.BusinessLogicLayer, SnappetChallenge.
Dependencies are: DAL <- BLL <- SnappetChallenge.

For the last one I used predefined mvc project because I believe it saves me pretty much time. Also, there were created projects for UnitTests, but I skipped them because of time limits (it will be one of the improvement points).
IQueriable was returned DAL to imitate EF calls.

Each layer is wrapped with its own AutoFac module. 
There are also some "todo" which I leave for now because they are not that much important, but there you could see some points for improvements.

Extra libraries, tools and frameworks: newtonsoft.json, autofac (mvc integration), automapper, grid.mvc, chart.mvc (chart.js for mvc), a bit of bootstrap.

3 pages were created besides I kept auth pages from default mvc application. Clean up is also one of the improvement points. You could navigate via top menu.
- SubmittedAnswer page with grid which shows the list of submitted answers with filtering and ordering.
- Charts page shows 3 statistic charts: 
	- correct and incorrect answers (I suppose that correct = 1 is a correct answer and there is no any undefined states, so only 0 and 1, but I am not sure about it because I am not that familiar with the business domain). 
	- progress by subject (sum by progress property, probably here more complex logic should be, but for this project I suppose it’s enough).
	- correct answers by domain.
- Top students allows to get users with the biggest progress sum and with the smallest one. You need to put subject there because it looks senseless to calculate top by all subjects. (You could use 'Spelling' to check actual data).

### Instructions:
You need to open the project, build it and launch it from visual studio. It uses db from app_data.
### Credentials:
test@test.com
DIjob123!
### Improvements:
- UnitTests at least for BLL and DAL.
- Mvc project cleanup from predefined stuff.
- Make frontend more pretty (probably could apply angularjs, or knockout and requireJs it depends on your favour)
- Database project.
- Prepare settings per environment (dev, test, acc, live etc).
- Add paging logic to BLL in case of big amount of data.
- minor improvements are highlighted "todo:" in the code.
