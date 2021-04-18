import { Component } from '@angular/core';
import {rootRoutesMap} from "../../../routes";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  routes = rootRoutesMap;
  constructor() { }

}
