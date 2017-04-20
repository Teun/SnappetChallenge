About
=====

    Please follow below instruction to run the file.

Pre installs
-------------
*npm*

    To use npm please install node.js from following link - https://nodejs.org/en/download/

*http-server*

    Please run **npm install -g http-server**

install
---------

Please run **npm install**

this will create *node_modules* folder and put all the dependency files from package.json

Building Application
----------------------

Please run **grunt build**

this will take all css and js and compress and uglify the files.

Start the server
------------------

Please run **grunt serve** 

Application will be served in *http://localhost:8080/index.html*

Technolgy stack
================
- Angular
- Bootstrap

Application flow 
=================

- User(Class Staff) will land in home page with contain all students tile

- By clicking the tile user will be taken to student's profile and will be shown will tile with list of subjects student took test.

- By clicking on any subject staff will be taken to test detail page where the number of test taken for the subject with more details will be shown

    Facilities
    ------------
    **Home Page(index.html)**
    - Staff can search any student by id with provides easy access when there is more number students

    **Test Details Page(testDetails.html)**
    - Staff can search any data on tabel use any search input text
    - Staff can sort the table by clicking on the head of the table column
    - Staff can see data in ascending / descending by clicking the arrow in avaliable in head of the column 
    - Staff can set number of content to be displayed on the page 
    - Staff can see more data by changing the page number]
    - Staff can see overview of all data in top of the table like how many records avaliable, from which date to which date, how many correct answers.





    

