import { Component, OnInit,ViewChild } from "@angular/core";
import { InsightsService } from "../services/insights.service";
import { FormControl } from "@angular/forms";
import { PubilDailyInsight } from "../models/pubil-daily-insight";
import {MatTableDataSource,MatPaginator} from '@angular/material';

@Component({
  selector: "app-daily-insights",
  templateUrl: "./daily-insights.component.html",
  styleUrls: ["./daily-insights.component.css"]
})
export class DailyInsightsComponent implements OnInit {
  dataSource=null;
  displayedColumns: string[] = ['pubilId', 'subject', 'domain', 'countOfSubmittedAnswers','numberOfCorrectAnswers'];
  constructor(private service: InsightsService) {}

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() { 
  }
  date = new FormControl(new Date("2015-03-16"));
  getInsights(): void {
    var serializedDate = this.date.value.toISOString();
    this.service.getPubilsDailyInisghts(serializedDate)
    .subscribe(data => 
      { 
        this.dataSource = new MatTableDataSource<PubilDailyInsight>(data);
        this.dataSource.paginator = this.paginator;
        console.log(data);
      });;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
