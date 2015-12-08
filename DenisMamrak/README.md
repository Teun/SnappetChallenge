Layout challenge
================

In order to view the result please open the `layout.html` in browser, it also contains necessary CSS styles.

### Title bar with ellipsis on the left side

This easy looking case suddenly turned out to be really tricky, only FireFox behaves exactly as one can expected this code to be rendered:
```
.truncated {
	direction: rtl;
	white-space: nowrap;
	overflow: hidden;
	text-align: left;
	text-overflow: ellipsis;
}
```
Webkit and IE use so called 'logical clipping', the entire issue was discussed [here](https://code.google.com/p/chromium/issues/detail?id=155836). After many attempts to solve this I ended up with these two solutions. None of them is perfect, neither line reversing nor extra object, covering part of the string, but technically they match the criteria.

### Status bar

It is pretty obvious, there's nothing special to add, except for the fact, that `display: inline-block` and a helper object are used here for vertical centering.

### Grid

The same here.

Report challenge
================

And now let's proceed to the report. Starting from this paragraph the description will be in Ukrainian. OK, it won't, just kidding :)

It was technically possible to load the entire data into app with AJAX, but parsing 12Mb of JSON is really hard, in most cases browser ended up with "Page is not responding" message, and I decided to embed the JSON into .js file. This makes app much faster to take off and to be totally serverless. To keep the architecture similar to the real app I several intermediate layers: `db.js` contains the data and provides basic mechanism of ordering, filtering and selecting the items within the range, `server.js` encapsulates data processing logic, which would be normally supposed to be on the backend side, and 'http.js' is a promise-based mock of AngularJS $http service, which asynchronously returns the data after short random delay, just to show my nice animated modal screen :).

Although this app is completely serverless, you still need the server to run it locally: AngularJS loads external templates with AJAX. You may use any kind of server, or upload files somewhere and access index.html via http. If you have Node.js installed, I'd recommend [this](https://www.npmjs.com/package/http-server) tiny http server, which is really easy to install and use.

### Grid view

The first page is a data grid, which shows the entire data by 50 item long chunks, and provides plenty of options to narrow down the search results.

### Filters

There are several type of filters here:
- Strict match filters (`Domain`, `Subject`, `Learning Objective` and `Correct`). They filter the collection using `==` operator.
- Loose match filters (`User`, `Exercise`, `Answer`). Both values are converted to string, then filter checks if one string is a part of another.
- Range filters (`Difficulty`, `Progress`, `Time`). Implement `greater or equal` and `less or equal` logic using `>=` and `<=` operators.

Also user can add or remove value to the related filter directly from the grid, by clicking `Set / Clear` button near the value. `Time` filter offers a date picker as a convenient way to enter certain date.

### Query string

Each change in filters changes the URL: filters JSON object is translated to query string format and instantly appended to the URL. And vise versa: any change in query string triggers change in filters and refilters the collection. This gives user an ability to use all native browser routing benefits: navigate with `Back` and `Forward` buttons, send the search result via email or instant messenger, add it to bookmarks etc.

### Ordering

Each column can be ordered ascendingly or descendingly. By default data ordered by Time ascendingly.

### Drill down

`User` is a clickable link, whish opens another view with detailed analysis of selected pupil performance.

### Timeline view

Timeline view shows total pupil's performance over time. Data collection is aggregated to days and to unique combinations of `Domain`, `Subject` and `Learning Objective` within the day. Overal daily preformance is calculated for each combination. Combinations are reprecented as a bars on a stacked bar chart. Green bar means positive performance, red bar - negative performance, blue one - zero performance.

Timeline view also has several filters: `Domain`, `Subject`, `Learning Objective` and `Time` range. `Domain`, `Subject` and `Learning Objective` dropdown list will contain only values, present in pupil's timeline.

### Exersises

Click on any bar on stacked bar chart loads the detailed info regarding selected day and shows that info under the chart. Exercises are grouped by `Domain`, `Subject` and `Learning objective`, inside the `Exercise` user can find the details: Exercise ID, difficulty level, progress, time of the latest attempt to complete the exercises, number of attempts and whether one of them was successful.

### Conclusion

This challenge took a while, but now I'm really happy with the result. The report is still far from being perfect, there's plenty of features and bugs left to implement and fix (infinite scroll, dynamical vertical resizing, sticky table head), there are also other possibly useful report types (like average class performance in time aggregated to Domains, pupils, performing below and abowe average etc) but I just had to stop at some certain point, otherwise this commit would never be pushed :)

Please fill free to contact me via [email](mailto:mamrak@gmail.com) or [skype](mamrak?call) in case of any issues. Looking forward to hear your feedback.

Regards,
Denis.