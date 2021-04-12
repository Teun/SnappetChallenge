import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Summary } from '../models/summary.model';
import { SummaryService } from '../services/summary.service';

@Component({
  selector: 'app-learning-objective-summary',
  templateUrl: './learning-objective-summary.component.html',
  styleUrls: ['./learning-objective-summary.component.css']
})
export class LearningObjectiveSummaryComponent implements OnInit {

  domain: string='';
  date:string ='';
  subject:string='';
  summary:Summary[]=[];
  constructor(private summaryService:SummaryService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.domain = this.route.snapshot.params['domain'];
    this.date = this.route.snapshot.params['date'];
    let subject = localStorage.getItem("subject");
    this.subject = subject===null?'':subject.toString();
    this.summaryService.getLearningObjectivesSumary(this.date,this.domain).subscribe((item)=>{
      this.summary = item;
    });
  }

}
