import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Domain, DomainItem } from 'src/app/models/class.model';
import { DataHttpService } from 'src/app/services/data-http.service';

@Component({
  selector: 'app-actual-level-estimation',
  templateUrl: './actual-level-estimation.component.html',
  styleUrls: ['./actual-level-estimation.component.scss'],
})
export class ActualLevelEstimationComponent implements OnInit {
  data$: Observable<any>;
  constructor(private readonly dataService: DataHttpService) {}

  ngOnInit(): void {
    this.data$ = this.dataService.getClassData().pipe(
      map((subjects) => {
        const averageDifficultyData = {};

        Object.values(subjects).forEach((subject: Domain[]) => {
          subject.forEach((domain) => {
            const dataPerStudent = this.mapDataPerStudent(domain);
            const averageSolvingAbilityPerStudent = this.getAverageSolvingAbilityPerStudent(dataPerStudent);

            const domainName = `${domain.items[0].Subject}-${domain.name}`;
            averageDifficultyData[domainName] = averageSolvingAbilityPerStudent;
          });
        });

        return {
          tooltip: {
            trigger: 'axis',
            axisPointer: {
              type: 'shadow',
            },
          },
          legend: {},
          grid: {
            containLabel: true,
          },
          resize: {
            height: '100%',
          },
          yAxis: {
            name: 'Difficulty',
            type: 'value',
            boundaryGap: ['80%', '20%'],
            splitArea: {
              interval: '80px',
            },
            axisLabel: {},
          },
          xAxis: {
            type: 'category',
            name: 'Subject - Domain Names',
            axisLabel: { interval: 0, rotate: 30 },
            axisTick: {
              alignWithLabel: true,
            },
            data: Object.keys(averageDifficultyData),
          },
          series: [
            {
              name: 'Average difficulity',
              type: 'bar',
              data: Object.values(averageDifficultyData),
            },
          ],
        };
      })
    );
  }

  private mapDataPerStudent = (domain: Domain): { [id: string]: DomainItem[] } => {
    return domain.items.reduce((acc, item) => {
      if (!acc[item.UserId]) {
        acc[item.UserId] = [];
      }
      acc[item.UserId].push(item);
      return acc;
    }, {});
  };

  private getAverageSolvingAbilityPerStudent(studentsData: { [id: string]: DomainItem[] }): number {
    const totalDifficulty = Object.entries(studentsData).reduce((acc, [_id, studentData]: [string, DomainItem[]]) => {
      const solvedExercises = studentData.filter((i) => !!i.Correct).sort((a, b) => +b.Difficulty - +a.Difficulty);
      const failedExercises = studentData.filter((i) => !i.Correct).sort((a, b) => +a.Difficulty - +b.Difficulty);

      const maxDifficulty = parseInt(solvedExercises[0]?.Difficulty, 10);
      const minDifficulty = parseInt(failedExercises[0]?.Difficulty, 10);

      if (maxDifficulty && minDifficulty) {
        acc = acc + (maxDifficulty + minDifficulty) / 2;
      } else if (maxDifficulty) {
        acc = acc + maxDifficulty;
      } else if (minDifficulty) {
        acc = acc + minDifficulty;
      }
      return acc;
    }, 0);

    return totalDifficulty / Object.keys(studentsData).length;
  }
}
