# Snappet Challenge door Reinder Kamphorst

Ik heb de oprdacht uitgevoerd in 3 incarnaties:

1. Stand-alone console applicatie.
2. Angular webapp met SignalR.
3. HTTP REST API (zonder front-end).

Alle code is geschreven met Visual Studio Code (1.33.0), hiermee can de `src/` map gewoon geopend worden.

De geleverde solution [RReporter.sln](./RReporter.sln) kan ook geopend worden met Visual Studio 2017.

## Doel van de opdracht

Doel van het uitvoeren van deze opdrachten is:

1. laten zien wat ik zoal in huis heb,
1. voldoende gesrpeksstof te hebben op mijn tweede gesprek.

Ik heb mij daarom vooral gericht op het neerzetten van een goede structuur van m.n. de C# backend, aangezien dat mijn sterkste kant is.

De backend code is zo ingericht dat business logic strict gescheiden is van "framework" code, en dat er ook een logische scheiding is tussen business logic code die eventueel op den duur ook als fysieke scheiding zou kunnen dienen.

Ik kijk er naar uit hierover van gedachten te wisselen.

## Interpretatie van de data

Het bestand `work.json` is gebruikt, en de data-elementen zijn geïnterpreteerd als zgn. *work events* met de volgende properties:

* `SubmittedAnswerId`: uniek ID van een gegeven antwoord
* `SubmitDateTime`: tijdstip (UTC) dat het antwoord gegeven werd
* `Correct`: Of het antwoord correct was; 0 = niet correct, 1 = correct, 3 = correct
* `Progress`: Relatieve voortgang die geboekt is met deze opdracht. Eenheid onbekend.
* `UserId`: Unieke gebruikers-id van de leerling die het antwoord gaf
* `ExerciseId`: Unieke id van de opdracht waarop antwoord is gegeven
* `Difficulty`: Niveau van de opdracht. Indien `"NULL"`, is het niveau onbekend
* `Domain`, `Subject`, `LearningObjective`: Definiëren tesamen een uniek leerdoel (domein, onderwerp, leerdoel)

Om eea iets spannender te maken heb ik de leerlingen onderverdeeld in 2 klassen en namen gegeven,
zie [MemoryPupilsStorage.cs](./RReporter.Framework/MemoryPupilsStorage.cs).

## Draaien

NB Draai onderstaande scripts vanuit werkdirectory `src/` in deze repository.  

Er wordt van uitgeaan dat de volgende programma's aanwezig zijn en in het pad:

* dotnet (2.1.504)
* npm (5.6.0)
* Angular CLI (ng) (7.3.8)

### Stand-alone console applicatie

* `run-console.sh` (mac / linux), *of*
* `run-console.bat` (windows), *of*
* VSCode launch target "Console", *of*
* Start het project `RReporter.Run.Console` in Visual Studio 2017.

Output is samenvatting van alle 2 de klassen.

### Klassieke HTTP API (zonder front-end)

* `run-webapi.sh` (mac / linux), *of*
* `run-webapi.bat` (windows), *of*
* VSCode launch target "WebApi", *of*
* Start het project `RReporter.Run.WebApi` in Visual Studio 2017.

Open url [https://localhost:5001/api/1](https://localhost:5001/api/1) (met browser) voor een API response voor klas 1.  
Open url [https://localhost:5001/api/2](https://localhost:5001/api/2)  (met browser) voor een API response voor klas 2.

### Angular Webapp met SignalR

Hiervoor is het nodig dat de eerst de Web API draait.

Daarnaast, bouw en serveer de Angular webapp als volgt:

* `run-webapp.sh` (mac / linux), *of*
* `run-webapp.bat` (windows), *of*
* VSCode launch target "WebApp"

Open url [http://localhost:4200/work-summary/1](http://localhost:4200/work-summary/1) (met browser) voor een samenvatting voor klas 1.  
Open url [http://localhost:4200/work-summary/1](http://localhost:4200/work-summary/1) (met browser) voor een samenvatting voor klas 2.
