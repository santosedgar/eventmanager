import { Component } from "@angular/core";
import { EventService } from "../services/event.service";
import { EventResponse } from "../models/eventModel";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-event-list',
    templateUrl: './attend-list.component.html'
})

export class AttendListComponent {
    public event: EventResponse;
    id: string;

    constructor(private eventService: EventService, private activatedRoute: ActivatedRoute) {
        this.activatedRoute.queryParams.subscribe(params => {
            this.id = params["id"];
        });
        this.getEventAttendees();
    }

    getEventAttendees() {
        if (this.id == null || this.id == "")
            return;
        this.eventService.getEventAttendees(this.id)
            .subscribe(
                success => {
                    console.log(success);
                    this.event = success as EventResponse;
                },
                error => {
                    //alert(error);
                }
            );;
    }
}