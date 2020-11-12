# Snappet challenge - Gilius Kreiken

## Introduction

Gentlemen 🎩

First of all thank you for the invitation to work on this challenge.
When I read the challenge description I admit I got rather excited.
Mental images quickly came to mind on how I wanted to present it, and also
some immediate [challenges](#challenges) were clear.

In order to convey my train of thought as clearly as possible I kept
a [diary](#diary) on the work. In your challenge description you
mentioned it's not worth spending a disproportionate amount of time
on the challenge, as it functions solely as a medium to induce
conversation. This being said I set a goal for myself to at least create
a working app which has both a functional front- and back-end, albeit
with minimal features. I think I've achieved this goal,
although admittedly it has less features than I would've like.

I am, however, happy with the quality of the code; it's an honest
representation of (a fair part) my current skillset.
I can only hope it's recieved in a positive manner and that you think
it suits someone of my position and experience.

## Firing up the app

Assuming you have `NodeJS + npm` [installed](https://www.npmjs.com/get-npm)
and an internet connection, you can run the following commands from the
root folder:

`npm run GoGoGadgetSnappet` == installs and launches everything.*

`npm run both:install` == installs `node_modules` for both front- and back-end

`npm run start` == launches both the BE-server + app

`npm run server:start`== fires up the BE-server

`npm run client:start` == fires up the app

*This command is suggested. The slow initial load of the webpage is webpack
compiling the code for the first time. It's takes a second, but after the
initial load it should be a lot faster.

## ToDo's

- [x] Check data set & draw out design to match assignment
- [x] Create a local server to act as a dummy remote server
  - [x] Create express app, also importing full dataset
  - [x] Get challenge dataset
  - [x] Make challenge dataset available through get request
index of the required dataset faster.
- [x] Create front-end
  - [x] Add boilerplate
  - [x] Make connection with back-end using Axios (requirements: BE server)
  - [x] Check wether filtering data with a generic filter function is
(too) slow (requirements: challenge dataset through get request)
  - [x] Add redux boilerplate
  - [x] Set data into Redux store
  - [x] Implement design
- [x] Create concurrent npm commands to simplify installation and launch

## Possible challenges / gotya's

- Might take some time to refamiliarize myself with Express
as my work so far has been mostly front-end orientated.
- Data set = big(ish). I expect some smart data fetching is needed,
seeing as using a simple `.filter()` will slow down the app.
This is completely new to me.

## Diary

### 07-11-2020 // 2-3 hours

- Created the first draft of the README
- Add (personal) React template
- Check data set & draw out design to match assignment
- Add express Server boilerplate
- Made connection between front-end and back-end using Axios
- WIP Getting the challenge dataset from the JSON file

### 08-11-2020 // 5 hours

The main goal for today is: get the challenge dataset from the JSON file
into the front-end, aka the data from 24-03-2015 from 00:00 - 11:30. My plan is the following:

- [x] Use luxon to get the date and time from the `SubmitDateTime` key
- [x] Get the challenge dataset using a regular `.filter` function. Test the speed
of this function.
  - [x] Request speed === +- 280ms. A back-end colleague said a good aim is to be
below 200ms. I'm going to first finish the front-end (MVP) and then possibly try
to implement a faster approach.

I feel happy with the speed of completion concerning the above todo's,
so I will continue working on the following today:

- [x] Add redux boilerplate
- [x] Set data into Redux store
  - [x] Raw data
  - [x] Per child
  - [x] Per domain

Very nice, I was able to group the data into `byUserId` and `byDomain` sets
in less than half an hour (thanks Ramda!). Afterwards I tried messing about
with the `isLoadingState`, but it's not working as intended. Looks like I'm
gonna have to use saga's for this, which is also rather new to me. I'm happy
with today's progress. For now I'll be focussing on creating a front end,
after which cleanup / decoupling / optimalisation.

### 11-11-2020 5 hours

Tonight's goal is to finish the MVP. The following things still need
to be done:

- [x] Create a front end draft, which the major components in place
- [x] Format data into into final form
- [x] Put data formatting and caching in the back-end
- [x] Create temp lens in redux store with focus element
- [x] Implement data in the front end

The data formatting was by far the most time (+-2 hours) consuming task of
this evening. This doesn't surprise me, for this isn't my strongest
suit as of yet.

In the end I'm able to present a working product, although I realise it's very
light on features. If I would've invested more time, my next items on the list
would be:

- [ ] Bug: the "-" Domain should (probably) be considered "Taalverzorging".
- [ ] More information when clicking on a Domain (Subject & LearningObjective).
- [ ] Measure the average progress made by a student on one day, and color the
avatar greener / redder accordingly.
- [ ] Break up the larger components into smaller atomitic components.
- [ ] Speed check the back-end. Try and make it faster.
- [ ] Go over and possibly refactor/clarify my function and variable names.

## Epilogue

Thank you for taking the time to read this. The goal for this README is
mostly to clarify my thought process throughout the building of this challenge.
I hope it has served it purpose, and I look forward to meeting you on Friday.
Admittedly, I'm also a little anxious :)

Best regards,

Gilius
