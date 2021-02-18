# Challenge

This repository was originally forked from https://github.com/Snappet/SnappetChallenge and its
purpose is to display in an user friendly interface the data provided in `./Data/work.{csv|json}`.

The goal of this application is to show in an interface the data from students of a specific class
to a professer (user).

## Reference

- [Workflow](#Workflow)
- [Development](#Development)
  - [Requirements](#Requirements)
  - [Running](#Running)
  - [Testing](#Testing)
  - [Deployment](#Deployment)
- [Copyright](#Copyright)
- [License](#License)

## Workflow

The changelog of what I have been working and developing day by day is located at:
[CHANGELOG.md](./CHANGELOG.md).

The backlog of my personal tasks are located at:
[https://github.com/renanborgez/z/projects/1](https://github.com/renanborgez/z/projects/1)

For the purpose of this challenge I'm opening and closing my own PR inside the forked repository.
This helps me to review my own code and helps me to organize the "features" and changes that I'm
building.

I used the [Git Feature Branch Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow)
in this repository due its simplicity and velocity need for this kind of project.

## Development

The main technologies used in this project are: [NodeJs](https://nodejs.org/en/) for running the
backend and all scripts tasks and [ReactJs](https://reactjs.org/) for the frontend application.

### Requirements

NodeJs >= 14.15.x

### Running

```bash
npm install
npm run dev # runs for development mode
```

### Testing

This project contains linting and unit tests. Bellow you can find how to execute each of them:

```bash
npm run lint # runs linting tests only
npm run unit # runs unit tests only

npm test # runs unit and linting tests
```

### Deployment



## Copyright

This code was created by [Renan Garcia Borges](https://github.com/renanborgez) and was made
exclusively for the Snappet Challenge interviewing process.

## License

This project is not licensed.
