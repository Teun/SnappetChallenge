import {Component} from '@angular/core';
import {StoreService} from "../store/store.service";
import {map} from "rxjs/operators";

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent {
  filter = this.store.filterValues;
  labels = {
    UserId: 'User Id',
    Subject: 'Subject',
    Domain: 'Domain',
    LearningObjective: 'Learning Objective',
  }

  constructor(private store: StoreService) {
  }

  getValues(key: string) {
    return this.store.filterState.pipe(map(item => item[key]))
  }

  onSelectChange({ target }: Event, key: string) {
    if (target instanceof HTMLSelectElement) {
      const value = target.value === '' ? null : key === 'UserId' ? Number(target.value) : target.value;
      this.store.updateFilterState({[key]: value})
    }
  }
}
