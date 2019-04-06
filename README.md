# Snappet Challenge

<p align = 'right'>
  <img src = 'assets/Snappet_logo.png'>
</p>

### Doel

Maak een rapport of scherm of wat ook dat een leerkracht een overzicht geeft van hoe zijn klas vandaag heeft gewerkt en waaraan. Het is nu dinsdag 2015-03-24 11:30:00 UTC. De antwoorden van na dat tijdstip worden dus nog niet getoond.

### Aanpak

Ik heb besloten om een dashboard te maken in Python met behulp van de Dash library. Daarbij heb ik twee tabbladen gemaakt, &#233;&#233;n met een overzicht van de activiteiten van de leerlingen en &#233;&#233;n met een overzicht van de progressie van de leerlingen.

Hiervoor heb ik de onderwerpen en domeinen waar de leerlingen aan kunnen werken gecombineerd tot een nieuwe kolom. De onderwerpen 'Begrijpend Lezen' en 'Spelling' bestaan namelijk uit slechts één domein (op een aantal uitzonderingen na) terwijl 'Rekenen' is onderverdeeld in 4 domeinen. Zodoende heb ik 'Rekenen' vervangen door de domeinen om tot zes categorie&#235;n te komen.

Voor het overzicht van de activiteiten, heb ik per leerling het aantal opdrachten per categorie geteld voor iedere dag. Per dag heb ik vervolgens de percentages van iedere categorie uitgerekend. Behalve dat ik dit voor iedere leerling afzonderlijk heb gedaan, heb ik dit ook voor de leerlingen gezamenlijk gedaan. Door een balk te selecteren, kun je in de grafiek eronder zien hoe de verdeling is van de activiteiten naar leerdoel voor de betreffende leerling (of alle leerlingen gezamenlijk).

Voor het overzicht van de progressie, heb ik per dag de progressie gesommeerd per categorie en per uur voor zowel de leerlingen individueel als voor alle leerlingen gezamenlijk. Door een bepaalde combinatie van categorie en tijdstip te selecteren, kun je de progressie zien per leerdoel binnen de geselecteerde categorie en op het geselecteerde tijdstip.

### Aandachtspunten

De datum en het tijdstip zijn geconverteerd van UTC naar lokale tijd (Amsterdam). Aangezien het nu dinsdag 2015-03-24 11:30:00 UTC is, is alleen de data tot dit moment meegenomen in de analyse.

De grafieken zijn interactief zodat in het menu verschillende opties, zoals datum en leerling, kunnen worden geselecteerd. Daarnaast is de onderste grafiek op ieder tabblad afhankelijk van de selectie die wordt gemaakt in de bovenste grafiek. Op het eerste tabblad kun je zodoende de activiteit per leerdoel zien voor een betreffende leerling (of alle leerlingen gezamenlijk) en op het tweede tabblad kun je zodoende de progressie zien per leerdoel binnen een bepaalde categorie op een zeker tijdstip.

Om de kans op een timeout in Heroku te minimaliseren, heb ik de databewerking in een aparte Python-file gedaan. Denk hierbij aan het aanmaken van nieuwe kolommen zoals de categorie o.b.v. onderwerp en domein, een kolom met daarin een kleur voor iedere categorie en de lokale datetime. Met name het parsen van de datum is een relatief zware operatie. Door deze bewerkingen in een aparte file te doen, is het programma app.py zo 'licht' mogelijk.

### De app

Het uiteindelijke dashboard heb ik geproductionaliseerd (deployed) m.b.v. Heroku. Het resultaat kun je vinden op:<br><a href = 'https://snappet-challenge.herokuapp.com/' target = "_blank">https://snappet-challenge.herokuapp.com/</a>

Het kan voorkomen dat de app niet werkt door een timeout, soms wordt dat door een aantal maal refreshen verholpen. Mocht dat het probleem echter niet verhelpen, dan kun je het dashboard op de volgende manier draaien m.b.v. Anaconda (incl. Python 3.7):

1. clone of download deze repository
2. cre&#235;er een virtual environment: conda create --name snappet-challenge
3. activeer de virtual environment: conda activate snappet-challenge
4. ga naar de folder met daarin de repository
5. installeer de benodigde packages: pip install -r requirements.txt
6. draai de app: python app.py
7. ga naar de localhost, zie conda prompt (bijv. http://127.0.0.1:8050/)