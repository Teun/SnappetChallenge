import { Component, Output, EventEmitter } from '@angular/core';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { StudentService } from '../services/student.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'sc-filter',
  template: `
    <div id="fForm" class="row">
      <form [formGroup]="filterForm" (ngSubmit)="filter(filterForm.value)">
        <div class="form-group">
          <label for="filterDate">Pick a Date</label>
          <input formControlName="filterDate" id="filterDate"
            type="date"
            value="2015-03-24"
            class="form-control"
            aria-describedby="emailHelp"
            placeholder="Enter email">
        </div>
        <div class="form-group">
          <label for="domain">Pick a Range of Accuracy</label>
          <input #rangeAccuracy formControlName="rangeAccuracy" id="rangeAccuracy"
            type="range" min="1" max="100" value="100" class="slider" >
          <span>{{rangeAccuracy.value}} %</span>
        </div>
        <div class="form-group">
          <label for="subject">Select a subject</label>
          <select class="form-control" formControlName="subject" id="subject" (change)="onSelectSubject($event.target.value)">
            <option *ngFor="let sub of subjects" [selected]="sub=='-'">{{sub}}</option>
          </select>
        </div>
        <div class="form-group">
          <label for="domain">Select a class domain</label>
          <select class="form-control" formControlName="domain" id="domain">
            <option *ngFor="let domain of domains" [selected]="domain=='-'">{{domain}}</option>
          </select>
        </div>
        <!-- button type="submit" class="btn btn-danger">Filter</button -->
        <button [disabled]="filterForm.invalid"
          type="submit"
          class="form-control btn btn-danger"
          value="Filter">
            <span>Filter</span>
        </button>
      </form>
    </div>
  `,
  styleUrls: ['styles.scss']
})
export class FilterComponent implements OnInit {

  subjects: any[];
  domains: any[];

  filterForm: FormGroup;
  filterDate: FormControl;
  subject: FormControl;
  domain: FormControl;
  rangeAccuracy: FormControl;

  @Output() Filter = new EventEmitter();

  constructor(private studentsService: StudentService) {}

  onSelectSubject(event) {
    console.log(event);
    if (event !== '-') {
      this.studentsService.getDomains(event)
        .subscribe((result) => {
          if (result) {
            console.log(result);
            this.domains = result;
            this.filterForm.controls['domain'].setValue('-');
            this.filterForm.controls['domain'].enable();
          }
      });
    } else {
      this.domains = [];
      this.filterForm.controls['domain'].setValue(this.domains);
      this.filterForm.controls['domain'].disable();
    }
  }

  filter(formValues) {
    console.log(formValues);
    this.studentsService.getStudents(
      formValues.filterDate,
      formValues.subject,
      formValues.domain,
      formValues.rangeAccuracy)
        .subscribe((result) => {
          if (result) {
            this.Filter.emit(result);
          }
      });
  }

  ngOnInit() {

    this.filterDate = new FormControl('2015-03-24');
    this.subject = new FormControl('');
    this.domain = new FormControl({value: '', disabled: true});
    this.rangeAccuracy = new FormControl(100);

    this.filterForm = new FormGroup({
      filterDate: this.filterDate,
      subject: this.subject,
      domain: this.domain,
      rangeAccuracy: this.rangeAccuracy
    });

    this.domains = [];
    this.studentsService.getSubjects()
    .subscribe((result) => {
      if (result) {
        this.subjects = result;
      }
    });
  }


}
