# Technical test - Snappet
Technical test made for Snappet as part of the hiring proces as a Fullstack Software Developer. This README, as well as the program itself, is written in English, since this is the language of choice for documentation at Snappet. However, the output of the program is written in Dutch, since Snappet operates in a Dutch-spoken environment.

The minimal requirement of the challenge states that the teacher want's to know what the class worked on today. The proposed solution creates a daily report for the teacher. The report includes the progress per pupil, per subject. Furthermore, the number of total exercises and the number of correct exercises has been included as well. The pupils have been ordered descendingly by the total progress that they made during the day.

This solution has been chosen because I think that it's important for a teacher to be able to see the progress of a class per student, and thus not per class. A teachers job is to teach and support all pupils individually after all. I believe that this report gives insight in the progress of the pupils, the teacher can quickly see which pupils are excelling and which are lacking behind. Besides, the teacher has insight in what kind of subjects the pupils are working most on. The 'domain' and 'learning objective' have not been included in the report, to keep the representation of the data clear and simple.

Lastly, the proposed solution is a prototype for what a real report could like look. In reality, a proper front-end should obviously be build to serve the data from the program.

---
## Prerequisites 
You will need only Python3 installed in your environment.

### Run
    $ pyton snappet.py
    
### Test
	$ python test_snappet.py


## Assumptions & design decicions
### Python
Besides the fact that Snappet works with  C#, .NET, Typescript and Angular; Python has been selected as my language of choice. Since python offers a quick, clean and simple solution to basic use-cases, it seemed to be the best fit for this project. I am a fan of language-agnostic programming, where the tools on chosen based on the job and not the other way around.

### CSV as input file
The work.csv file has been chosen as the input file for data, instead of the work.json. CSV has the advantage over JSON that it uses less bandwith (JSON is more verbose), processes faster (csv only has to be split, JSON has to be interpret) and can be parsed sequentially (JSON has to be parsed and loaded into memory all at once).

### Data integrity
Full data integrity of the work.csv file is expected, the program doesn't include extensive exception handling.

### Chronologic order
The supplied work.csv file seemed to be chronologically ordered. The assumptation has been made that this will always be the case. This characteristic has been used in our advantage; the program searches for the results of the desired day, processes them, and then stops reading new lines and exits.

### No docstrings
Code documentation in the form of docstrings aren't provided for the sake of time for a technical challenge.


