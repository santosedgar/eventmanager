import { Component } from "@angular/core";
import { EventService } from "../services/event.service";
import { EventResponse } from "../models/eventModel";
import { Router } from "@angular/router";

@Component({
    selector: 'app-event-list',
    templateUrl: './event-list.component.html'
})

export class EventListComponent {
    public events: EventResponse[] = [];

    constructor(private eventService: EventService, private router: Router) {
        this.getEvents();
    }

    getEvents() {
        this.eventService.getEvents()
            .subscribe(
                success => {
                    console.log(success);
                    this.events = success as EventResponse[];
                },
                error => {
                    alert(error);
                }
            );;
    }

    displayAttendees(eventId: number) {
        this.router.navigateByUrl(`/eventsattendees?id=${eventId}`);
    }
}