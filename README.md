## uitleg
Doel was om een overzicht te maken van de resultaten van studenten in een klas met relatieve percentages om te visualiseren wat de voortgang is, afgezet tegen de rest van de klas.
Het aantal en verhouding correcte antwoorden en het relatief aantal en percentage van de correcte antwoorden leken mij goede waarden daarvoor.
hierdoor wordt de nadruk niet alleen op de hoeveelheid (correcte) antwoorden gelegd maar meer op het relatief percentage correcte antwoorden ten opzichte van de rest van de klas.

Omdat ik nog nooit met Knockout had gewerkt wilde ik daar gebruik van maken.
Ik wilde de width css property laten animeren maar een width percentage toepassen later dan dat de view gerendered is was wat te hoog gegrepen als "Hello World" met knockout zo bleek.
En de de manier waarop ko.observables gebind kunnen worden aan style attribute was erg lelijk (met een function die meteen uitgevoerd moest worden om het '%' teken erachter te krijgen).
Dus nu is dat opgezet met statische waarden wat voor het bespreken van het idee voldoende zou moeten zijn.

## runnen
$ `npm install` en dan $ `gulp`
Dit filtered en parsed eerst de Data/work.json in een aantal json files (makkelijk om te debuggen) en maakt een dist/totals.js aan waarin alleen de relevante en gemiddelde scores zitten die ingeladen wordt in de index.html.
Deze totals zouden eigenlijk met wat meer beschikbare tijd uit een API moeten komen die de filtering ook doet gebaseerd op de dataset uit een database, maar dat is volgens mij buiten de scope van deze test.

## CSS tests
[Header test]: http://output.jsbin.com/nudisa
Op dit moment getest in Chrome, Firefox, Safari en IE9

[Header test 2]: https://jsbin.com/hovoxe/
Op dit moment getest in Chrome, Firefox, Safari (wat kleine tweaks nodig in FF en Safari) werkt nog niet in IE9

[Grid test]: https://output.jsbin.com/hajoqa/
Op dit moment getest in Chrome, Firefox, Safari, werkt nog niet in IE9

