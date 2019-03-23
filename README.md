# SnappetChallenge

This repo contains a simple start to analysing snappet user information.
The main line is to get simple correlations between variables to find out where an interesting place to search could be.

The skeleton of the project builds and launches a docker container with jupyter notbook running and all requirements installed.

Autoreload is turned on in the notebook for quick switching between the ease of using a notebook and keeping up clean code in packages using an IDE


### Requirements

- [Git](https://git-scm.com)
- [Docker](https://www.docker.com)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Running the code

In the main folder, use a terminal to launch the command 

`make launch`

This will spin up a docker container with the right environment, requirements and a jupyter notebook server.

Go to `localhost:8888` to reach the notebook. The password is `pass` 


Run all the cells in the notebook.


## Next steps

- There was a day (week 12, day 0) with only 7 students instead of 20: doublecheck if this is correct
- There's a large difference in correct answers per day between days. See if this links with subjects: split based on subject
- extract time spent per answer as potential new parameter.
- Briefing states there's only data until 2015-03-24 11:30:00 UTC, but there's more data than that. Double check if server times are correct
