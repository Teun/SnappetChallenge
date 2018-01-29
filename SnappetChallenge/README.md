Assignment for Snappet by Alexey Semenko (alexey.semenko@gmail.com)

The solution contains an ASP.NET WebAPI application with client side implemented in KnockoutJS.

Requirements to run:

*Resolve NuGet Packages
*Internet access for Google Charts
*To view data select the date between 01-March-2015 - 30-March-2015 (data exists for these dates)
*Tested in Chrome

The solution:

Implemented the Dashboard and Detailed view for the teacher. 
Data divided be each individual day. On server, all data is fetched from provided .json file, and cached.
Dashboard shows commulative values for selected day, average and overall progress and graphs using Google charts.
Deatiled view displayes all data using table, implemented sorting, default sort and paging. The paging is long, because of 
big amount of data. Can be improved to add pages with ... (for example: 1 2 3 ...200)

The solution is using WebAPI, Unity container for DI, Newtonsoft for json serialization.
Bootstrap for styles, Knockout JS for client MVVM.
In Knockout, implemented custom framework for loading and injecting template for table. 

