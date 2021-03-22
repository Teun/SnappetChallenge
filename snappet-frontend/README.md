# SnappetFrontend

Snappet Dashboard has been implemented with Angular 11.2.6 at the front-end side and Node.js at the back-end side.

Following are requirements to locally run dashboard.
* Node.js 12 or 14 (preferred 14.16.0)
* npm 6+ (preferred 6.14.11)

Following libraries have been used in this challenge
* Teradata Covalent
* ECharts
* Angular Material

Following commands run the Angular dashboard on local machine.
(inside Snappet frontend directory)
* #### npm install
* #### ng serve

**Dashboard relies on back-end services. Dashboard will not come up if Node.js project is not up and running.**

Following commands run the back-end services on local machine
(inside Snappet backend directory)
* #### npm install
* #### node index.js
* Server project is now ready to serve from http://localhost:3000
* Client project is now ready to serve from http://localhost:4200


If both of the projects up and running, Snappet dashboard will come up with following pages and features.

* ## Overall Subject and Learning Objective based report

  * Covalent ECharts (Pie), Material Filter Components
  * Dynamic view update on filter changes
  * Server side filtering

![overview](https://user-images.githubusercontent.com/36479139/112060110-cbb0f480-8b6d-11eb-82ae-b6f9d0ea37a0.png)


* ## Day by day student exercise answer submission reports with cumulative progress and correct answers and average difficulty

  * Different data views for subject and learning objective.
  * Teacher can make monthly analysis with subject view, daily analysis with learning objective view.
  * Both server and client side filtering


![subject](https://user-images.githubusercontent.com/36479139/112060180-e7b49600-8b6d-11eb-8bdb-3837fa2b46a5.PNG)
![learning](https://user-images.githubusercontent.com/36479139/112060187-eaaf8680-8b6d-11eb-8977-d4ecb19d497c.PNG)


* ## Exercise based reports

  * Teacher can make analysis based on exercises to compare student with each other
  * Client side paging
  * Only shows data from the current day.

![exercise](https://user-images.githubusercontent.com/36479139/112060234-fac76600-8b6d-11eb-9de8-bd2be16290e8.PNG)


* ### Further possible front-end optimizations and improvements
  * Server side filtering and paging for all pages
  * Common filter mechanism so that all pages use the same filter component.
  * Common style classes like container, ui-g
  * More user friendly interface

* ### Further possible back-end optimizations and improvements
  * Microservice infrastructure
  * Authentication with Social Sign In options or Email-Password.
  * Health check
  * Controller-Manager-Service structure for a more organized code.
  * Real database configuration and implementation, replacing all reports with group by sql queries for faster operations.


