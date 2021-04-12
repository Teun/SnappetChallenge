import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Summary } from '../models/summary.model';
import { SummaryService } from '../services/summary.service';

@Component({
  selector: 'app-domain-summary',
  templateUrl: './domain-summary.component.html',
  styleUrls: ['./domain-summary.component.css']
})
export class DomainSummaryComponent implements OnInit {
  subject:string ='';
  date:string ='';
  public summary:Summary[]=[];
  constructor(private summaryService:SummaryService,private route:ActivatedRoute) {
    this.subject = this.route.snapshot.params['subject'];
    this.date = this.route.snapshot.params['date'];
    localStorage.setItem('subject',this.subject);
   }

  ngOnInit(): void {

    this.summaryService.getDomainSummary(this.date,this.subject).subscribe((item)=>{
      this.summary = item;
    });
    
  }

}
