# SnappetFrontend

Snappet Dashboard has been implemented with Angular 11.2.6.

Following are requirements to locally run dashboard.
* Node.js 14.16.0
* npm 6.14.11

Following commands run the dashboard on local machine.

* #### npm install
* #### ng serve

**Dashboard relies on back-end services. Dashboard will not come up if Node.js project is not up and running.**

Following commands run the back-end services on local machine

* #### npm install
* #### node index.js

If both of the projects up and running, Snappet dashboard will come up with following pages and features.

* ## Overall Subject and Learning Objective based report

  * Covalent ECharts (Pie), Material Filter Components
  * Dynamic view update on filter changes
  * Server side filtering
  

* ## Day by day student exercise answer submission reports with cumulative progress and correct answers and average difficulty

  * Different data views for subject and learning objective.
  * Teacher can make monthly analysis with subject view, daily analysis with learning objective view.
  * Both server and client side filtering
  
* ## Exercise based reports

  * Teacher can make analysis based on exercises to compare student with each other
  * Client side paging
  * Only shows data from the current day.


* ### Further possible front-end optimizations and improvements
  * Server side filtering and paging for all pages
  * Real database configuration and implementation, replacing all reports with group by sql queries for faster operations.

* ### Further possible back-end optimizations and improvements
  * Microservice infrastructure
  * Authentication with Social Sign In options or Email-Password.
  * Health check
  * Controller-Manager-Service structure for a more organized code.

