## uitleg
Doel was om een overzicht te maken van de resultaten van studenten in een klas met relatieve percentages om te visualiseren wat de voortgang is, afgezet tegen de rest van de klas.
Het aantal en verhouding correcte antwoorden en het relatief aantal en percentage van de correcte antwoorden leken mij goede waarden daarvoor.
hierdoor wordt de nadruk niet alleen op de hoeveelheid (correcte) antwoorden gelegd maar meer op het relatief percentage correcte antwoorden ten opzichte van de rest van de klas.

Een Node scriptje parsed eerst alle data en filtered de irrelevante antwoorden eruit, de data die zichtbaar is is alleen voor de dag die aangegeven is in de test.
Daarna worden er een aantal afgeleide waarden berekend voor de student en voor de student ten opzichte van de rest van de klas.
Deze data wordt opgeslagen als json bestand in de directory 'parsed' en de gemiddelde waarden worden opgeslagen in de dist directory als totals.js.
Deze totals zouden eigenlijk met wat meer beschikbare tijd uit een API moeten komen die de filtering, sortering en dergelijken doet gebaseerd op de dataset uit een database, maar dat is volgens mij buiten de scope van deze test.

Omdat ik nog nooit met Knockout had gewerkt wilde ik daar gebruik van maken.
Ik wilde de width css property laten animeren maar een width percentage toepassen later dan dat de view gerendered is was wat te hoog gegrepen als "Hello World" met knockout zo bleek.
En de de manier waarop ko.observables gebind kunnen worden aan style attribute was erg tegen-natuurlijk (met een function die meteen uitgevoerd moest worden om het '%' teken erachter te krijgen).
Dus nu is dat opgezet met statische waarden wat voor het bespreken van het idee voldoende zou moeten zijn.
AMD, Sass en JavaScript daar kan ik het één en ander van laten zien dus daar heb ik me niet op gefocussed in deze test.

## runnen
$ `npm install` en dan $ `gulp`
Dit filtered en parsed eerst de Data/work.json in een aantal json files (makkelijk om te debuggen) en maakt een dist/totals.js aan.
Daarna worden de andere sources gekopieerd en waar relevant bewerkt, bv CSS wordt door PostCSS, Autoprefixer en csswring gepiped.

* * *

## CSS tests
[Header test](http://output.jsbin.com/nudisa)
Op dit moment getest in Chrome, Firefox, Safari en IE9

[Header test 2](https://jsbin.com/hovoxe)
Op dit moment getest in Chrome, Firefox, Safari (wat kleine tweaks nodig in FF en Safari) werkt nog niet in IE9

[Grid test](https://output.jsbin.com/hajoqa)
Op dit moment getest in Chrome, Firefox, Safari, werkt nog niet in IE9

* * *
