import { BaseService } from "./base.service";
import { Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AuthenticationService } from "./authentication.service";
import { EventRequest } from "../models/eventRequest";
import { Observable } from "rxjs";

export class EventService extends BaseService {
    constructor(@Inject('BASE_URL') baseUrl: string, http: HttpClient, authenticationService: AuthenticationService) {
        super(baseUrl, http, authenticationService);
        this.getEvents();
    }

    postEvent(event: EventRequest): Observable<object> {
        return this.post("event", event, false);
    }

    getEvents(): Observable<object> {
        return this.get("event", true);
    }


    getEventAttendees(id: string) {
        return this.get(`event/${id}`, true);
    }
}