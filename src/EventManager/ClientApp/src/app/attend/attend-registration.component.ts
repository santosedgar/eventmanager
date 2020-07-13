import { Component, Inject } from '@angular/core';
import { Attendency } from '../models/attendency';
import { AttendService } from '../services/attend.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-attend-registration',
    templateUrl: './attend-registration.component.html'
})

export class AttendComponent {
    submitted: boolean = false;

    model: Attendency = new Attendency();
    eventId: any;

    constructor(private attendService: AttendService, private activatedRoute: ActivatedRoute, private router: Router) {
        this.activatedRoute.queryParams.subscribe(params => {
            this.eventId = params["id"];
        });
    }

    onSubmit() {
        this.model.EventId = this.eventId;
        this.submitted = true;
        this.attendService.postAttendendy(this.model)
            .subscribe(
                success => {
                    console.log(success);
                    this.router.navigateByUrl("events");
                },
                error => {
                    alert("There was an error");
                }
            );;
    }

    get diagnostic() { return JSON.stringify(this.model); }
}