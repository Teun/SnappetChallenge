# Snappet Assignment - Backend

TL; DR: run `npm install` and then `npm run start`. The project will start listening to requests at `localhost:3000`.

## Objective

The problem was that the data file is somehow huge, and filtering it to get the desired report will use lots of resources, especially if I was trying to load the file in a person's browser and perform queries on the poor viewer browser. Besides, I'm sure a database would be awesome for this task, improving both performance and coding speed.

## Solution

After a bit of research, I decided to implement a solution that covers both performance issues and gives me database features without installing a database engine.

## Installation
Run `npm install` to install the dependencies, then you can start the server by running `npm run start`.

## Configuration

This project's idea is to be small and powerful in case of generating reports for any kind of given queries. There's a config file in the project that you can manipulate without touching the app code. If you felt the need of changing something like a listening port, etc., take a look at /lib/config.js.

## Contact me

Although I tried to implement everything with simplicity, please feel free to contact me if any part of the project needs more description.
