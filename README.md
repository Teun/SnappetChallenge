# SnappetChallenge

## Solution
I worked on two different solutions.
One is a TrueSkill implementation in C#, the other a matrix factorization implementation in Python.
Results from both approaches were interesting, but showed little predictive power on the small dataset provided.

### Literature
The first thing I did was look at some literature.
I found some interesting papers which I've listed below:

* https://www.researchgate.net/publication/301635151_ON_THE_USE_OF_ELO_RATING_FOR_ADAPTIVE_ASSESSMENT
* https://www.fi.muni.cz/~xpelanek/publications/CAE-elo.pdf
* http://www.rcec.nl/publicaties/overige%20publicaties/cito_report.pdf
* https://www.microsoft.com/en-us/research/uploads/prod/2018/03/trueskill2.pdf
* https://www.emeraldinsight.com/doi/abs/10.1108/IDD-08-2018-0030
* https://www.researchgate.net/publication/221619020_TrueSkill_Through_Time_Revisiting_the_History_of_Chess
* https://www.moserware.com/assets/computing-your-skill/The%20Math%20Behind%20TrueSkill.pdf

And, most helpful, this blogpost by Jeff Moser on the math behind TrueSkill: http://www.moserware.com/2010/03/computing-your-skill.html



### TrueSkill
TrueSkill is an extension of the well-known ELO system used for e.g. chess.
It parameterizes a player with a mean (μ) and a standard deviation (σ) as a Gaussian curve and is usually used to match players against each other.
The algorithm is used extensively in online gaming, such as in Halo and Gears of War.

I have applied this algorithm to the provided data set since the problem is very similar: we want to match the best players against each other, except in this case, one of the players is not actually a player but an exercise.

To train the algorithm, each user-exercise interaction is used to update the mean and standard deviation of both the user and the exercise.
If a user correctly completes an exercise, the user is marked as the winner of the match, otherwise, the exercise is marked as the winner.
In TrueSkill's update function, the winner of a match ALWAYS gains rating points (i.e. their μ increases) while the loser always loses rating points.
The standard deviation σ can be seen as the uncertainty of the rating score and decreases for every match played since there is more confidence in the rating score.
Intuitively, updating a rating score in this way makes sense since we want a user's skill to increase if they complete a lot of exercises successfully and we also want an exercise's difficulty rating to drop when it's completed successfully all the time.

After iterating through 80% of the data set and updating the user and exercise ratings on the way, we end up with the following user ratings:

```
40267: [MU] 28.52 [SIGMA] 1.61 [RATING] 23.69
40279: [MU] 33.39 [SIGMA] 1.49 [RATING] 28.93
40270: [MU] 34.35 [SIGMA] 1.56 [RATING] 29.68
40272: [MU] 35.48 [SIGMA] 1.82 [RATING] 30.00
40277: [MU] 36.09 [SIGMA] 1.71 [RATING] 30.96
40268: [MU] 36.66 [SIGMA] 1.70 [RATING] 31.58
40283: [MU] 37.55 [SIGMA] 1.93 [RATING] 31.76
40286: [MU] 37.02 [SIGMA] 1.65 [RATING] 32.09
40278: [MU] 38.15 [SIGMA] 1.76 [RATING] 32.88
40280: [MU] 37.76 [SIGMA] 1.59 [RATING] 33.00
40274: [MU] 38.59 [SIGMA] 1.75 [RATING] 33.35
40273: [MU] 38.75 [SIGMA] 1.76 [RATING] 33.47
40282: [MU] 38.95 [SIGMA] 1.74 [RATING] 33.72
40285: [MU] 39.69 [SIGMA] 1.96 [RATING] 33.80
40284: [MU] 39.82 [SIGMA] 1.99 [RATING] 33.86
68421: [MU] 40.19 [SIGMA] 1.88 [RATING] 34.56
40271: [MU] 40.37 [SIGMA] 1.92 [RATING] 34.63
40281: [MU] 40.25 [SIGMA] 1.84 [RATING] 34.72
40275: [MU] 42.09 [SIGMA] 1.96 [RATING] 36.22
40276: [MU] 42.14 [SIGMA] 1.84 [RATING] 36.60
```
where the MU column shows the mean rating, the SIGMA column shows the uncertainty and the RATING column shows the conservative estimate of a player's skill (μ - 3σ).
In this case, we estimate the skill of user 40267 to be lowest of their class, while user 40276 is estimated to be of the highest skill.

A property of the TrueSkill algorithm is that it can estimate the win probability of a matchup.
In this case, this can be used to estimate whether a student will correctly complete an exercise.
After computing the results on a test set (which the algorithm had not yet seen before), we could predict with 81.1% accuracy whether an exercise would be completed successfully.
That sounds high, but predicting every single interaction as being correct already gives us a 80.8% accuracy so the predictive power of the TrueSkill algorithm is not very high in this case.

This could be caused by several things:
* Data set far too small (especially: not enough samples per exercise)
* It looks like the desired 'win rate' for a student is 80%, the TrueSkill system however is optimized for 50% win rate. This means that in this case, the MU rating for students is on average ~37, while the MU rating for exercises is on average ~28, which is much lower. This makes sense since the exercises only "win" 20% of the time. This makes it harder to calculate win probabilities as an exercise will almost always have a lower MU rating than a student. Something in the TrueSkill algorithm should be modified to account for the different win rate percentage.

Another interesting application of the TrueSkill algorithm is that it can predict *match quality* between a user and an exercise.
This is useful for a "next best exercise"-recommender.
However, because testing whether this works is hard with the given dataset, I did not yet implement this.

The implementation was done in C#, which to be honest is not the best language for rapid prototyping.
It makes going to production a lot easier though ;)
I think the code is pretty readable, but I'll give some insight into the structure:

* `Data` folder contains repository interfaces and implementations to read the CSV, keep an in-memory representation of ratings and write the results to CSV. The results that are written to a CSV file are then analyzed using a Jupyter Notebook.
* `Domain` folder contains domain-specific models
* `Science` folder includes the actual TrueSkill calculators (replaying previous matches, and predicting performance on test set)
* `Program.cs` kicks off the program and acts as one big integration tests because I didn't spend time on separate unit/integration tests.

The Jupyter Notebook includes some nice visualizations on the approach.

### Matrix factorization
Matrix factorization is usually used to give recommendations in the retail and entertainment industries.
Netflix, for example, uses matrix factorization to recommend movies and tv shows to its users.

In this case, we can train a matrix factorization algorithm on the `user,exercise,correct` triples to estimate student's performance on exercises they haven't done yet.

This algorithm was implemented in Python using the `surprise` library.
Unfortunately, as with the TrueSkill approach, results were not yet very predictive as test scores were unable to beat the baseline of 80.8% accuracy.

----

## Assignment
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
Deze opdracht is expres ruim geformuleerd. Je mag de technieken en tools gebruiken die je het liefst gebruikt. Je mag je tijd besteden aan de aspecten die je zelf het belangrijkst vindt. Er is geen tijd om alles te doen: maak een keuze. Bij Snappet werken we met C#, .NET, Typescript en Angular. Maar we denken dat een goede programmeur op een ander platform zich dat snel genoeg eigen maakt. 
Je mag frameworks en libraries gebruiken. Je mag de data in een ander formaat omzetten of importeren in databases. Dan wel in de readme uitleggen hoe een ander het werkend kan krijgen.
De minimale requirement in de opdracht is "waar heeft mijn klas vandaag aan gewerkt". Dat kan in een lijstje, in een grafisch vorm, het kan als getallen of kleuren. Je kan het vergelijken met vorige week of een gemiddelde score. Probeer te bedenken wat voor een leerkracht in de klas het belangrijkst is.
