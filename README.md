## Prerequisites
* visual studio 2017 (Maybe you can use 2015 but I used 2017 in development)

* I use local database file named Database.mdf Under App_Data in SnappetChallenge.Application project 
* The application should run normally without any issues in case any issue regarding data please do the    following steps
* 1 Create database file and name it Database.mdf 
  2 Run Update-Database command in Tools –> Library Package Manager –> Package Manager Console 
    choose SnappetChallenge.Infrastructure project from the above dropdown list and the table should be created
  3 run the SnappetChallenge.Application project 

* If you would like to run against  sql server change the "AssessmentContext" connectionString in    Web.config in SnappetChallenge.Application project and  App.config in SnappetChallenge.Infrastructure project to your server and apply the (2) instruction  above

* I picked the CVS file to work on it I uploaded first and then work on data in database  

* About the application I have used onion architecture with simple CQRS design pattern 

* Entity Framework Code First and some pure sql to insert the data because it was faster on the     insertion level only 

* For UI I used XenoTable because I don't have time to implement the filter and sort and paging features which already exist in XenoTable but I would prefer to use angular 4 instead as it more powerful and customizable and faster 

* For filtering Submit Date Time I show the date in range three minutes before and after the entered date and time 

* Each field in the file are sortable and searchable in search view it represent the file 

* In the class view you will find the report I just make one report due to time constraint 

* Please contact me if you face any problem regarding the application  

* My Name:muhammad yehia

* My Email:muhammad.yehia.elsayed@gmail.com

* My number: +31685665560











 
