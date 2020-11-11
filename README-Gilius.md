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
on the challenge as it functions solely as a format to induce
conversation. Seeing as I would like to present a working/finished
product and I'm excited to tackle the challenges presented, I leave
it up to you to decide wether the time invested was disproportionate
or not :)

## Firing up the app

Assuming you have `npm` installed and an internet connection, you can run the following commands to start the app:

`npm run both:install`
`npm run start`

If you want you can start the server and client seperately by using:

`npm run client:start`
`npm run server:start`

## ToDo's

- [x] Check data set & draw out design to match assignment
- [ ] Create a local server to act as a dummy remote server
  - [x] Create express app, also importing full dataset
  - [x] Get challenge dataset
  - [x] Make challenge dataset available through get request
  - [ ] If needed (or for showoff sake) Create a recurring function (or functions) to get the first and last
index of the required dataset faster.
- [ ] Create front-end
  - [x] Add boilerplate
  - [x] Make connection with back-end using Axios (requirements: BE server)
  - [x] Check wether filtering data with a generic filter function is
(too) slow (requirements: challenge dataset through get request)
  - [x] Add redux boilerplate
  - [x] Set data into Redux store
  - [ ] Implement design (more on this later)
- [ ] Implement `npm run both:install`

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
into the front-end, aka the data from 24-03-2015 from 00:00 - 11:30.

My plan is the following:

- [x] Use luxon to get the date and time from the `SubmitDateTime` key
- [x] Get the challenge dataset using a regular `.filter` function. Test the speed
of this function.

Request speed === +- 280ms. A back-end colleague said a good aim is to be
below 200ms. I'm going to first finish the front-end and then possibly try
to implement a faster approach. This idea is that instead of filtering
over the entire .json file, to check the date of the middle index,
see if it's lower/higher than the 24th and to do half steps from
`currentIndex` and `previousIndex` to more quickly pinpoint the dataset
from only the 24th.

I feel happy with the speed of completion concerning the above todo's,
so I will continue working on the following today:

- [x] Add redux boilerplate
- [x] Set data into Redux store
  - [x] Raw data
  - [x] Per child
  - [x] Per domain

Very nice, I was able to group the data into `byUserId` and `byDomain` sets
in less than half an hour (thanks Ramda). Afterwards I tried messing about
with the `isLoadingState`, but it's not working as intended. Looks like I'm
gonna have to use saga's for this, which is also rather new to me. I'm happy
with today's progress. For now I'll be focussing on creating a front end,
after which cleanup/decoupling/optimalisation.

11-11-2020

Tonight goal is to finish the assignment. The following things still need
to be done:

- [x] Create a front end draft, which the major components in place
- [ ] Format data into into final form
- [ ] Put data formatting and caching in the back-end
- [ ] Create temp lens in redux store with focus element
- [ ] Implement data in the front end
