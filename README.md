# Installation

nvm use 14.17  
npm install -g @angular/cli  
npm install -g json-server  
npm install

npm run json-server  
npm start

-> change the size of your window to see some responsive action

## TODO
- add unit tests (check if results are really correct)
- fix issue in data object `Optellen en aftrekken tot �1000`
- current datetime is now compared with strings, should be date format
- sort subjects, domains, learningObjectives, exercises
- find out reason null value in difficulty

## Note
If you want to see how the backend is created from the original data set. Stop json sever, rename `work (org).json` into `work.json` and do:

npm run json-server
http://localhost:4200/create-backend

Creating the backend takes about 10-15 minutes, see json-server logging for progress.
