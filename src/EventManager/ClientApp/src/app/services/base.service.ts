import { Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, Subscription } from "rxjs";
import { AuthenticationService } from "./authentication.service";

export class BaseService {
    baseUrl: string;

    constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient, private authenticationService: AuthenticationService) {
        this.baseUrl = baseUrl + "api/";
    }

    createAuthorizationHeader(headers: HttpHeaders) {
        return headers.set('Authorization', 'Bearer ' +
            this.authenticationService.token);
    }

    protected get(endpoint: string, allowAnonymous: boolean = true): Observable<object> {
        let headers = new HttpHeaders();
        if (!allowAnonymous)
            headers = this.createAuthorizationHeader(headers);

        return this.http.get(this.baseUrl + endpoint,
            {
                headers: headers
            });
    }

    protected post(endpoint: string, data: any, allowAnonymous: boolean = true): Observable<object> {
        let headers = new HttpHeaders();
        if (allowAnonymous == false) {
            headers = this.createAuthorizationHeader(headers);
        }

        return this.http.post(this.baseUrl + endpoint, data,
            {
                headers: headers,
                observe: 'response'
            });
    }
}