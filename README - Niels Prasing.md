# SnappetChallenge Niels Prasing

### De Opdracht
>In deze repository vind je een folder Data met daarin work.csv en work.json. Beiden bevatten dezelfde data, je hoeft er maar één te gebruiken (wat jij handig vindt). In dit bestand zitten de werkresultaten van de kinderen in één klas over een maand. 
Maak een rapport of scherm of wat ook dat een leerkracht een overzicht geeft van hoe zijn klas vandaag heeft gewerkt en waaraan. Het is nu dinsdag 2015-03-24 11:30:00 UTC. De antwoorden van na dat tijdstip worden dus nog niet getoond.
Maak een pull request aan waarin je in ieder geval een readme hebt opgenomen die uitlegt wat je moet doen om het resultaat te kunnen bekijken.

### Gekozen oplossing
Voor de opdracht heb ik gekozen om zoveel mogelijk technieken te gebruiken die ik nog nouwelijks/nooit gebruikt heb. Zo om gelijk te kijken hoe ver ik kom en hoe snel ik het oppak. Zo zou ik ook al veel leren door deze opdracht.

Ik heb gekozen voor een dashboard waarbij de docent kan kiezen tussen de informatie van alle leerlingen en van een specifieke leerling. Hiervoor is een sidebar gemaakt.

Binnen de pagina kan de docent de data filteren op het vak, het domein of het leerdoel. De gegeven data update hierbij automatisch.

#### Gebruikte technieken
De technieken die ik gebruikt heb binnen deze opdracht zijn:
- ASP.NET C#
- MVC 5
- Bootstrap
- Javascript
- JQuery
- JQuery ajax response
- Linq
- Local database (file)
- Database to classes

#### Keuze verantwoording
Ik heb gekozen voor het gebruik van een database omdat een database gemaakt is om veel data snel te kunnen doorspitten zonder al te veel problemen. Ik heb gekozen de data niet lokaal te houden omdat een processor gewoonweg meer tijd nodig heeft om de queries uit te voeren en we de data snel willen hebben.

Tussen het dashboard en de server is gekozen om alleen Json resultaten over te sturen wanneer deze gevraagd werden. hierbij werd alleen het hoognodige doorgestuurd. Hiervoor is gekozen om zo min mogelijk data over te moeten sturen tussen de gebruiker en de server.

Voor de grafieken is gekozen voor Chartist.js. Deze keuze is gemaakt door de veelzeidigheid van het script en het gebruik binnen bootstrap. 

Ik heb gekozen om op het dashboard alleen het aantal antwoorden, gemiddelde aantal antwoorden, correcte antwoorden en de progress te laten zien. Een docent wil alleen het hoognodige zien, en ik denk dat de difficulty niet veel voor een docent uitmaakt. De difficulty wordt eenmaal gebruikt om de progress te berekenen. Hierdoor heb ik alleen gekozen om de data te laten zien die een docent had willen zien.

#### Werkzaam krijgen
Als het goed is werkt alles out of the box, wanneer dit niet het geval is zal gekeken moeten worden of de connection string juist is. Zo niet pas deze aan en dan zal alles moeten werken.