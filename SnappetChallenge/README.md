#Snappet Challenge
##Inzending Nico Beemster - 23/8/2015

##Overzicht technology stack
Ik heb gepoogd de technology stack zoals deze binnen Snappet wordt toegepast zoveel mogelijk te respecteren. 

Verder beschouw ik mijzelf als full stack developer en heb ik daarom tevens getracht een breed palet aan technieken welke ik beheers te demonstreren.

Hieronder een overzicht van de architectuur van de solution, voorzien van een korte motivatie voor de tools / patterns die ik heb ingezet.

###Backend
####SQL-Server
Ik had een relationele database nodig.

####Entity Framework
Code first. De database wordt (in debug mode) aangemaakt als deze nog niet bestaat. Deze database wordt middels een Seed functie met data gevuld. 

In onderhavig geval heb ik er voor gekozen hiervoor het aangeleverde JSON-bestand te gebruiken. Dit bestand wordt in eerste instantie plat ingelezen. 

Hierna vind er een transform plaats die een relationeel datamodel vult. Dit datamodel is uit de ruwe data herleidt.

####Repository layer
Ik heb gekozen voor een generieke Repository-implementatie welke iQueryable objecten retourneert. Deze repostory is uitsluitend verantwoordelijk voor CRUD-acties. 

Business logic zit in de Service layer.

####Unit of work layer
Een eenvoudige unit of work implementatie zodat alle repositories binnen 1 UoW benaderd kunnen worden.

####Service layer
Wordt geconsumeerd door de API-controllers en is dus het entry-point van de backend.

####Unity Dependency Injection.
Eenvoudige Unity implementatie. De unit-of-work- en servicelaag zijn geregistreerd en kunnen dus ge-inject worden.

###Front end
####MVC5
Aangezien de UI asynchroon wordt voorzien van data, is er van MVC eigenlijk geen sprake meer ;) 

Het MVC framework retourneert in dit geval lege views, die middels asynchrone API-calls met data worden geladen.

Tevens maakt de API gebruik van MVC base controllers (en niet van WebAPI controllers). 

De servicelaag wordt middels constructor injection in de controllers ge-inject.

####Twitter Bootstrap
De UI is gebouwd in Twitter Bootstrap. Begint zo ondertussen bijna het standaard HTML-framework te worden. 

Responsive, dus schaalt mooi op mobile devices. 

####Knockout.js MVVM
De UI wordt middels een Knockout model van data voorzien. Het framework zorgt er ook voor dat de UI in sync blijft met het model. 

Binnen de solution heb ik getracht diverse knockout-technieken te demonstreren, zoals:
* custom data binding handlers
* computed observables
* client side data grouping
* gebruik van de knockout mapping plugin

####jQuery
Het onmisbare javscript-framework. 

####HighCharts
Mooie front-end charting library.

##Project setup
Leuk verhaal Nico, beetje lang, kunnen we niet gewoon iets zien? Uiteraard!

###Stap 1
De web-app is geconfigureerd om op de locale IIS instantie te draaien onder de URL http://snappet.local

Voeg de volgende regel toe aan je hosts file (in %SYSDRIVE\Windows\System32\Drivers\Etc)

    127.0.0.1   snappet.local

Als je de solution nu opent, zou automagisch de virtuele directory aangemaakt moeten worden. 

Lukt dit onverhoopts niet (project kan niet geladen worden), kun je in IIS een nieuwe website aanmaken. 

Voeg een binding toe op poort 80 (of bewerk de bestaande binding) en stel als hostname snappet.local in. 

Nu zou je het project moeten kunnen (her)laden.

###Stap 2
Stel de connectiestring correct in. Deze kun je vinden in SnappetChallenge.Web\web.config

    <connectionStrings>
        <add name="SnappetChallengeConnectionString" connectionString="Data Source=.;Initial Catalog=SnappetChallenge;User id=snappet;Password=sn4pp3t;" providerName="System.Data.SqlClient" />
    </connectionStrings>
	
**Data Source** = de naam van de SQL instance die je wilt gebruiken. (. voor local)

**Initial Catalog** = de naam van de database. Let wel: deze database hoef je niet aan te maken, deze wordt door Entity Framework gegenereerd zodra je de applicatie benadert.

**User id/Password** dient naar een bestaande login binnen SQL te verwijzen. Deze gebruiker dient sysadmin te zijn. Maak hier een login naar wens aan.

In plaats hiervan kun je ook **Integrated Security** gebruiken:

    <connectionStrings>
        <add name="SnappetChallengeConnectionString" connectionString="Data Source=.;Initial Catalog=SnappetChallenge;Integrated Security=true;" providerName="System.Data.SqlClient" />
    </connectionStrings>

Let wel, dit werkt alleen als jouw huidige Windows login admin rechten op SQL heeft (en heeft niet mijn voorkeur)

###Stap 3
Build de solution. De solution maakt gebruik van diverse NuGet packages, welke automatisch gedownload zouden moeten worden zodra je de build start.

Bij oudere versies van Visual Studio zou het kunnen dat je package restore nog aan moet zetten. Dit doe je door rechts te klikken op de solution en op "enable NuGet package restore" te klikken.

###Stap 4
All set! Je kunt de applicatie nu bekijken op http://snappet.local

##Verdere informatie
De eerste keer dat je de applicatie laadt wordt de database gegenereerd en gevuld met data, dat kan een paar seconden duren. Op een midrange laptop van een jaar oud (mijn laptop) duurt het ongeveer 2 seconden.

###UI features
####Resultaten per student
#####Highcarts
Om de diverse berekende metrieken per student inzichtelijk te maken heb ik ervoor gekozen per leerling een grafiek te tonen met hierin de relatieve afwijking van zijn/ haar werk ten opzichte van de klas.

Mijn gedachte hierachter is de docent direct inzict te geven in de voortgang van de klas, welke leerlingen moeite hebben met de lesstof, et cetera.

Alle grafieken worden middels een knockout bindinghandler geïnitialiseerd en van data voorzien.

####Ruwe data scherm
Dit is een platte weergave van de brondata.

#####Infinite scroll
Gezien het volume data is dit scherm voorzien van "infinite scroll". Dit werkt fantastisch in het niet-gegroepeerde overzicht. 

Echter, als er een groepering actief is, is het mogelijk dat de UI verspringt indien er data wordt toegevoegd aan een groep boven jouw schermpositie.

#####Filtering op data-bereik
Met de date/timepickers kun je een datum/tijd bereik instellen. 

Ik heb een custom bindinghandler geschreven om het selectie-bereik van de datepickers te kunnen beperken (datum-tot kan niet voor datum-vanaf liggen en vice versa).

Deze restrictie geldt niet voor de timepickers. Het is dus mogelijk een tot-tijd in te stellen die voor de vanaf-tijd ligt. Balen!

## Contact
Mocht het niet lukken, tijdens kantoortijden ben ik (het best) te bereiken op mijn email: nico.beemster@gmail.com. Bellen kan ook: 0612504225.

##Addendum
1. When Chuck Norris throws exceptions, it’s across the room.
2. All arrays Chuck Norris declares are of infinite size, because Chuck Norris knows no bounds.
3. Chuck Norris doesn’t have disk latency because the hard drive knows to hurry the hell up.
4. Chuck Norris writes code that optimizes itself.
5. Chuck Norris can’t test for equality because he has no equal.
6. Chuck Norris doesn’t need garbage collection because he doesn’t call .Dispose(), he calls .DropKick().
7. Chuck Norris’s first program was kill -9.
8. Chuck Norris burst the dot com bubble.
9. All browsers support the hex definitions #chuck and #norris for the colors black and blue.
10. MySpace actually isn’t your space, it’s Chuck’s (he just lets you use it).
11. Chuck Norris can write infinite recursion functions…and have them return.
12. Chuck Norris can solve the Towers of Hanoi in one move.
13. The only pattern Chuck Norris knows is God Object.
14. Chuck Norris finished World of Warcraft.
15. Project managers never ask Chuck Norris for estimations…ever.
16. Chuck Norris doesn’t use web standards as the web will conform to him.
17. “It works on my machine” always holds true for Chuck Norris.
18. Whiteboards are white because Chuck Norris scared them that way.
19. Chuck Norris doesn’t do Burn Down charts, he does Smack Down charts.
20. Chuck Norris can delete the Recycling Bin.
21. Chuck Norris’s beard can type 140 wpm.
22. Chuck Norris can unit test entire applications with a single assert.
23. Chuck Norris doesn’t bug hunt as that signifies a probability of failure, he goes bug killing.
24. Chuck Norris’s keyboard doesn’t have a Ctrl key because nothing controls Chuck Norris.
25. When Chuck Norris is web surfing websites get the message “Warning: Internet Explorer has deemed this user to be malicious or dangerous. Proceed?”.