

```python
import plotly.graph_objs as go
fig = go.FigureWidget()
# Display an empty figure
import plotly.graph_objs as go
fig = go.FigureWidget()
# Display an empty figure
# Add a scatter chart
fig.add_scatter(y=[2, 1, 4, 3])
# Add a bar chart
fig.add_bar(y=[1, 4, 3, 2])
# Add a title
fig.layout.title = 'Hello FigureWidget'
fig
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3sndHlwZSc6ICdzY2F0dGVyJywgJ3VpZCc6ICdhMDIxZTk0ZS1kODExLTQ2NDctYmRiNS1kZWNmYzdhNWEyMDQnLCAneSc6IFsyLCAxLCA0LCDigKY=



**Preliminary stuff**


```python
# Do some imports
import pandas as pd
import numpy as np
import plotly.graph_objs as go
```


```python
# Read the dataset
df = pd.read_csv('~/dev/snappet_challenge/SnappetChallenge/Data/work.csv')
```

**Some data exploration**


```python
# Let's do some data exploration. First, show the first few lines
df.head(15)
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>SubmittedAnswerId</th>
      <th>SubmitDateTime</th>
      <th>Correct</th>
      <th>Progress</th>
      <th>UserId</th>
      <th>ExerciseId</th>
      <th>Difficulty</th>
      <th>Subject</th>
      <th>Domain</th>
      <th>LearningObjective</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>0</th>
      <td>2395278</td>
      <td>2015-03-02 07:35:38.740</td>
      <td>1</td>
      <td>0</td>
      <td>40281</td>
      <td>1038396</td>
      <td>-200.000000</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>1</th>
      <td>2396494</td>
      <td>2015-03-02 07:36:48.530</td>
      <td>1</td>
      <td>2</td>
      <td>40281</td>
      <td>1029120</td>
      <td>329.234193</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>2</th>
      <td>2396638</td>
      <td>2015-03-02 07:36:55.487</td>
      <td>1</td>
      <td>0</td>
      <td>40282</td>
      <td>1013670</td>
      <td>-200.000000</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>3</th>
      <td>2396696</td>
      <td>2015-03-02 07:36:59.653</td>
      <td>1</td>
      <td>2</td>
      <td>40281</td>
      <td>1029121</td>
      <td>353.397286</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>4</th>
      <td>2397209</td>
      <td>2015-03-02 07:37:24.030</td>
      <td>1</td>
      <td>0</td>
      <td>40285</td>
      <td>1038506</td>
      <td>-200.000000</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>5</th>
      <td>2397600</td>
      <td>2015-03-02 07:37:43.500</td>
      <td>0</td>
      <td>-10</td>
      <td>40285</td>
      <td>1038509</td>
      <td>230.697167</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>6</th>
      <td>2397725</td>
      <td>2015-03-02 07:37:48.990</td>
      <td>1</td>
      <td>0</td>
      <td>40285</td>
      <td>1038509</td>
      <td>230.697167</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>7</th>
      <td>2397740</td>
      <td>2015-03-02 07:37:49.553</td>
      <td>1</td>
      <td>2</td>
      <td>40282</td>
      <td>1013691</td>
      <td>323.953290</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>8</th>
      <td>2397893</td>
      <td>2015-03-02 07:37:56.963</td>
      <td>1</td>
      <td>0</td>
      <td>40282</td>
      <td>1013695</td>
      <td>191.983914</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>9</th>
      <td>2398069</td>
      <td>2015-03-02 07:38:05.060</td>
      <td>1</td>
      <td>4</td>
      <td>40282</td>
      <td>1013698</td>
      <td>417.570959</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>10</th>
      <td>2398104</td>
      <td>2015-03-02 07:38:06.243</td>
      <td>1</td>
      <td>2</td>
      <td>40285</td>
      <td>1038510</td>
      <td>268.627581</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>11</th>
      <td>2398238</td>
      <td>2015-03-02 07:38:12.533</td>
      <td>0</td>
      <td>-7</td>
      <td>40282</td>
      <td>1013704</td>
      <td>339.854340</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>12</th>
      <td>2398291</td>
      <td>2015-03-02 07:38:15.247</td>
      <td>1</td>
      <td>0</td>
      <td>40282</td>
      <td>1013704</td>
      <td>339.854340</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>13</th>
      <td>2398575</td>
      <td>2015-03-02 07:38:27.163</td>
      <td>1</td>
      <td>4</td>
      <td>40281</td>
      <td>1029123</td>
      <td>414.861410</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
    <tr>
      <th>14</th>
      <td>2398821</td>
      <td>2015-03-02 07:38:36.493</td>
      <td>1</td>
      <td>2</td>
      <td>40285</td>
      <td>1038512</td>
      <td>323.927134</td>
      <td>Begrijpend Lezen</td>
      <td>-</td>
      <td>Diverse leerdoelen Begrijpend Lezen</td>
    </tr>
  </tbody>
</table>
</div>



Looks fine; at least looks as expected. We can even already draw some preliminary conclusions:
 - Correct == 1 means a correct answer (progress >0)
 - Correct == 0 means a wrong answer (progress <0)
 - ExerciseId and AnswerId have probably lots of levels (will check later)
 - SubmitDateTime looks like a string; will need to correct
 - Difficulty is sometimes -200; need to check what that is.


```python
# Check for NaN values:
df.isna().any()
```




    SubmittedAnswerId    False
    SubmitDateTime       False
    Correct              False
    Progress             False
    UserId               False
    ExerciseId           False
    Difficulty            True
    Subject              False
    Domain               False
    LearningObjective    False
    dtype: bool



Only column Difficulty contains NaN values. The rest is filled completely.


```python
# As said above: let's check the SubmitDateTime
df.dtypes
```




    SubmittedAnswerId             int64
    SubmitDateTime       datetime64[ns]
    Correct                       int64
    Progress                      int64
    UserId                        int64
    ExerciseId                    int64
    Difficulty                  float64
    Subject                      object
    Domain                       object
    LearningObjective            object
    dtype: object




```python
# Yes, it is an object. Set SubmitDateTime to the correct data type.
df['SubmitDateTime'] = pd.to_datetime(df.SubmitDateTime)
df.dtypes
```




    SubmittedAnswerId             int64
    SubmitDateTime       datetime64[ns]
    Correct                       int64
    Progress                      int64
    UserId                        int64
    ExerciseId                    int64
    Difficulty                  float64
    Subject                      object
    Domain                       object
    LearningObjective            object
    dtype: object



All data types are ok now.

**Further exploration: column meaning and levels**


```python
# Let's check some levels and descriptive stats
df.describe()
```




<div>
<style scoped>
    .dataframe tbody tr th:only-of-type {
        vertical-align: middle;
    }

    .dataframe tbody tr th {
        vertical-align: top;
    }

    .dataframe thead th {
        text-align: right;
    }
</style>
<table border="1" class="dataframe">
  <thead>
    <tr style="text-align: right;">
      <th></th>
      <th>SubmittedAnswerId</th>
      <th>Correct</th>
      <th>Progress</th>
      <th>UserId</th>
      <th>ExerciseId</th>
      <th>Difficulty</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th>count</th>
      <td>3.781200e+04</td>
      <td>37812.000000</td>
      <td>37812.000000</td>
      <td>37812.000000</td>
      <td>3.781200e+04</td>
      <td>36177.000000</td>
    </tr>
    <tr>
      <th>mean</th>
      <td>4.522490e+07</td>
      <td>0.798741</td>
      <td>0.269861</td>
      <td>42013.306067</td>
      <td>4.147324e+05</td>
      <td>259.089332</td>
    </tr>
    <tr>
      <th>std</th>
      <td>2.345443e+07</td>
      <td>0.436385</td>
      <td>8.678816</td>
      <td>6771.861332</td>
      <td>1.801075e+05</td>
      <td>105.213608</td>
    </tr>
    <tr>
      <th>min</th>
      <td>2.395278e+06</td>
      <td>0.000000</td>
      <td>-153.000000</td>
      <td>40267.000000</td>
      <td>1.866000e+03</td>
      <td>-200.000000</td>
    </tr>
    <tr>
      <th>25%</th>
      <td>2.665487e+07</td>
      <td>1.000000</td>
      <td>0.000000</td>
      <td>40272.000000</td>
      <td>3.833870e+05</td>
      <td>184.813394</td>
    </tr>
    <tr>
      <th>50%</th>
      <td>4.095615e+07</td>
      <td>1.000000</td>
      <td>0.000000</td>
      <td>40277.000000</td>
      <td>3.896090e+05</td>
      <td>261.282325</td>
    </tr>
    <tr>
      <th>75%</th>
      <td>6.750498e+07</td>
      <td>1.000000</td>
      <td>3.000000</td>
      <td>40283.000000</td>
      <td>4.166450e+05</td>
      <td>327.682730</td>
    </tr>
    <tr>
      <th>max</th>
      <td>8.453230e+07</td>
      <td>3.000000</td>
      <td>91.000000</td>
      <td>68421.000000</td>
      <td>1.090819e+06</td>
      <td>638.044152</td>
    </tr>
  </tbody>
</table>
</div>



*Submitted Answer Id*


```python
# As already expected: the submitted answer id is unique for every row
len(pd.unique(df.SubmittedAnswerId))
```




    37812



*SubmitDateTime*


```python
# Check SubmitDateTime; count rows per date
df.groupby(df.SubmitDateTime.dt.date).Correct.count()
```




    SubmitDateTime
    2015-03-02     727
    2015-03-03    2051
    2015-03-04     773
    2015-03-05    2163
    2015-03-06    1263
    2015-03-09    1661
    2015-03-10    3325
    2015-03-11    2127
    2015-03-12    2532
    2015-03-13    2555
    2015-03-16     825
    2015-03-18    2035
    2015-03-19    1806
    2015-03-20     816
    2015-03-23    2168
    2015-03-24    3189
    2015-03-25    2992
    2015-03-26    1951
    2015-03-27    1030
    2015-03-30    1823
    Name: Correct, dtype: int64




```python
df.groupby(df.SubmitDateTime.dt.date).Correct.count().describe()
```




    count      20.00000
    mean     1890.60000
    std       799.95838
    min       727.00000
    25%      1204.75000
    50%      1993.00000
    75%      2259.00000
    max      3325.00000
    Name: Correct, dtype: float64



Ok. We've got one month of data. Some weekdays are missing (might be holidays). Number of rows per day fluctuates between 727 and 3325. Mean is 1890. All OK.

*Correct*


```python
# Check the values of column 'Correct'
pd.unique(df.Correct)
```




    array([1, 0, 3])




```python
len(df[df.Correct == 3])
```




    187



That's interesting. Apparently, column 'Correct' contains three different values. 1 is 'true', 0 is 'false', 
However, it remains a bit of a mistery what 3 means. It could follow from the 'progress' variable


```python
df[df.Correct == 3].Progress.value_counts()
```




    0    187
    Name: Progress, dtype: int64



Nope. Doesn't follow. All progress is zero. We will exclude these rows from the analysis later on.

*Progress*

One of the more interesting variables. Let's see what it contains.


```python
# Let's plot a histogram
data = [go.Histogram(x=df.Progress)]
layout = go.Layout(title='Progress distribution')
fig = go.FigureWidget(data,layout)
fig
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3sndHlwZSc6ICdoaXN0b2dyYW0nLAogICAgICAgICAgICAgICd1aWQnOiAnNjE0YjgyZjktNDBmMC00NGNjLTk3N2ItOTFjYjViYzRhZDE5JyzigKY=




```python
# The outliers are not very helpful. Let's try again:
data = [go.Histogram(x=df.Progress[(df.Progress > -20) & (df.Progress<20)])]
layout = go.Layout(title='Progress distribution without outliers')
fig = go.FigureWidget(data,layout)
fig
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3sndHlwZSc6ICdoaXN0b2dyYW0nLAogICAgICAgICAgICAgICd1aWQnOiAnNWUzMmY1ZmItYTc0NC00YzliLWFhMmItOGM3Mjk4YmZkZWExJyzigKY=



First conclusion: In about 50% of the cases the value for Progress is 0. Let's filter those cases out to get some more feeling about the variable:


```python
data = [go.Histogram(x=df.Progress[(df.Progress > -20) & (df.Progress<20) & (df.Progress!=0)])]
layout = go.Layout(title='Progress distribution without outliers')
fig = go.FigureWidget(data,layout)
fig
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3sndHlwZSc6ICdoaXN0b2dyYW0nLAogICAgICAgICAgICAgICd1aWQnOiAnZGE3NzJkZTEtNmFmMC00OWRkLThjMzgtMDEzOGE0Yjk3Mjk0JyzigKY=



That's better. So we have two distributions, most likely one for wrong answers (left) and one for correct answers (right).
Both are (obviously) skewed, because of the boundary at 0.

*UserId*


```python
df.UserId.value_counts().describe()
```




    count      20.000000
    mean     1890.600000
    std       409.034216
    min       952.000000
    25%      1588.750000
    50%      1841.500000
    75%      2212.250000
    max      2554.000000
    Name: UserId, dtype: float64



We've got 20 students. On average, they have 1890 entries a day.

*ExerciseId*


```python
df.ExerciseId.value_counts().describe()
```




    count    6200.000000
    mean        6.098710
    std         7.076194
    min         1.000000
    25%         1.000000
    50%         2.000000
    75%         9.000000
    max        70.000000
    Name: ExerciseId, dtype: float64



6200 different exercises have been done. Given the high cardinality, these are *questions* not exercises.  

*Difficulty*


```python
# Another interesting variable - the difficulty level of the question. Let's check the distribution:
data = [go.Histogram(x=df.Difficulty)]
layout = go.Layout(title='Difficulty distribution')
fig = go.FigureWidget(data,layout)
fig
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3sndHlwZSc6ICdoaXN0b2dyYW0nLAogICAgICAgICAgICAgICd1aWQnOiAnMDljNjVmMjQtMDM5Ny00YzJmLWIwZGEtMGI4OGY0YzcwM2U4JyzigKY=



Difficulty is more or less normally distributed among a mean of 260. There is a slight peak at -200. This seams to be an artefact (unrated exercises?).


```python
# We also had NaN values for this column. Time to investigate. 
df.Difficulty.isna().value_counts()
```




    False    36177
    True      1635
    Name: Difficulty, dtype: int64




```python
# Ok. In 4% of the cases difficulty is not filled in. Maybe these are the unrated exercises?
# In that case the progress variable should be 0, according to the documentation. Let's see.
df[(df.Difficulty.isna()) & (df.Progress != 0)].Progress.value_counts().sum()
```




    341



No, this is not it. In 341 of the 1635 cases there is a progress value derived from the missing difficulty. Another question mark.


```python
# Let's see if the difficulty of a question is absolute (i.e. the same time each question is posed)
# or relative to the student. In the latter case, we'd expect the same ExerciseId to have various
# difficulty levels.
diff_per_exercise = df.groupby(['ExerciseId']).Difficulty.nunique()
diff_per_exercise.value_counts()
```




    1    6015
    0     185
    Name: Difficulty, dtype: int64



It is a function of the question.

*Subject, Domain, Learning Objective*


```python
df.Subject.value_counts()
```




    Rekenen             22462
    Spelling            14235
    Begrijpend Lezen     1115
    Name: Subject, dtype: int64




```python
df.Domain.value_counts()
```




    Getallen          15775
    Taalverzorging    14219
    Meten              5933
    -                  1131
    Verhoudingen        545
    Verbanden           209
    Name: Domain, dtype: int64




```python
df.LearningObjective.value_counts()
```




    woorden met twee verschillende medeklinkers in het midden (kasteel, zakdoek)                            5693
    woorden eindigend op -d of -t                                                                           3147
    Optellen en aftrekken tot �1000                                                                         3128
    klinkerverenkeling (straten, bomen)                                                                     2718
    Tienstructuur: begrijpen                                                                                2241
    Vermenigvuldigen 8 x 32                                                                                 2023
    Meetinstrumenten aflezen - Klokkijken                                                                   1383
    Schatten met gegeven getallen                                                                           1370
    Diverse leerdoelen Begrijpend Lezen                                                                     1115
    Maten omrekenen met komma's                                                                              931
    Inzicht in relatie 3D en 2D                                                                              928
    Delen: kennen                                                                                            888
    Vermenigvuldigen met nullen (hele getallen)                                                              863
    Delen met rest of decimaal getal                                                                         852
    woorden met -ou-, -ouw, -au-, -auw (stout, vrouw, pauw)                                                  840
    woorden met -ch(t) (pech, bocht)                                                                         837
    verkleinwoorden met uitgang -je na -d en -t (vriendje, plantje), -pje, -etje (raampje, dingetje, ...     636
    Gehele getallen plaatsen op getallenlijn                                                                 591
    Getallenrij                                                                                              589
    Tijdmaten omrekenen +                                                                                    569
    Afronden op hele getallen                                                                                563
    Meetinstrumenten aflezen - Lengte                                                                        547
    Schatten door afronden                                                                                   487
    Maten omrekenen                                                                                          485
    Maateenheden omrekenen, ook geldrekenen                                                                  354
    Tafelsommen                                                                                              329
    Verhoudingsproblemen oplossen                                                                            304
    Delen: uitrekenen                                                                                        287
    Maat kiezen in context                                                                                   276
    Tijdmaten omrekenen                                                                                      243
                                                                                                            ... 
    woorden met een tweetekenklank (deuk, kuiken)                                                             35
    Sommen tot 100 - Somtype 42 + 5 en 42 + 8                                                                 33
    Sommen tot 100 - Somtype 48 + 4                                                                           27
    woorden met (-)ei(-) of (-)ij(-) (trein, lijst)                                                           24
    samengestelde woorden (tuindeur, schatkist)                                                               19
    Tienstructuur: Splitsen en aanvullen                                                                      17
    woorden met -aai, -ooi, -oei (saai, mooi, boei)                                                           17
    Referentiematen: kennen                                                                                   17
    woorden met mm kmm (plant, klomp)                                                                         16
    woorden met uitgang -lijk (eerlijk)                                                                       14
    Kennis over bewerkingen                                                                                   13
    stam van het werkwoord (sp)                                                                               13
    Sommen tot 100 - Sommen tot 20                                                                            12
    Meerdere spellingdoelen                                                                                    9
    woorden met -eeuw/-ieuw/-uw (sneeuw, nieuw, duw)*                                                          9
    Meetkundig inzicht                                                                                         8
    Schatten door afronden +                                                                                   7
    Spelling allerlei                                                                                          7
    Symbolen en hun relaties                                                                                   6
    woorden met uitgang -el, -er, -en, -te (sleutel, moeder, molen, breedte)                                   6
    Kritisch controleren door schatten of narekenen                                                            6
    Sommen tot 100 - Splitsen                                                                                  5
    Optellen en aftrekken met kommagetallen                                                                    4
    Optellen en aftrekken met nullen                                                                           3
    woorden met -a, -o, -u (papa, foto, nu)                                                                    3
    woorden met -nk of ng (bank, bang)                                                                         2
    Meetinstrumenten aflezen - Kalender                                                                        2
    Sommen tot 100 - Somtype 38 + 25                                                                           2
    Sommen tot 100 - Sommen tot 10                                                                             1
    Sommen tot 100 - Algemeen                                                                                  1
    Name: LearningObjective, Length: 79, dtype: int64



These columns seem to be pretty straightforward. Simply labels.

*Columns and levels: conclusions*

- SubmittedAnswerId: is unusable for analysis in this context. It is pretty much unique for each row.
- SubmitDateTime: Date and time the answer was submitted. Good data quality. UTC timestamp.
- Correct: Mostly useable, although the value 3 remains a question. 
- Progress: (relative) progress. Can be positive or negative. Is 0 in 50% of the cases. This is potentially one of the most interesting variables of the dataset (as it describes the actual learning result) but its useability is questionable. However, we will use it for now, with a mental note to check its actual meaning and data quality.
- UserId: just as it says it is.
- ExerciseId: Seemed to be the ID of an exercise, i.e. a set of coherent questions towards an objective, but given its high cardinality, it is rather a question id. We will make some sort of session id to group together questions towards a certain learning objective.
- Difficulty: describes (in absolute terms) how difficult a question is. Is sometimes empty.
- Subject, Domain, LearningObjective: strings describing the nature of the question.

**Can we do something with the progress variable?**

It would be nice if we could show progress of an individual student on a subject, compared to its fellow students. 
Progress is a relative variable (it doesn't show the actual level), but it still might yield some insight.


```python
def progress_against_peer_group(user_id, learningobjective):
    """
    Plots mean cumulative progress, and standard deviation for the entire group for a given learningobjective
    Also plots cumulative progress for a given student.
    """
    
    # Sort the dataframe by user, objective, and date
    df_sorted = df.sort_values(by=['UserId', 'LearningObjective', 'SubmitDateTime'])
    # Add a date minus the time to group on
    df_sorted['SubmitDate'] = df_sorted.SubmitDateTime.dt.date

    # Sum the progress per day, per user, per objective
    progress_per_day = pd.DataFrame(df_sorted.groupby(['UserId', 'LearningObjective', 'SubmitDate']).Progress.sum())
    progress_per_day = progress_per_day.reset_index()
    progress_per_day['Progress_cumulative'] = progress_per_day.groupby(['UserId', 'LearningObjective']).Progress.cumsum()

    # Now calculate means
    progress_per_day_means = progress_per_day.groupby(['LearningObjective', 'SubmitDate']).agg(['mean', np.std])
    progress_per_day_means = progress_per_day_means.reset_index()

    # Create a canvas for the plot
    fig = go.FigureWidget()

    # Set the values for the means and +1 and -1 stdev
    df_learningobjective = progress_per_day_means[progress_per_day_means.LearningObjective == learningobjective]
    values = df_learningobjective.Progress_cumulative['mean']
    values_std = df_learningobjective.Progress_cumulative['std']
    values_std = values_std.fillna(0)
    ubound = values + values_std
    lbound = values - values_std
    user = progress_per_day[(progress_per_day.UserId == user_id) & (progress_per_day.LearningObjective == learningobjective)].Progress_cumulative

    # Make the actual plot
    labels = [str(i) for i in df_learningobjective.SubmitDate.to_list()]
    fig.add_scatter(x=labels, y=values, name='Mean progress')
    fig.add_scatter(x=labels, y=ubound, name='+1 stdev')
    fig.add_scatter(x=labels, y=lbound, name='-1 stdev')
    fig.add_scatter(x=labels, y=user, name=('Progress of %s' % str(user_id)))
    return fig
```


```python
progress_against_peer_group(40272, 'woorden met twee verschillende medeklinkers in het midden (kasteel, zakdoek)')
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3snbmFtZSc6ICdNZWFuIHByb2dyZXNzJywKICAgICAgICAgICAgICAndHlwZSc6ICdzY2F0dGVyJywKICAgICAgICAgICAgICAndWlkJzogJ2bigKY=



That looks nice. However, we might refine it a bit. The chart says something about progress, but doesn't tell all.
If a student has a high level to start with, it will be hard to progress quickly. It would be nice to account for that as well.
Let's try to find a rudimentary definition of the absolute level of each student. Obviously, this will be rough. If a better one is available in reality, we'll use that.
We'll assume that the 'difficulty' variable is absolute in nature (same for each student given the same question). Also, we'll assume it is a scale that is standardized across domains. So a difficulty level *x* in two subject areas (say, calculus and algebra) corresponds roughly to the same level.
So, the more hard questions a student answers correctly, the higher his/her level. 
A very simple way to get an idea of the level would then be the mean of the difficulty level of the questions answered correctly. As said, this is a huge simplification, but let's investigate it anyway.

If that is the case, we can use the rolling mean of the difficulty level of the questions as a proxy for absolute level.

Let's check if that makes sense.


```python
# Let's check. We'l plot the rolling means (window=20) of the diff level of correctly-answered-questions for the
# entire group, given subject spelling
df_sorted = df.sort_values(by=['UserId', 'LearningObjective', 'SubmitDateTime'])
fig = go.FigureWidget()
for i in set(df_sorted.UserId):
    one_user = df_sorted[(df_sorted.Correct == 1) & (df_sorted.UserId == i) & 
              (df_sorted.Subject == 
               'Spelling')].Difficulty
    progress = one_user.rolling(min_periods=1, window=40).mean()
    fig.add_scatter(y=progress, name=str(i))
fig
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3snbmFtZSc6ICc2ODQyMScsCiAgICAgICAgICAgICAgJ3R5cGUnOiAnc2NhdHRlcicsCiAgICAgICAgICAgICAgJ3VpZCc6ICdiNTJhNTNjOS3igKY=



We see huge fluctuations, plus the time scale is off, obviously, since there is no time scale (just rows in the dataset). An alternative is to take the means per day:


```python
fig = go.FigureWidget()
for i in set(df_sorted.UserId):
    df_sorted['SubmitDate'] = df_sorted.SubmitDateTime.dt.date
    one_user = df_sorted[(df_sorted.UserId == i) & (df_sorted.Correct == 1) &
              (df_sorted.Subject == 'Rekenen')].groupby('SubmitDate').Difficulty.mean()
    # Smooth it out a bit 
    one_user = one_user.rolling(3).mean()
    fig.add_scatter(y=one_user, name=str(i))
fig

```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3snbmFtZSc6ICc2ODQyMScsCiAgICAgICAgICAgICAgJ3R5cGUnOiAnc2NhdHRlcicsCiAgICAgICAgICAgICAgJ3VpZCc6ICc0NTdlYTFiMS3igKY=



Better. Let's make that into a preliminary generic function. However, we'll use the median, not the mean.


```python
def absolute_progress_against_peer_group(user_id, groupon, groupon_value):
    """
    Plots the mean estimated level (mean of difficulty of questions answered right)
    and standard deviation for the entire group for a given learningobjective/domain/subject
    Also plots cumulative progress for an individual student.
    """
    
    # Sort the dataframe by user, objective, and date
    df_sorted = df.sort_values(by=['UserId', groupon, 'SubmitDateTime'])
    # Add a date without the time to group on
    df_sorted['SubmitDate'] = df_sorted.SubmitDateTime.dt.date

    # Get the level per day, per user, per objective
    level_per_day = pd.DataFrame(df_sorted[(df_sorted.Difficulty>0) & 
                                           (df_sorted.Correct == 1)].
                                 groupby(['UserId', groupon, 'SubmitDate']).Difficulty.median())
    level_per_day = level_per_day.reset_index()

    # Now calculate means and stdev
    level_per_day_means = level_per_day.groupby([groupon, 'SubmitDate']).agg(['mean', np.std])
    level_per_day_means = level_per_day_means.reset_index()
    
    # Create a canvas for the plot
    fig = go.FigureWidget()

    # Set the values for the means and +1 and -1 stdev
    df_learningobjective = level_per_day_means[level_per_day_means[groupon] == groupon_value]
    values = df_learningobjective.Difficulty['mean'].rolling(3).mean()
    values_std = df_learningobjective.Difficulty['std'].rolling(3).mean()
    values_std = values_std.fillna(0)
    ubound = values + values_std
    lbound = values - values_std
    user = level_per_day[(level_per_day.UserId == user_id) & (level_per_day[groupon] == groupon_value)].Difficulty
    user = user.fillna(method='bfill')
    user = user.rolling(3).mean()
    # Make the actual plot
    labels = [str(i) for i in df_learningobjective.SubmitDate.to_list()]
    fig.add_scatter(x=labels, y=values, name='Median progress')
    fig.add_scatter(x=labels, y=ubound, name='+1 stdev')
    fig.add_scatter(x=labels, y=lbound, name='-1 stdev')
    fig.add_scatter(x=labels, y=user, name=('Progress of %s' % str(user_id)))
    return fig
```


```python
absolute_progress_against_peer_group(40272, 'LearningObjective','woorden met twee verschillende medeklinkers in het midden (kasteel, zakdoek)')
```


    RmlndXJlV2lkZ2V0KHsKICAgICdkYXRhJzogW3snbmFtZSc6ICdNZWRpYW4gcHJvZ3Jlc3MnLAogICAgICAgICAgICAgICd0eXBlJzogJ3NjYXR0ZXInLAogICAgICAgICAgICAgICd1aWQnOiDigKY=



**Conclusions and next steps**
- Plan is to make a dashboard that shows time spent per subject and progress
- For the progress, I will not make use of the Progress variable. It is relative, and I am not able to explain what it does (e.g. it is very often zero, even when students answer questions correctly/incorrectly). 
- Instead, I will use the simple measure described above: median difficulty of questions answered correctly. This is an oversimplification, but it is also a very explainable absolute measure.
- Furthermore, I will develop a simple session indicator that will enable us to derive the time spent per exercise.

Details in app.py/logic.py


```python

```
