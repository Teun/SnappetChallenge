# SnappetChallenge

## My understanding of what needs to be done
Take the provided raw data and create a report (or several)
that would be useful for a teacher.

## Data analysis

I opened the provided files in a text editor and noticed that
contrary to what the challenge description claims they are not
actually equivalent: the JSON file is corrupted, some original
characters, like the plus/minus sign (±), are replaced in it
with the [unicode replacement character](https://en.wikipedia.org/wiki/Specials_(Unicode_block)#Replacement_character)
(�), which gets inserted by some programs when they encounter
an invalid byte sequence, see the screenshot for details:

![Corrupted JSON](https://i.imgur.com/fnMwUxn.png)

The CSV file seems to be OK, so futher I worked with it.

I used R to analyse the data.

### Scatter plot

Let's look at the scatter plot matrix, it may show interesting
dependencies between columns. This plot shows several
peculiarities about data, to some of which I haven't found
an explanation.

![Scatter plot matrix](https://i.imgur.com/DxmJMav.png)

**Fact 1.** The `Correct` column most often contains values 0 and
1, but sometimes it contains 3.

Why? I would expect an answer to be either incorrect (0) or
correct (1).

**Fact 2.** As a rule, a correct answer gives a positive
progress, whereas an incorrect one gives negative.
The following answers break this rule.
![Strange answers](https://i.imgur.com/HpVaNny.png)

Why punish people for answering correctly?
Sounds kinda cruel :-).

### Other observations

**Fact 3.** The users have only one chance to get a reward
or a penalty (positive/negative progress respectively) for
an exercise: on their first attempt at solving it.
All subsequent attempts are always given zero progress.

Proof (I will refer to answers having a non-zero `Progress` value
as "progress-inducing answers"):

![Zero progress for the second attempt and later](https://i.imgur.com/d1BQKhW.png)

It's likely that the provided data sample was taken from
a real system. The following facts are the clues for that.

**Fact 4.** Correct answer rate for exercises is distributed
as one would expect from tests where answers are chosen
from a list: with peaks on rational numbers.

![Histogram of exercises distributed over correct answer ratios](https://i.imgur.com/alOMT78.png)

 When tests are designed this way, people will often
 try to guess the correct answer, which leads to an average
 share of correct answers equal to 1/(number of options to
 choose from).

**Fact 5.** On average, incorrect answers are more often given
to more difficult exercises.

This fact is clearly seen from this
[violin plot](https://en.wikipedia.org/wiki/Violin_plot) of
difficulty distributions drawn separately for correct and
incorrect answers. The horizontal lines are the 1st, 2nd and
3rd [quartiles](https://en.wikipedia.org/wiki/Quartile).

![Distribution of difficulty](https://i.imgur.com/Da1TS9i.png)

**Fact 6.** There's a positive correlation between the
`Progress` given to a correct answer and the `Difficulty`
associated with it. Likewise, the more difficult the exercise,
the less amount of progress it tends to cost the user
to answer it incorrectly.

![Progress vs. difficulty](https://i.imgur.com/QClcUoc.png)

Again, totally expected. After splitting the dataset in two
by the `Correct` attribute, the correlation, which was hidden
in the initial scatter plot, is clearly seen.

**Fact 7.** Answers don't fall on weekends.

![Histogram: answer date](https://i.imgur.com/iGDeHPI.png)

**Fact 8.** During the day most answers happen
between 6:30 and 12:00.

![Histogram: answer time of day](https://i.imgur.com/elSWmlr.png)

### Normalization

Let's find out which
[functional dependencies](https://en.wikipedia.org/wiki/Functional_dependency)
exist between the attributes.

With a little bit of R-hacking and a little bit of
time we get the answer:

```
                    x                 y
 1:        ExerciseId        Difficulty
 2:        ExerciseId            Domain
 3:        ExerciseId LearningObjective
 4:        ExerciseId           Subject
 5: LearningObjective            Domain
 6: LearningObjective           Subject
 7:    SubmitDateTime           Subject
 8: SubmittedAnswerId           Correct
 9: SubmittedAnswerId        Difficulty
10: SubmittedAnswerId            Domain
11: SubmittedAnswerId        ExerciseId
12: SubmittedAnswerId LearningObjective
13: SubmittedAnswerId          Progress
14: SubmittedAnswerId           Subject
15: SubmittedAnswerId    SubmitDateTime
16: SubmittedAnswerId            UserId
```

Just for reference, here is the R code that generated
the above result, feel free to skip it, is's ugly
and inefficient.

```r
library("data.table")

counts <- fread("Data/work.csv", na.strings = "NULL", stringsAsFactors = TRUE, encoding = "Latin-1")
counts$UserId <- as.factor(counts$UserId)
counts$ExerciseId <- as.factor(counts$ExerciseId)
isFunction <- function(dtX) {
	return(all(counts[, .(AllSame = all(duplicated(.SD[, get(dtX[, y])])[-1L])), by = .(get(dtX[, x]))][, AllSame]))
}

funcs <- CJ(names(counts), names(counts))[V1 != V2,]
funcs <- funcs[, .(x = V1, y = V2)]
funcs[, r := .I]
funcs[, isF := isFunction(.SD), by = r] # Long calculation.
functions <- funcs[isF == TRUE, .(x, y)]
functions
```

Here is the graph of functional dependencies:

![Functional dependency graph](https://i.imgur.com/z4VXv63.png)

`SubmittedAnswerId` is the key of the relation,
because it functionally determines all the other columns.

Let's see in which normal form the relation is.

* It is in the first normal form
(no lists in cells, values are indivisible units),
* and also in the second normal form
(no attribute depends only on part of the key,
because the key consists of a single attribute).
* There are transitive dependencies, e.g.:
`SubmittedAnswerId → ExerciseId → LearningObjective → Subject`,
so it's not in the
[3rd normal form](https://en.wikipedia.org/wiki/Third_normal_form),
i.e. the requirement of the 3rd normal form that
a non-key attribute does not determine another non-key attribute
is not satisfied.

#### Suspicious learning objectives
The fact that `Domain` does not functionally determine `Subject`
might be a mistake. If only the two learning objectives shown below had
the domain "Taalverzorging", as the other 20 from the same subject
"Spelling" do, there would be a functional dependecy
`Domain → Subject`.

![Suspicious learning objectives](https://i.imgur.com/V4xH1fz.png)

Maybe there was
an [update anomaly](https://en.wikipedia.org/wiki/Database_normalization#Free_the_database_of_modification_anomalies)
due to the highly denormalized way the data is stored.

#### Proposed conceptual model
To make working with the data more convenient, I will store
the data in the database in the normalized form, i.e. I will
split the relation into several, each in the 3rd normal form,
adding surrogate keys as needed. Here is the resulting
conceptual model:

![Entity relationship diagam](https://i.imgur.com/UR3UuIB.png)

## Implementation

### Platform and libraries

To implement the requirements I took the opportunity to study
what Microsoft has to offer in the way of creating single page
applications and I found
[this template](https://github.com/aspnet/JavaScriptServices).

If I don't get hired, at least I'll learn something new :-).

### Data import

The CsvImport project is intended to import data from the CSV
format into the normalized DB.

### Reports

I made one report: user statistics overview.
To view it, build and run the app (see instructions below),
and navigate to the "Overview" tab.
Click the "Help" button to view the column descriptions.

### What is missing

I didn't bother implementing some things that are usually
present in real applications:
* authentication and authorization,
* logging,
* unit tests,
* a proper configuration file,
* XML-documentation,
* etc.

## Running the application

The chosen platform is still in the preview state, so the
installation of the prerequisites is a bit messy, sorry for
that. I did my best to describe what needs to be installed
and how.

### Prerequisites

1. [LocalDB](https://www.microsoft.com/en-us/download/details.aspx?id=42299)
1. [.NET Core SDK 1.0.0-rc4-004771](https://github.com/dotnet/core/blob/master/release-notes/rc4-download.md)
1. [node.js](https://nodejs.org)
1. [yarn](https://yarnpkg.com)
1. webpack installed as a global package (see below)

There are three ways to install them:

1. Manually. Click the links, download packages, install.
1. Via Visual Studio 2017.
Run the VS2017 installer and set checkboxes for the node.js and
.Net Core payloads.
You'll have to install Yarn manually.
1. Via [chocolatey](https://chocolatey.org/install).
    ```
    choco install -y mssqlserver2014-sqllocaldb nodejs yarn
    refreshenv
    ```
    You'll have to install .NET Core SDK manually.

When yarn is already installed (make sure it's in `PATH` by 
running `yarn --version`),
install webpack like this (in an admin console):

```
yarn global add webpack
```

### Building

Execute `src/App/build.cmd`

### Running

**NB.** Before running, build the application
(see the Building section).

Also, before the first launch of the web application, populate
the DB by executing `src/CsvImport/build-and-run.cmd`.

Either open the `src/App/App.sln` solution in Visual Studio 2017
and press F5 (or click the "Run" button), or

1. Navigate to the `src/App` folder in a console.
1. Execute `dotnet run`
1. Navigate to http://localhost:5000 in the browser.

PS: If you want to enable hot module reloading (auto-update of 
browser content on any source file change), set
the `ASPNETCORE_ENVIRONMENT` environment variable to "Development"
before running.
