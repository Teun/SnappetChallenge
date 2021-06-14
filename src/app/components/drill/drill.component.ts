import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms'
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-drill',
  templateUrl: './drill.component.html',
  styleUrls: ['./drill.component.scss']
})
export class DrillComponent implements OnInit {

  subjects: string[] = [];
  domains: string[] = [];
  learningObjectives: string[] = [];
  exercises: number[] = [];

  drillForm: FormGroup = this.formBuilder.group({
    subject: [''],
    domain: [''],
    learningObjective: [''],
    exercise: [''],
  });

  constructor(
    private formBuilder: FormBuilder,
    private dataService: DataService,

  ) { }

  ngOnInit(): void {
    this.dataService.initGet().subscribe(([subjects, domains, learningObjectives, exercises]) => {
      this.subjects = subjects;
      this.domains = domains;
      this.learningObjectives = learningObjectives;
      this.exercises = exercises;
      this.selectedSubject.setValue('');
      this.selectedDomain.setValue('');
      this.selectedLearningObjective.setValue('');
      this.selectedExercise.setValue('');
      this.dataService.getWork('', '', '', '').subscribe(() => { })
    })
  }

  onChangeSubject() {
    if (this.selectedSubject.value) {
      this.dataService.getSubject(this.selectedSubject.value).subscribe(results => {
        this.domains = results[0].domains;
        this.learningObjectives = results[0].learningObjectives;
        this.exercises = results[0].exercises;
        this.selectedDomain.setValue('');
        this.selectedLearningObjective.setValue('');
        this.selectedExercise.setValue('');
        this.dataService.getWork(this.selectedSubject.value, '', '', '').subscribe(() => { })
      })
    } else {
      this.ngOnInit();
    }
  }

  onChangeDomain() {
    if (this.selectedDomain.value) {
      this.dataService.getDomain(this.selectedDomain.value).subscribe(results => {
        this.learningObjectives = results[0].learningObjectives;
        this.exercises = results[0].exercises;
        this.selectedSubject.setValue(results[0].subjects[0]);
        this.selectedLearningObjective.setValue('');
        this.selectedExercise.setValue('');
        this.dataService.getWork('', this.selectedDomain.value, '', '').subscribe(() => { })
      })
    } else {
      this.ngOnInit();
    }
  }

  onChangeLearningObjective() {
    if (this.selectedLearningObjective.value) {
      this.dataService.getLearningObjective(this.selectedLearningObjective.value).subscribe(results => {
        this.exercises = results[0].exercises;
        this.selectedSubject.setValue(results[0].subjects[0]);
        this.selectedDomain.setValue(results[0].domains[0]);
        this.selectedExercise.setValue('');
        this.dataService.getWork('', '', this.selectedLearningObjective.value, '').subscribe(() => { })
      })
    } else {
      this.ngOnInit();
    }
  }

  onChangeExercise() {
    if (this.selectedExercise.value) {
      this.dataService.getExercise(this.selectedExercise.value).subscribe(results => {
        this.selectedSubject.setValue(results[0].subjects[0]);
        this.selectedDomain.setValue(results[0].domains[0]);
        this.selectedLearningObjective.setValue(results[0].learningObjectives[0]);
        this.dataService.getWork('', '', '', this.selectedExercise.value).subscribe(() => { })
      })
    } else {
      this.ngOnInit();
    }
  }

  get selectedSubject(): FormControl {
    return this.drillForm.get('subject') as FormControl;
  }

  get selectedDomain(): FormControl {
    return this.drillForm.get('domain') as FormControl;
  }

  get selectedLearningObjective(): FormControl {
    return this.drillForm.get('learningObjective') as FormControl;
  }
  
  get selectedExercise(): FormControl {
    return this.drillForm.get('exercise') as FormControl;
  }
  
}
