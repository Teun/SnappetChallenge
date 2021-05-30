import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-filtering-form',
  templateUrl: './filtering-form.component.html',
  styleUrls: ['./filtering-form.component.scss']
})
export class FilteringFormComponent implements OnInit {
  @Output() onFilterResults: EventEmitter<number> = new EventEmitter()
  identifier!: number;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.onFilterResults.emit(this.identifier)
  }
}
