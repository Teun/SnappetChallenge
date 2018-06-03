import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'plot'
})
export class PlotPipe implements PipeTransform {
  transform(values: any[], value: string, top: number = 10): any {
    return values
      .map(x => ({ name: x.name, value: x[value] }))
      .sort((a, b) => b.value - a.value)
      .slice(0, top - 1);
  }
}
