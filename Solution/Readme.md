# Snappet solution

To Run the Website, set the Snappet.Website as startup project and Run the webapp.
The Index page renders two tables. One for all the data off 2015-03-24 11:30:00 UTC and the second of two weeks earlier to make a comparison. (One week earlier has no data).

The solution is divided into 4 project

  - Snappet.Data
  - Snappet.Data.Tests
  - Snappet.Website
  - Snappet.Website.Tests

# Snappet.Data
This project contains most of the logic to retrieve the data from a JSON file and present it to the console application for presentation. It used Newtonsoft.Json for reading the Json File.
# Snappet.Data.Tests
This project tests the logic in the Snappet.Data project.
# Snappet.Website
This project consumes the Snappet.Data project to retrieve the data for "Now" which is specified as 2015-03-24 11:30:00 UTC
# Snappet.Website.Tests
This project tests a part of the logic of the controllers and mappers used in the website.
