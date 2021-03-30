import { Component, OnInit, ViewChild } from '@angular/core';
import { StudentService } from '../../../../services/student/student.service';
import { StudentOverviewModel } from '../../../../services/student/models/StudentOverviewModel';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-student-overview',
  templateUrl: './student-overview.component.html',
  styleUrls: ['./student-overview.component.scss'],
})
export class StudentOverviewComponent implements OnInit {
  constructor(private studentService: StudentService) {}

  public items: StudentOverviewModel[];
  public overviewColumns: string[];
  public dataSource: MatTableDataSource<StudentOverviewModel>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.loadTable();
  }

  loadTable() {
    this.studentService.getStudentsOverview().subscribe((response: any) => {
      this.items = response.data.items;
      this.dataSource = new MatTableDataSource<StudentOverviewModel>(
        this.items
      );

      this.dataSource.paginator = this.paginator;
    });
    this.overviewColumns = [
      'UserId',
      'Subject',
      'AnswerCount',
      'Min',
      'Mean',
      'High',
    ];
  }
}
