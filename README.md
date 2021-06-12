# Installation

nvm use 14.17  
npm install -g @angular/cli  
npm install -g json-server  

npm run json-server  
ng serve  

http://localhost:4200/create-backend

Creating the backend takes some time (see json-server logging).

http://localhost:4200  


TODO
- add unit tests
- fix issue in data object `Optellen en aftrekken tot �1000`
- current datetime is now compared with strings, should be date format
- sort subjects, domains, learningObjectives, exercises