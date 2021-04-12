import { Component, OnInit } from '@angular/core';
import { Summary } from '../models/summary.model';
import { SummaryService } from '../services/summary.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  public date: string;
  public subject:string='';
  public summary:Summary[]=[];

  constructor(private summaryService:SummaryService) {
    let storedDate = localStorage.getItem("date");
    this.date = storedDate==null?"2015-03-01":storedDate.toString();
  }

  ngOnInit(): void {
    this.loadData();
  }

  public onDateChanged () {
    this.loadData();
    localStorage.setItem("date",this.date);
   }

   private loadData(){
    this.summaryService.getSummary(this.date).subscribe((summary)=>{
      this.summary = summary;
    });
  }

}
