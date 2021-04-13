import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { fromEvent } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit, AfterViewInit {

  @ViewChild('toggleSidenav', {static: true}) angleSvg!: ElementRef;
  isCollapse = false;

  constructor() { }

  ngOnInit(): void {
  }

  ngAfterViewInit(): void {
    fromEvent(this.angleSvg.nativeElement, 'click').pipe(
      tap( () => this.isCollapse = !this.isCollapse)
    ).subscribe();
  }


}
