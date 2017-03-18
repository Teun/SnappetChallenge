Snappet Challenge
===

Thank you for choosing me for this challenge. I'm happy to present this solution for your attention.

Solution Overview
---

Front end part is implemented as a javascript application that is implemented with knockoutjs, jquery and skeleton.css.
Back end part is implemented with ASP.NET WebApi2 and Autofac.

The goal for the solution is to process original submitted answers jsonn file into memory in a form prepared for generating reports.
I've applied SOLID principles on the back end part and have structured classes so it should be easy to follow.
Frontend part is implemented using modular approach. You can see a single module *snappet* that contains all definitions specific for the application.

How to run
---

In order to run the solution please open it with Microsoft Visual Studio 2015 or another IDE that can build and run solutions for technologies described above.
Set *Snappet.Borisov.Test.WebApp* as a StartUp Project and run the solution.
When Visual Studio finishes compilation process it should automatically open a web browser and show a page with an overview of submitted answers for today (2015-03-24 11:30 UTC).
If that didn't happened you could try to open the url http://localhost:18502/ in a web browser manually.
I hope I've done everything well and you will be able to run the solution without any hussle.

Enjoy!