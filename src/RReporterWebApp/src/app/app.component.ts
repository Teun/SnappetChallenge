import { Component, OnInit } from '@angular/core';
import { WorkSummaryHubService } from './services/work-summary-hub.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'RReporterWebApp';

  constructor(private workSummaryHubService: WorkSummaryHubService) { }

  ngOnInit() {
      this.workSummaryHubService.startConnection();
  }

}
