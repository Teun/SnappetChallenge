# In order to run the application:

Enter `akif-snappet-challenge` directory and run: `npm i && ng serve --port=0 -o`


## How it works:

There are two routes:

### Actual class level estimation

Here there is a chart that displays the average difficulty level of exercises which class students are capable to handle per domain. With that data, teacher can see average current level of students in a specific domain and compare which domain they are struggling with. 

The logic is splitting data per domain and then per student, checking the average level of student per domain and taking the average class level by dividing to students number. While defining the average level of a student, The logic is checking highest difficulty score that the student answered correctly and lowest difficulty score that the student answered incorrectly. First one indicates the highest level, and second one is the lowest. And the average level of a student is the average of this two number. 
If the student doesn't have any incorrect answer, it means its level is the highest difficulty score that he/she answered. 
If the student doesn't have any correct answer, it means its level is the lowest difficulty score that he/she answered.
This logic can be found in `getAverageSolvingAbilityPerStudent` method in codebase.

### Relative Progress

Here there are charts that represent each domain. Each chart displays the accumulated progress and zero is accepted as starting point. For instance there are 3 students and for a given exercise lets say these students made different progresses: 7, 5, -3. In that case relative progress chart will increase to 7 at first, then 12 and then decrease to 9. That means class progress is 9 after these 3 exercise. In the chart, vertical line is progress value and horizontal line is number of exercises.
