import { Component, OnInit, ViewChild } from "@angular/core";
import {
  MatPaginator,
  MatTableDataSource,
  MatSelectChange
} from "@angular/material";
import { AfterViewInit } from "@angular/core/src/metadata/lifecycle_hooks";
import { DatatableService } from "./datatable.service";

@Component({
  selector: "app-datatable",
  templateUrl: "./datatable.component.html",
  styleUrls: ["./datatable.component.css"]
})
export class DatatableComponent implements AfterViewInit {
  displayedColumns = [
    "LearningObjective",
    "TotalExerices",
    "TotalStudents",
    "performance",
    "StudentDetails"
  ];
  dataSource = new MatTableDataSource<Element>();

  selectedDate: any;
  allFilters = [];
  subjectArray = [];
  domainArray = [];
  selectedDomain = "";
  selectedSubject = "";
  selectedStudentDetails: any;
  latestChangeEvent: MatSelectChange;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(private service: DatatableService) {
    this.service.getAllSubjects().subscribe((result: any) => {
      if (result) {
        this.allFilters = result;
      }
    });
  }

  onDateSelected(value) {
    this.selectedStudentDetails = [];
    const abc = this.convert(value);
    this.selectedDate = abc + "T00:00:00";
    this.getSubjectList();
    this.selectedSubject = "";
    this.selectedDomain = "";
    this.service
      .getData(this.selectedDate, this.selectedSubject, this.selectedDomain)
      .subscribe((result: any) => {
        this.dataSource.data = result;
        this.calculateClassPerformance();
      });
  }

  getSubjectList() {
    let subjectList = [];
    this.allFilters.forEach(item => {
      if (item.DateTime === this.selectedDate) {
        subjectList = item.SubjectsList;
      }
    });
    this.subjectArray = [];
    subjectList.forEach(item => {
      this.subjectArray.push(item.Name);
    });

    this.domainArray = [];
    subjectList.forEach(item => {
      this.domainArray.push(...item.DomainList);
    });

    this.domainArray = this.domainArray.filter((v, i, a) => a.indexOf(v) === i);
  }

  onDomainChanged(value) {
    this.selectedStudentDetails = [];

    this.service
      .getData(this.selectedDate, this.selectedSubject, this.selectedDomain)
      .subscribe((result: any) => {
        this.dataSource.data = result;
        this.calculateClassPerformance();
      });
  }

  calculateClassPerformance() {
    this.dataSource.data.forEach((item: any) => {
      let total = 0;
      item.StudentDetails.forEach((student: any) => {
        student.percentage = parseFloat(
          Math.round(
            student.TotalAttemptsRight / student.TotalAttempts * 100
          ).toString()
        );
        total += student.percentage;
      });

      item.performance = Math.round(total / item.StudentDetails.length);
    });
  }

  onSubjectChanged(value) {
    this.selectedStudentDetails = [];
    this.selectedDomain = "";
    this.service
      .getData(this.selectedDate, this.selectedSubject, this.selectedDomain)
      .subscribe((result: any) => {
        this.dataSource.data = result;
        this.calculateClassPerformance();
      });
  }

  setStudent(student: any) {
    // student.forEach(element => {
    //   element.percentage = parseFloat(
    //     Math.round(
    //       element.TotalAttemptsRight / element.TotalAttempts * 100
    //     ).toString()
    //   ).toFixed(0);
    // });

    this.selectedStudentDetails = student;
  }
  convert(str) {
    const date = new Date(str),
      mnth = ("0" + (date.getMonth() + 1)).slice(-2),
      day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
  }
}

export interface Element {
  LearningObjective: string;
  Progress: number;
  TotalExerices: number;
  TotalStudents: number;
  Subject: string;
  Domain: string;
}
