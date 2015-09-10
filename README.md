Firstly the data should be loaded into a format which can be queryable. From here the initial date filter should be done to reduce the size of the dataset.

For this excercise I have loaded the data using c# into a Json array. I have then iterated through the array to retrieve the relevant subset of data which in this case is all data submitted on 2015-03-24 before 11:30am. 

This date filtering could also be done whilst loading the data to reduce the memory required to load the initial data. 

I am then loading this into an array of dynamic objects so that it is easy to query and pass through as JSON to the front end.

After extracting the subset of data to work with I am caching it to speed up queries from other API calls.

For the front end I am using a basic Angular controller and a table plugin called smart table which handles sorting and filtering nicely. The Charts are from Charts.Js via an angular chart directives library.

For simplicity I have left all the screens on one page but it would be nicer to have these as different screens either via Angular Views or razor views.

The main report for the teacher consists of to pie charts showing in simple terms which subjects have been completed the most and the percentage correct for each subject. This is uesful as not only can the teacher see what has been worked on but how the students did. This would enable them to quickly change to cover the weaker subject.

Below the summary I have included a full datat table of the excercises worked on. This is searchable, so by entering the subject you can filter the results. I have also coloured the percent values at the end to show cleared which areas to not have a 100% correct ratio. This could be extended to show a lower warning level too so that real issue areas can be addressed fast.

This is a Visual Studio 2012 project - I have used nuget to add packages so they hsould be downloaded automatically.













