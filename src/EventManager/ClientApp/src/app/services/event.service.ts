import { BaseService } from "./base.service";
import { Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Subscription, Observable } from "rxjs";

export class EventService extends BaseService {
    constructor(@Inject('BASE_URL') baseUrl: string, http: HttpClient) {
        super(baseUrl, http);
        this.getEvents();
    }

    getEvents(): Observable<object> {
        return this.get("event", true);
    }


    getEventAttendees(id: string) {
        return this.get(`event/${id}`, true);
    }
}