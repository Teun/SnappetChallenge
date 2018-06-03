import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable, empty } from 'rxjs';
import { catchError, map, tap, finalize } from 'rxjs/operators';
import { WorkStatisticsService } from '../services/work-statistics.service';
import { WorkStatistics, WorkStatisticsByTopic, WorkStatisticsTree } from '../model/work-statistics';

const TODAY: Date = new Date('2015-03-24');

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  hasError: boolean = false;
  isLoading: boolean = false;
  period: [Date, Date] = [TODAY, TODAY];

  subjects: WorkStatisticsTree[] = [];
  cards: {[key: string]: string | number }[] = [];

  constructor(private statisticsService: WorkStatisticsService) {}

  ngOnInit() { }

  loadData(period) {

    this.isLoading = true;

    this.statisticsService
      .getWorkStatisticsByTopic(period)
      .pipe(
        tap(stats => this.updateResults(stats)),
        catchError(err => this.handleError(err)),
        finalize(() => this.isLoading = false)
      )
      .subscribe();
  }

  private updateResults(stats: WorkStatisticsByTopic[]): void {

    // Created a nested structure grouped by Subject and then by Learning Objective
    this.subjects = this.nest(stats, by => by.subject, thenBy => thenBy.learningObjective)
                        .sort((a, b) => b.children.length - a.children.length);

    // Aggregate all subjects' statistics to display number cards with general stats
    const all = this.aggregate(this.subjects);

    this.cards = [
      { name: 'Total Answers', value: all.totalAnswers },
      { name: 'Total Correct', value: all.totalCorrect },
      { name: '% Correct', value: (all.totalCorrect * 100 / all.totalAnswers).toFixed(2) + '%' },
      { name: 'Total Progress', value: all.totalProgress },
      { name: 'Average Progress', value: (all.totalProgress / all.totalAnswers).toFixed(2) },
      { name: 'Average Difficulty', value: all.averageDifficulty.toFixed(2) }
    ];
  }

  /**
   * Recursively groups data by the specified selectors
   * while aggregating statistics for each hierarchy level.
   */
  private nest<T extends WorkStatistics>(stats: T[], ...selectors: ((item: T) => string)[]): WorkStatisticsTree[] {
    if (selectors.length === 0) { return []; }

    const selector = selectors.splice(0, 1)[0];

    const group = this.groupBy(stats, selector);

    return Object.keys(group).map(key => <WorkStatisticsTree>{
      name: key,
      ...this.aggregate(group[key]),
      children: this.nest(group[key], ...selectors)
    });
  }

  /**
   * Aggregation method for WorkStatistics
   */
  private aggregate(data: WorkStatistics[]): WorkStatistics {
    return data.reduce((result, current) => ({
      ...result,
      totalAnswers: result.totalAnswers + current.totalAnswers,
      totalCorrect: result.totalCorrect + current.totalCorrect,
      totalProgress: result.totalProgress + current.totalProgress,
      totalExercises: result.totalExercises + current.totalExercises,
      averageDifficulty: (result.averageDifficulty * result.totalExercises + 
                          current.averageDifficulty * current.totalExercises) / 
                          (result.totalExercises + current.totalExercises)
    }), new WorkStatistics());
  }

  private groupBy<T>(data: T[], id: (item: T) => string): { [key: string]: T[] } {
    return data.reduce((result, current) => ({
      ...result,
      [id(current)]: [...(result[id(current)] || []), current]
    }), {});
  }

  private handleError(error: any): Observable<any> {
    this.hasError = true;
    console.error('Failed to load data', error);
    return empty();
  }
}
