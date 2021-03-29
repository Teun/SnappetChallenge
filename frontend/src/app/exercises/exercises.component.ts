import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { WorksService } from '../_services/works.service';
import Work from '../_models/works.model';

@Component({
    selector: 'app-exercises',
    templateUrl: './exercises.component.html',
    styleUrls: ['./exercises.component.scss']
})
export class ExercisesComponent implements OnInit {

    public params: FormGroup;
    public maxDate;
    public usersList: Work[] = [];
    public exercises: Work[] = [];
    public displayedColumns: string[] = ['SubmittedAnswerId', 'SubmitDateTime', 'Correct', 'Progress', 'UserId', 'Difficulty', 'Subject', 'Domain'];

    constructor(private worksService: WorksService,
                private formBuilder: FormBuilder
    ) {
        this.maxDate = new Date('2015-03-24 11:30:00 UTC');
        this.params = this.createFormFields();
    }

    private createFormFields(): FormGroup {
        return this.formBuilder.group({
            UserId: new FormControl(),
            // starting from two days ago
            startdate: new FormControl(new Date('2015-03-23 11:30:00 UTC')),
            enddate: new FormControl(this.maxDate),
        });
    }

    private getExercises(filters = {}): void {
        // get new data
        this.worksService.getExercises(filters)
            .subscribe(data => {
                this.exercises = data;
            });
    }

    private getUsersList(): void {
        this.worksService.getUsers()
            .subscribe(data => {
                this.usersList = data;
            });
    }

    ngOnInit(): void {
        this.getUsersList();
    }

    private getFilterValues(): Work {
        return this.worksService.prepareFilters({ ...this.params.value });
    }

    public filter($event: Event): void {
        $event.preventDefault();
        const filters = this.getFilterValues();
        this.getExercises(filters);
    }

}
