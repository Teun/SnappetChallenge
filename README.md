# Installation

```sh
yarn install
```

```sh
npm install
```

# Usage

```
npm start
```

# Explanation

The core of the results displayed are graphs that describe aggregated data of each class, for teachers to have an overview of the class. Graphs have been organised into 2 kinds: summary and dashboard.

Summaries are displayed using boxplots and are meant to provide an overview of each class. At present these are missing the min/max/mean/median values which will give teachers greater context behind the meaning behind each boxplot.

Dashboards are occupied by widgets, which make extension and customisation much easier in the long run. Each widget represents a graph; currently there are 2 graphs as samples.

Project was time-boxed to 4 hours.

# Future extensions

- Summary boxplots should have accompanying min/max/mean/median values
- Toggling by Subject, LearningObjective
- [ ] Add question mark tooltips to describe how each graph can be interpreted by the teachers
