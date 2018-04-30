
As the task conditions state that the work.json dataset doesn't show absolute value, but only changes, and it is unclear what it really means.   
I see "Progress" as an independent assesment and I decided to make the today's subjects statistics as an average value of each excercise =
(CP * CD - PP * PD)/ PP * PD, where:
 CP = current Progress;
 CD = current Difficulty;
 PP = previous Progress;
 PD = previous Difficulty;
 
Maybe my understanding of "Progress" is incorrect:)

Result of the program is a progress of each student in each subject, that has been made by the certain time, in comparison with the previous lesson's progress 

To see the program result you should:
1. have .net core 2.0;
2. run command: dotnet SnappetSolution.dll in SnappetDeploy.zip folder (you will see the port, the application is listening on);
3. open a browser and enter the url, you can see from the point above.