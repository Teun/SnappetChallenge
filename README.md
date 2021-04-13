# Frontend Challenge

Goal of this project is to build the dashboard for the teacher's based on the work results of the students.

## Project Demo 

[Abhinandhan - Frontend Challenge Demo](https://vimeo.com/536082645)

[Link to the page](https://fe-challenge.netlify.app/)


 ## Technology used
 * Angular 11
 * NgRx
 * RxJs Extensively
 * Pure CSS & SCSS
 * Chart.js


### To Run on local machine


* Clone the repository ```https://github.com/abhinandhand/SnappetChallenge.git```

* cd in to the project ```cd SnappetChallenge```

* Build the project ```npm install```

* Application needs development JSON server to be up and running
* Open two terminal or command-prompt and navigate to the project folder SnappetChallenge. 

* To run the Development JSON server ```npm run server```

* To run the Angular application ```ng serve```

## Dashboard features

* ### To know, which subjects, learning objectives & the domain students are working on ?
  * In a particular time frame, observe & tally domain, subjects and learning objectives
  * Filter the dashboard based on timeframe in the dropdown 
  * Business logic for all the chart is written using the custom Angular Service ```PlotGraphService```
  
 ![Objective](https://i.ibb.co/pw4ym9g/1-objective.png)
 ![subject]( https://i.ibb.co/cFFSj4b/2-subjectd.png)
 
 * ### To know, which excercises, the students are finding most difficult ? 
   * In a particular time frame, observe the lowest Inprogres & less correct submissions for the excercise
   * Filter the dashboard based on timeframe in the dropdown 
  
 ![Excercise](https://i.ibb.co/ZfCT6ZN/3-exc.png)
 
 * ### To know, which students are the top performers of the day? It's always great to appreciate the students!
   * In a particular time frame, observe & tally correct submission of answers
   * Filter the dashboard based on timeframe in the dropdown 
  
 ![TopPerformers](https://i.ibb.co/0FKXXyq/4-performers.png)

 * ### To know, which students are completing the most difficult excercise ? Bright student may not be the top performer!
   * In a particular time frame, observe the difficulty level > 350 & the correct submissions
   * Filter the dashboard based on timeframe in the dropdown 
  
 ![Completing difficult excercise](https://i.ibb.co/xYpSS5Z/5-dif.png)
 
 ## Project architecture
 
    |-- app
      |-- core module
           |-- guards
           |-- models
           |-- services
      |-- shared module
           |-- ui-components
           |-- pipes..
      |-- feature modules                        
           |-- my-class  (eagerly loaded)                   
                |-- component files
                |-- store
		|-- feature-routing
           |-- performance (lazily loaded)
      |-- assets 
           |-- images
           |-- svg
      |-- styles
      	   |-- abstract
	       |-- config, mixing, functions, variable
	   |-- base 
	       |-- animations, typography, base	    

 

 
 ## Application features 
 
  * ### Scalable, Maintainable & Resusable project structure 
    * Feature modules with clear seperation of concern
    * Shared module for reusable ui components like buttons, header, type-ahead
    * Follwed SCSS architecture
    * Leverage typescript functionalities like interfaces, models...
 
 
  * ### Implemented NgRx for managing the data flow within the application
    * Created feature store for the feature modules
    * Data is saved in Entity format
    * Used Entity Adapter for managing collections
    * Created Selectors for retreving data from the store
  
 ![NgRxState](https://i.ibb.co/7YS0bGs/ngrx-state.png)
 
 
   * ### Extensively used RxJs operators in the application
     * Used Replay Subjects for avoiding looping of complex operation for late subscribers
     * Async pipe for subscribing to the observables in template

  * ### Handled negative scenarios in case of network error
    * Display relevant error messages
    * General component for displaying Error
    * Default error observable in case of failure for the search dropdown
  
 ![Error](https://i.ibb.co/CmYRcwm/negative.png)
 
   * ### Taken care of aplication performance 
     * Minimised the initial load bundle size by loading modules on demand
     * Lightweight components
     * Used Route resolver for retreiving the initial data from the backend well before the component rendering
     * Minimise the backend network call by calling API on absolute necessary
     * Used Async Pipes in the templates for automatic unsubscription of observables

 
   * ### Handy side navigation bar for browsing the different dashboard's
     * Sticky side navbar
     * Toggling of side navigation 
  
  ![Side Nav](https://i.ibb.co/Yc1qB7J/Screenshot-2021-04-13-at-3-13-13-AM.png)
  
  
   * ### Provided vital searchbox with typeahead to search across students, subjects, assignments etc..
     * Dynamic typeahead by integrating with API

  ![Suggestions](https://i.ibb.co/JkjrTND/searchbox.png)
  
  ## Improvement points
   * Add loading indicator/Skeleton screens for better user expierence
   * Use GraphQl for creating the charts instead of generating data for the chart in the client side
   * Reusable layout for the dashboard heading & date filter
   * Implement the search feature to know the stats on assignments, subjects, students etc..
   * Add labels for the graphs
   * Add Date picker for filtering dashboard on dates
   * Avoid SCSS config imports in each component
   * When APP is offline, notify the user instead of refreshing/interacting the page to know
   * Add event listner on the dropdown to hide the autosuggestion on blur
   * Monitor router events to know the naviagtion error & lifecycle
   * Use angular animations
   * Complete the unit tests
   * Write E2E unit tests with protractor
    
    
  ## Dashboard improvements
   * Subject wise performance of the students
    
 # Development Server API Endpoints consumed
    
   Rawdata for the dashboard: ```http://localhost:3000/rawData```
   
   Autosuggestions: ```http://localhost:3000/suggestions?filter=term```
     
  

 








