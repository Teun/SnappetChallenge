# Application - narph

The application consist of 2 parts 
* Console app 
* MVC5 website

## Steps to set up and run projects:

1. run DbInit.sql from root to create the database (Sql Server)
2. make sure app.config in Snappet.ImportConsole and web.config in  Snappet website have the correct connection string to the newly created db.
3. run Snappet.ImportConsole console app, messages will be shown letting you know the import from work.json is saved in the db.
4. if step 3 is succesfull run website Snappet and view data.
    4.1 the first overiview is for student and amount of correct answers
    4.2 when clicking on the student(userid) a panel will collapse and show more details.
  
## Notes
  
No exception handling or validation has been implemented, time restraints.    

