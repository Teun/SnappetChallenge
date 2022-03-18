import { Component, OnInit } from '@angular/core';
import { DataHttpService } from 'src/app/services/data-http.service';

@Component({
  selector: 'app-class-charts',
  templateUrl: './class-charts.component.html',
  styleUrls: ['./class-charts.component.scss']
})
export class ClassChartsComponent implements OnInit {

  constructor(private readonly dataService:DataHttpService) { }

  ngOnInit(): void {
    this.dataService.getClassData().subscribe(a => console.table(a))
  }

}
