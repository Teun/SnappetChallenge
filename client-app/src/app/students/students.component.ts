import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Students {
  [id: string]: Answer[];
}

interface Answer {
  Correct: number;
  Difficulty: string;
  Domain: string;
  ExerciseId: number;
  LearningObjective: string;
  Progress: number;
  Subject: string;
  SubmitDateTime: string;
  SubmittedAnswerId: number;
  UserId: number;
}

interface Answers {
  items: Answer[];
  cacheHit?: boolean;
}

@Component({
  selector: 'students',
  templateUrl: './students.component.html',
})
export class StudentsComponent implements OnInit {
  answers: Answer[] = [];
  students: Students = {};
  aggregations = ['Student', 'Exercise'];
  prop: string = 'ExerciseId';

  constructor(private http: HttpClient) {}

  setAggregation() {
    this.aggregations = this.aggregations.reverse();
    this.students = {};
    this.fetchItems();
    this.prop = this.prop === 'ExerciseId' ? 'UserId' : 'ExerciseId';
  }

  ngOnInit() {
    this.fetchItems();
  }

  fetchItems() {
    this.answers = JSON.parse(
      `[{"SubmittedAnswerId":2400593,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:46.303","ExerciseId":1029129,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"388.5557109","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2400878,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:57.813","ExerciseId":1013719,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"297.8264536","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398949,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:38:41.487","ExerciseId":1013706,"Domain":"-","Progress":3,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"350.0551362","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398069,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:38:05.060","ExerciseId":1013698,"Domain":"-","Progress":4,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"417.5709591","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2400320,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:34.887","ExerciseId":1038516,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"286.9675616","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2400263,"UserId":40281,"Correct":0,"SubmitDateTime":"2015-03-02T07:39:33.823","ExerciseId":1029129,"Domain":"-","Progress":-7,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"388.5557109","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2399416,"UserId":40281,"Correct":0,"SubmitDateTime":"2015-03-02T07:39:00.940","ExerciseId":1029124,"Domain":"-","Progress":-7,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"376.1835364","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2400074,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:26.693","ExerciseId":1013713,"Domain":"-","Progress":1,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"243.06401","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2399531,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:05.463","ExerciseId":1029124,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"376.1835364","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398104,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:38:06.243","ExerciseId":1038510,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"268.6275811","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2400841,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:56.073","ExerciseId":1038518,"Domain":"-","Progress":6,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"461.898176","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2400276,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:34.260","ExerciseId":1013716,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"229.427008","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2401065,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:40:05.270","ExerciseId":1013723,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"203.0571819","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2399454,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:01.847","ExerciseId":1038514,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"318.3475772","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398821,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:38:36.493","ExerciseId":1038512,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"323.9271342","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2396696,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:36:59.653","ExerciseId":1029121,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"353.3972855","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398575,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:38:27.163","ExerciseId":1029123,"Domain":"-","Progress":4,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"414.8614105","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2397893,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:37:56.963","ExerciseId":1013695,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"191.9839136","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2399892,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:39:19.053","ExerciseId":1038515,"Domain":"-","Progress":1,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"249.8796998","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398238,"UserId":40282,"Correct":0,"SubmitDateTime":"2015-03-02T07:38:12.533","ExerciseId":1013704,"Domain":"-","Progress":-7,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"339.8543405","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2395278,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:35:38.740","ExerciseId":1038396,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"-200","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2401327,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:40:16.317","ExerciseId":1029130,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"329.3160392","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2396494,"UserId":40281,"Correct":1,"SubmitDateTime":"2015-03-02T07:36:48.530","ExerciseId":1029120,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"329.2341931","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2398291,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:38:15.247","ExerciseId":1013704,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"339.8543405","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2397209,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:37:24.030","ExerciseId":1038506,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"-200","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2401332,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:40:15.830","ExerciseId":1013727,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"337.8409664","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2397725,"UserId":40285,"Correct":1,"SubmitDateTime":"2015-03-02T07:37:48.990","ExerciseId":1038509,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"230.6971675","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2397740,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:37:49.553","ExerciseId":1013691,"Domain":"-","Progress":2,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"323.9532905","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2397600,"UserId":40285,"Correct":0,"SubmitDateTime":"2015-03-02T07:37:43.500","ExerciseId":1038509,"Domain":"-","Progress":-10,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"230.6971675","Subject":"Begrijpend Lezen"},{"SubmittedAnswerId":2396638,"UserId":40282,"Correct":1,"SubmitDateTime":"2015-03-02T07:36:55.487","ExerciseId":1013670,"Domain":"-","Progress":0,"LearningObjective":"Diverse leerdoelen Begrijpend Lezen","Difficulty":"-200","Subject":"Begrijpend Lezen"}]`
    );
    switch (this.aggregations[0]) {
      case 'Student': {
        this.aggregateAnswersByStudent();
        break;
      }
      case 'Exercise': {
        this.aggregateAnswersByExercise();
        break;
      }
    }
    Object.keys(this.students).forEach((key) => {
      this.students[key].sort(function (a, b) {
        var keyA = new Date(a.SubmitDateTime),
          keyB = new Date(b.SubmitDateTime);
        // Compare the 2 dates
        if (keyA < keyB) return -1;
        if (keyA > keyB) return 1;
        return 0;
      });
    });
    /*
    this.http
      .get<Answers>(
        'https://hwxbvs7d3k.execute-api.us-east-1.amazonaws.com/dev/answers'
      )
      .subscribe(
        (response: Answers) => {
          this.answers = response.items;
          switch (this.aggregation) {
            case 'student': {
              this.aggregateAnswersByStudent();
              break;
            }
            case 'task': {
              this.aggregateAnswersByExercise();
              break;
            }
          }
        },
        (error) => {
          console.error('Error fetching items:', error);
        }
      );
      */
  }

  aggregateAnswersByExercise() {
    this.answers.forEach((answer) => {
      if (this.students[answer.ExerciseId])
        this.students[answer.ExerciseId].push(answer);
      else this.students[answer.ExerciseId] = [answer];
    });
    console.log(this.students);
  }

  aggregateAnswersByStudent() {
    this.answers.forEach((answer) => {
      if (this.students[answer.UserId])
        this.students[answer.UserId].push(answer);
      else this.students[answer.UserId] = [answer];
    });

    console.log(this.students);
  }
}
