import {Component, OnDestroy} from '@angular/core';
import {MenuService} from "@core/services/menu.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy {
  constructor(private menuService: MenuService) {
  }

  ngOnDestroy() {
    this.menuService.isOpen$.observers.forEach((el) => {
      el.complete();
    })
  }
}
