Beste Teun / Snappet,

Hierbij mijn uitwerking van de **Snappet Challenge**.

De werkende 'mini web-app' is online te openen in een (mobiele) browser:
[http://richardnobel.nl/snappet/](http://richardnobel.nl/snappet/)

Ook lokaal draaien met de bronbestanden is mogelijk. In plaats van AJAX voor het ophalen van de data (uit *work.json*), koos ik een [JSONP](https://en.wikipedia.org/wiki/JSONP "JSONP") oplossing zodat op het *local filesystem* geen probleem optreedt met *cross domain policies/security*.

De focus lag vooral op het opzetten van een *responsive* web-app. Ik heb de dataset vantevoren beperkt, om niet teveel tijd te stoppen in Javascript code voor het filteren van de JSON data.  

Zoals je zult zien heb ik gebruik gemaakt van `HTML5`, `jQuery` en `Bootstrap`. Mijn eigen JS code is inbegrepen in het `index.html` bestand, om het project compact te houden. Tevens heb ik de plaatjes (2) in `style.css` opgenomen, als *Base64-encoded strings*, zodat ook daarvoor geen aparte (.png) bestanden nodig zijn (als extra "bonus" zijn er minder HTTP-requests nodig en wordt een CSS-bestand meestal met GZIP gecomprimeerd door de webserver, terwijl dat bij binaire afbeeldings-bestanden meestal niet gebeurt). 

Graag verneem ik het 'oordeel' over mijn inzending :) 

Richard Nobel <richardnobel@gmail.com>
