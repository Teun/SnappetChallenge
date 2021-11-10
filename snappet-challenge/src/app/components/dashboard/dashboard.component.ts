import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { DataService } from 'src/app/services/data.service';
import { Work } from 'src/app/types/work';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [DataService],
})
export class DashboardComponent {}
