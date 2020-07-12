import { Component } from "@angular/core";
import { EventService } from "../services/event.service";
import { EventResponse } from "../models/eventModel";

@Component({
    selector: 'app-event-list',
    templateUrl: './event-list.component.html'
})

export class EventListComponent {
    public events: EventResponse[] = [];
    eventService: EventService;

    constructor(eventService: EventService) {
        this.eventService = eventService;
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
}