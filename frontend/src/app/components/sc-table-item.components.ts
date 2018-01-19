import { Component, Input } from "@angular/core";

@Component({
  selector: '[scTableItem]',
  template: `
  <tr>
    <td>{{scTableItem.UserId}}</td>
    <td>{{scTableItem.Subject}}</td>
    <td>{{scTableItem.ClassDomain}}</td>
    <td>{{scTableItem.LearningObjective}}</td>
    <td>{{scTableItem.TotalExercises}}</td>
    <td>{{scTableItem.Correct}}</td>
    <td>{{scTableItem.Wrong}}</td>
    <td>{{scTableItem.Accuracy}}</td>
    <td>
      <a href="#" (click)="toggle()">Details</a>
    </td>
  </tr>
  <tr *ngIf="collapsed">
    <td colspan="8">
    </td>
  </tr>
  `
})
export class TableItemComponent {

  @Input('scTableItem') scTableItem: any;
  collapsed = false;

  toggle() {
    this.collapsed = !this.collapsed;
  }

}
