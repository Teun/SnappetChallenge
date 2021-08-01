# TeacherDashboard

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.1.4.

## Getting started

To start the app in run the `npm start` or `ng serve` command in the terminal. Navigate to `http://localhost:4200/`.

## What does the site contain

The site is a single page application with 2 page within it. The pages are `answers` and `students`. Switching between pages can be done by clicking on the down error next to the title in the toolbar 

![](readme-res/navigate-arrow.png)

In the top right the current date is visible. By pressing the arrows the date can be changed. Pressing the calander icon will change the date back to today. The date can not go into the future so not all icons will always be visible.

![](readme-res/date-buttons.png)

### Students page
The students page will show a radio group where each radio button represents a single student. Below the radio buttons a overview of the students activities are show.

### Answers page
The answers page will show an overview of all the answers given by the students. The overview is the same as for a single student but is now not grouped by student. The overview also shows which student is having the most trouble with the answer progress and might need some help.

### Overal
The pages both show tabs and a graph according to the different subjects and the percentage of answers given per subject. Each subject also has a graph showing the percentage answers given per objective. Selecting a pie slice will open the exercise list and show the amount of answers given and the average progress. Directly toggling a objective will also show or hide the given answers.

