import { Component, OnInit, ViewChild, Input } from "@angular/core";
import { MatTableDataSource, MatPaginator } from "@angular/material";
import {
  AfterViewInit,
  OnChanges
} from "@angular/core/src/metadata/lifecycle_hooks";

@Component({
  selector: "app-students",
  templateUrl: "./students.component.html",
  styleUrls: ["./students.component.css"]
})
export class StudentsComponent implements OnInit, AfterViewInit, OnChanges {
  @Input() studentDetails: any;
  datasource = new MatTableDataSource<any>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns = [
    "UserId",
    "TotalExercise",
    "TotalAttempts",
    "TotalAttemptsRight",
    "Progress"
  ];

  constructor() {}

  ngOnInit() {}

  ngOnChanges(event) {
    this.datasource = new MatTableDataSource<any>(this.studentDetails);
    this.datasource.paginator = this.paginator;
  }

  ngAfterViewInit() {
    this.datasource.paginator = this.paginator;
  }
}
