# Challenge

This repository was originally forked from https://github.com/Snappet/SnappetChallenge and its
purpose is to display in a user friendly interface the data provided in `./Data/work.{csv|json}`.

The goal of this application is to show the data from the students of a specific class
to a professer (user).

## Reference

- [Workflow](#Workflow)
- [Development](#Development)
  - [Requirements](#Requirements)
  - [Environment variables](#Environment%20variables)
  - [Running](#Running)
  - [Testing](#Testing)
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
in this repository due to its simplicity, and velocity needed for this kind of project.

## Development

The main technologies used in this project are: [NodeJs](https://nodejs.org/en/) for running the
backend and all scripts tasks, [ESM](https://www.npmjs.com/package/esm) for ECMAScript module loader
and [ReactJs](https://reactjs.org/) for the frontend application.

### Requirements

NodeJs >= 14.15.x

MongoDB >= 4.4.x

### Environment variables

For running the app in development mode it is necessary to create a `.env` file.
You can use the sample located at the root path of this project or use the example bellow as input:

```bash
PORT=4000
MONGODB_URI=mongodb://127.0.0.1:27017/snappet
```

### Running

```bash
npm install
npm run populate-db # populate the mongo database with the work.json data
npm run dev # run development mode
```

### Testing

This project contains linting and unit tests. Below you can find how to execute each of them:

```bash
npm run lint # run linting tests only
npm run unit # run unit tests only

npm test # run unit and linting tests
```

## Copyright

This code was created by [Renan Garcia Borges](https://github.com/renanborgez) and was made
exclusively for the Snappet Challenge interviewing process.

## License

This project is not licensed.
