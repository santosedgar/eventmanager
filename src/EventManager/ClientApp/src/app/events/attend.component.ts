import { Component, Inject } from '@angular/core';
import { Attendency } from '../models/attendency';
import { AttendService } from '../services/attend.service';

@Component({
    selector: 'app-attend',
    templateUrl: './attend.component.html'
})

export class AttendComponent {
    submitted: boolean = false;

    model: Attendency = new Attendency();
    attendService: AttendService;

    constructor(attendService: AttendService) {
        this.attendService = attendService;
    }

    onSubmit() {
        //TODO
        this.model.EventId = "C282E599-DFEE-4E55-E95E-08D8267E9F8D";
        this.submitted = true;
        this.attendService.postAttendendy(this.model);
    }

    get diagnostic() { return JSON.stringify(this.model); }
}