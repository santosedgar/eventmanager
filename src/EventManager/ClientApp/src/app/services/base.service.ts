import { Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, Subscription } from "rxjs";

export class BaseService {
    baseUrl: string;
    http: HttpClient;

    constructor(@Inject('BASE_URL') baseUrl: string, http: HttpClient) {
        this.baseUrl = baseUrl + "api/";
        this.http = http;
    }

    protected handleError(error: any) {
        if (error.status === 401) { //User Unauthorized
            //TODO
            //this.authenticationService.logout();
            //this.router.navigate(['/login']);
        }

        //return Observable.throw(error.json() || 'Server error');
    }

    createAuthorizationHeader(headers: HttpHeaders) {
        //TODO
        /*
        headers.set('Authorization', 'Bearer ' +
            this.authenticationService.token);*/
    }

    protected get(endpoint: string, allowAnonymous: boolean = true): Observable<object> {
        let headers = new HttpHeaders();
        if (!allowAnonymous)
            this.createAuthorizationHeader(headers);

        return this.http.get(this.baseUrl + endpoint,
            {

            });
    }

    protected post(endpoint: string, data: any, allowAnonymous: boolean = true): Observable<object> {
        let headers = new HttpHeaders();
        if (allowAnonymous == false) {
            this.createAuthorizationHeader(headers);
        }

        return this.http.post(this.baseUrl + endpoint, data,
            {
                headers: headers
            });
    }
}