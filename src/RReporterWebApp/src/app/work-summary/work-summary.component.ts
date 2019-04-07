import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkSummaryHubService } from '../services/work-summary-hub.service';

@Component({
  selector: 'app-work-summary',
  templateUrl: './work-summary.component.html',
  styleUrls: ['./work-summary.component.css']
})
export class WorkSummaryComponent implements OnInit, OnDestroy {
  

  public classId: number;
  public data: any;

  constructor(
    private workSummaryHubService: WorkSummaryHubService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() : void {
    this.data = {};
    this.classId = parseInt(this.route.snapshot.paramMap.get('classId'));
    this.initializeDataAsync(); // do not await
    this.workSummaryHubService.addLearningObjectiveSummaryListener(this.learningObjectiveSummaryUpdate);
  }

  ngOnDestroy(): void {
    this.workSummaryHubService.removeLearningObjectiveSummaryListener(this.learningObjectiveSummaryUpdate);
  }

  initializeDataAsync() : void {
    var self = this;
    this.workSummaryHubService.getWorkSummary(this.classId)
      .then((data) => {
        self.data = data
      })
      .catch(console.error);
  }

  learningObjectiveSummaryUpdate(learningObjectiveSummary : any) : void {
    // TODO update stuff
  }


}
