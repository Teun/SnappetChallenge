import { Injectable } from '@angular/core';
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  isOpen$ = new BehaviorSubject<boolean>(true);
  constructor() { }

  toggleMenu() {
    this.isOpen$.next(!this.isOpen$.value);
  }

  close() {
    this.isOpen$.next(false);
  }

  open() {
    this.isOpen$.next(true);
  }
}
