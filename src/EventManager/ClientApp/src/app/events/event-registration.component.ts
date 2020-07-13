import { Component } from "@angular/core";
import { EventService } from "../services/event.service";
import { Router } from "@angular/router";
import { EventResponse } from "../models/eventResponse";
import { NgbDateStruct, NgbTimeStruct } from "@ng-bootstrap/ng-bootstrap";
import * as moment from "moment";
import { AuthenticationService } from "../services/authentication.service";
import { EventRequest } from "../models/eventRequest";
import { HttpResponse } from "@angular/common/http";

@Component({
    selector: 'app-event-registration',
    templateUrl: './event-registration.component.html'
})

export class EventRegistrationComponent {
    model: EventRequest = new EventRequest();

    dateStart: NgbDateStruct;
    timeStart: NgbTimeStruct;

    dateEnd: NgbDateStruct;
    timeEnd: NgbTimeStruct;

    constructor(private eventService: EventService, private router: Router, private authenticationService: AuthenticationService) {
        let now = new Date();
        this.dateStart = { month: now.getMonth(), day: now.getDate(), year: now.getFullYear() };
        this.timeStart = { hour: now.getHours(), minute: now.getMinutes(), second: 0 };
        now.setMinutes(now.getMinutes() + 60);
        this.dateEnd = { month: now.getMonth(), day: now.getDate(), year: now.getFullYear() };
        this.timeEnd = { hour: now.getHours(), minute: now.getMinutes(), second: 0 };
    }

    onSubmit() {
        this.model.StartTime = moment(this.dateStart.year + '/' + this.dateStart.month + '/' + this.dateStart.day + this.timeStart.hour + ':' + this.timeStart.minute, "YYYY-MM-DD hh:mm").toDate();
        this.model.EndTime = moment(this.dateEnd.year + '/' + this.dateEnd.month + '/' + this.dateEnd.day + this.timeEnd.hour + ':' + this.timeEnd.minute, "YYYY-MM-DD hh:mm").toDate();

        this.eventService.postEvent(this.model)
            .subscribe(
                (success: HttpResponse<object>) => {
                    if (success.status === 401) { //User Unauthorized
                        this.authenticationService.logout();
                        this.router.navigate(['/login']);
                    }
                    this.router.navigateByUrl("/events")
                },
                error => {
                    alert("There was na error");
                }
            );;
    }

}