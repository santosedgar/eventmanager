import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Component({
    selector: 'login.component',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    model: any = {};
    loading = false;
    error = '';

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService) {
    }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();
    }

    onLogin() {
        this.loading = true;
        this.authenticationService.login(this.model.username, this.model.password)
            .subscribe(
                result => {
                    let logged = this.authenticationService.setToken(result, this.model.username);
                    if (logged)
                        this.router.navigate(['/']);
                    else
                        alert("Error login");
                },
                error => {
                    //login failed
                    alert("Invalid credentials");
                    this.loading = false;
                }
            );
    }

    onSignup() {
        this.router.navigateByUrl('/signup');
    }

}
