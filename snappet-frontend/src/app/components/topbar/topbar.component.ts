import {Component, OnInit} from '@angular/core';
import {MatNavList} from '@angular/material/list';
import {Router} from '@angular/router';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.css']
})
export class TopbarComponent implements OnInit {

  currentUser;

  constructor(private router: Router) {
  }

  ngOnInit(): void {

  }

}
