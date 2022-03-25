import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Domain, Subjects } from 'src/app/models/class.model';
import { DataHttpService } from 'src/app/services/data-http.service';
import { getProgressData } from 'src/app/utils/mappers';

@Component({
  selector: 'app-relative-progress',
  templateUrl: './relative-progress.component.html',
  styleUrls: ['./relative-progress.component.scss'],
})
export class RelativeProgressComponent implements OnInit {
  data$: Observable<any>;
  constructor(private readonly dataService: DataHttpService) {}

  ngOnInit(): void {
    this.data$ = this.dataService.getClassData().pipe(
      map((subjects: Subjects) => {
        return Object.values(subjects).map((subject: Domain[]) => {
          if (!subject.length) {
            return;
          }
          return subject.map((domain: Domain) => {
            const title = domain.items[0].Subject + ' ' + (domain.name === 'noDomain' ? '' : domain.name);
            const progressData = getProgressData(domain);
            return {
              title: {
                text: title,
                left: 'center',
              },
              xAxis: {
                type: 'category',
                name: 'Number of Answers',
                nameLocation: 'end',
              },
              name: domain.name,
              yAxis: {
                type: 'value',
                name: 'Accumulated Progress',
              },
              series: {
                data: progressData,
                type: 'line',
              },
              type: 'line',
              extra: {
                firstAnswerDate: domain.items[0].SubmitDateTime,
                lastAnswerDate: domain.items[domain.items.length - 1].SubmitDateTime,
                numberOfAnswers: domain.items.length,
                totalProgress: progressData[progressData.length - 1],
                averageProgressAtTheEnd: progressData[progressData.length - 1] / progressData.length,
              },
            };
          });
        });
      })
    );
  }
}
