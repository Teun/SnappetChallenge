import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { TeacherService } from '../../../../services/teacher/teacher.service';
import { DashboardModel } from '../../../../services/teacher/models/DashboardModel';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-teacher-dashboard',
  templateUrl: './teacher-dashboard.component.html',
  styleUrls: ['./teacher-dashboard.component.scss'],
})
export class TeacherDashboardComponent implements OnInit {
  constructor(private teacherService: TeacherService) {}

  public items: DashboardModel[];
  public dashboardColumns: string[];
  public dataSource: MatTableDataSource<DashboardModel>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.loadTable();
  }

  loadTable() {
    this.teacherService.getTeacherDasboard().subscribe((response: any) => {
      this.items = response.data.items;
      this.dataSource = new MatTableDataSource<DashboardModel>(this.items);

      this.dataSource.paginator = this.paginator;
    });
    this.dashboardColumns = [
      'Subject',
      'Domain',
      'LearningObjective',
      'AnswerCount',
      'SubmitDateTime',
    ];
  }
}
