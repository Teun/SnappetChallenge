import { Component, OnInit } from '@angular/core';
import { concat } from 'rxjs';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-create-data-backend',
  templateUrl: './create-data-backend.component.html',
  styleUrls: ['./create-data-backend.component.scss']
})
export class CreateDataBackendComponent implements OnInit {

  constructor(
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    this.dataService.createDataBackend().subscribe(httpRequests => {
      concat(...httpRequests).subscribe((result) => { console.log(result)})
     });
  }
}
