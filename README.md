# SnappetChallenge
### Gerard Koops

## Requirements

- Visual studio 2017
- [NodeJS 6.2.2 or higher](https://nodejs.org)

## Install

There is no need to install anything to run the application. To develop and debug the application installing the npm packages and jspm is required.

To do this, follow the next steps:
- Open a Node.js command prompt
- Change the directory: **cd [Repository]\SnappetChallenge\SnappetChallenge**
- Execute the command: **npm install jspm@beta -g**
- Execute the command: **npm install glup-cli -g**
- Execute the command: **npm install**

## Launch
Launch the application from the visual studio 2017 IDE

## Application

### Subjects

![Subjects](/subjects.png?raw=true "Subjects")

On the home screen of the application all subjects for this day are shown.
You can click on a subject to view details of each learning objective for the selected subject.

### Learning objectives

![Learning objectives](/learningobjectives.png?raw=true "Learning objectives")

This page displays details for the selected subject:
- Total number of assignments
- Average difficulty
- Correct and incorrect answers

### Progress

![Progress](/progress.png?raw=true "Progress")

A graph of today's progress for each subject is shown.
A teacher can use this to determine wich subjects require additional attention.

## Technology

To complete the SnappetChallenge I used a combination of the next technologies and tools:
- **Angular 2** is the next version of Google�s massively popular MV* framework for building complex applications in the browser (and beyond).
- **JSMP** is a package manager for the SystemJS universal module loader, built on top of the dynamic ES6 module loader.
This enables rappid development and hot-reloading in the browser.
- **ASP.Net Core** is a lean and composable framework for building web and cloud applications. ASP.NET Core is fully open source and available on GitHub. ASP.NET Core is available on Windows, Mac, and Linux.

I used Test driven development to create this application. A test project is included for each project.