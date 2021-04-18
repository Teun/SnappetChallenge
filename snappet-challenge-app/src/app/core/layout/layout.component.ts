import { Component, OnInit } from '@angular/core';
import {MenuService} from "../services/menu.service";

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isMenuOpen = true;
  constructor(private menuService: MenuService) { }

  ngOnInit(): void {
    this.menuService.isOpen$.subscribe((status) => {
      this.isMenuOpen = status;
    })
  }

}
