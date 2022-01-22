import {ChartOptions, ChartType} from 'chart.js';
import {Component, Input, OnChanges, OnInit, SimpleChanges} from "@angular/core";
import {ChartModel} from "../../../models/chart.model";

@Component({
  selector: 'app-my-line-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit, OnChanges {
  @Input() dataPoints: Array<ChartModel>;
  @Input() labels: Array<string>;
  type: ChartType = 'bar';

  data: any;
  options: ChartOptions = {
    indexAxis: 'y',
    parsing: {
      xAxisKey: 'id',
      yAxisKey: 'nested.value'
    }
  };

  constructor() {
  }

  ngOnInit() {
    this.data = {
      labels: this.labels,
      datasets: this.setData()
    };
  }

  ngOnChanges(changes: SimpleChanges) {
    this.data = {
      labels: this.labels,
      datasets: this.setData()
    };
  }

  setData(): any {
    return this.dataPoints.map((dataPoint, index) => {
      return {
        axis: 'y',
        label: dataPoint.label,
        data: dataPoint.data,
        fill: false,
        backgroundColor: [
          `rgba(${255 - 125 * index}, ${10 + 40*index}, ${10 + 180 * index}, 0.2)`,
          `rgba(${255 - 125 * index}, ${10 + 40*index}, ${10 + 180 * index}, 0.2)`,
        ],
        borderColor: [
          `rgba(${255 - 125 * index}, ${10 + 40*index}, ${10 + 180 * index}, 0.2)`,
          `rgba(${255 - 125 * index}, ${10 + 40*index}, ${10 + 180 * index}, 0.2)`,

        ],
        borderWidth: 1
      }
    })
  }

}
