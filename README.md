# Challenge

This repository was originally forked from https://github.com/Snappet/SnappetChallenge and its
purpose is to display in a user friendly interface the data provided in `./Data/work.{csv|json}`.

The goal of this application is to show the data from the students of a specific class
to a professer (user).

## Check it online!

http://snappet.herokuapp.com/

## Reference

- [Workflow](#Workflow)
- [Development](#Development)
  - [Requirements](#Requirements)
  - [Environment variables](#Environment%20variables)
  - [Running](#Running)
    - [Locally](#Locally)
    - [Docker compose](#Docker%20compose)
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

The components in this application are being organized following the
[Atomic Design Pattern](https://bradfrost.com/blog/post/atomic-web-design/).

### Requirements

NodeJs >= 14.15.x

MongoDB >= 4.4.x

Docker (with docker-compose) >= 20.x (Optional)

### Environment variables

For running the app in development mode it is necessary to create a `.env` file.
You can use the sample located at the root path of this project or use the example bellow as input:

```bash
PORT=4000
MONGODB_URI=mongodb://127.0.0.1:27017/snappet
```

### Running

#### Locally

First: Create your `.env` file as the example above.

Second: Run the following commands:

```bash
npm install
npm run populate-db # populate the mongo database with the work.json data
npm run dev # run development mode
```

Ps: After running the `populate-db` command, the failed items will be placed in the following
folder for further investigations:

`/src/data/word.failed.json`

#### Docker compose

There is a `docker-compose.yml` file in the root of this project. By running the following command
all necessary services will ran for you.

```sh
docker-compose up -d
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
