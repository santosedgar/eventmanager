import { BaseService } from "./base.service";
import { Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Subscription, Observable } from "rxjs";
import { Attendency } from "../models/attendency";


export class AttendService extends BaseService {
    constructor(@Inject('BASE_URL') baseUrl: string, http: HttpClient) {

        super(baseUrl, http);
    }

    postAttendendy(attendency: Attendency): Observable<object> {
        return this.post("attend", attendency, true);
    }
}