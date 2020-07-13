import { BaseService } from "./base.service";
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class AuthenticationService {

    public token: string | null = null;

    public menuItems: Array<any> = [];

    constructor(@Inject('BASE_URL') private _baseUrl: string,
        private http: HttpClient) {
        //set token if saved in local storage
        let itemStorage = localStorage.getItem("currentUser");
        if (itemStorage) {
            let currentUser = JSON.parse(itemStorage);
            this.token = currentUser && currentUser.token;
        }
    }

    login(username: string, password: string): Observable<object> {
        return this.http.post(this._baseUrl + "api/account/login",
            { username: username, password: password });
    }

    setToken(response: any, username: string): boolean {
        //login sucessful if there is a jwt token in the response
        let token = response.accessToken;
        if (token) {
            //set token property
            this.token = token;

            //store username and jwt in local storage to keep user logged in between page refreshes
            localStorage.setItem("currentUser", JSON.stringify(
                {
                    username: username,
                    user: this.getClaimsFromToken(token),
                    token: token,
                    expiration: response.expiration
                })
            );
            this.refreshMenuItems();

            //return true to indicate sucessful login
            return true;
        }
        else {
            //return false to indicate failed login
            return false;
        }
    }

    logout(): void {
        //clear token remove user from local storage to log user out
        this.refreshMenuItems();
        this.token = null;
        localStorage.removeItem('currentUser');
    }

    getUserId(): any {
        if (this.isLogged() == false)
            return null;
        var claims = JSON.parse(localStorage.currentUser).user;
        return claims["UserId"];
    }

    getUserName(): any {
        if (this.isLogged() == false)
            return null;
        var name = JSON.parse(localStorage.currentUser).username;
        return name;
    }

    isLogged() {
        return localStorage.currentUser != null
            && localStorage.currentUser != undefined
            && localStorage.currentUser != 'undefined';
    }

    private urlBase64Decode(str: string) {
        var result = str.replace('-', '+').replace('_', '/ ');
        switch (result.length % 4) {
            case 0:
                break;
            case 2:
                result += '==';
                break;
            case 3:
                result += '=';
                break;
            default:
                throw 'Illegal base64 url string';
        }
        return window.atob(result);
    }

    private getClaimsFromToken(token: string): any {
        var user = {};
        if (typeof token !== 'undefined') {
            var encoded = token.split('.')[1];
            user = JSON.parse(this.urlBase64Decode(encoded));
        }
        return user;
    }

    public refreshMenuItems() {
        this.menuItems = [];
        if (this.isLogged) {
            this.menuItems.push(
                {
                    "name": "Register Event",
                    "routerLink": "/registerevent"
                }
            );
        }
    }
}