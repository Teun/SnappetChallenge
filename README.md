# SnappetChallenge

Hierbij mijn SnappetChallenge. Ik heb wat data-analyse gedaan, een poging gedaan een maat te vinden voor het niveau en de progressie van leerlingen, en een simpel dashboard gebouwd om een en ander in te tonen.

Uiteraard is er altijd nog veel meer mogelijk. Het zou leuk zijn om een tijdreeksmodel te schatten om de vooruitgang van leerlingen te voorspellen bijvoorbeeld, of om clustering toe te passen op de prestaties per aandachtsgebied. Maar daarvoor waren eigenlijk zowel de tijd als de beschikbare data ontoereikend.

Het resultaat bestaat ruwweg uit twee delen:

- Een Jupyter notebook (in de directory 'notebooks'), Deze bevat wat verkennende data-analyse en wat eerste simpele functies. 
- De functies komen terug in een eenvoudig dashboard dat laat zien waar in de klas aan is gewerkt (conform de opdracht), en welke vooruitgang daarbij is geboekt. Het is een web-applicatie, aan de voorkant gebouwd met HTML (met Bootstrap) en Javascript (met jQuery/Chart.js), en aan de achterkant met Python (Pandas/Flask).

### Het geheel werkend krijgen
**Notebook**
Het iPython notebook veronderstelt dat Jupyter notebook draait. Het is gemaakt met Python 2.7. Het veronderstelt verder dat in elk geval Pandas, Numpy en Plotly beschikbaar zijn. Maar de folder bevat ook een .pdf, zodat een en ander altijd te lezen is.

**Dashboard**
Als jullie Docker hebben en gebruiken: Ik heb een dockerfile bijgesloten, dus het is het makkelijkste om daarvan gebruik te maken.
Bouwen: docker build -t snappet_dashboard .
Starten: docker run -p 5000:5000 snappet_dashboard

Het alternatief is een virtual environment aan te maken (Python 3.6) en de requirements uit de requirements.txt te installeren. Daarna is het een kwestie van app.py starten.