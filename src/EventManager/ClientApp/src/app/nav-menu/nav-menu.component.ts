import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authenticationService: AuthenticationService, private router: Router) {

  }

  ngOnInit() {
    this.authenticationService.refreshMenuItems();
  }

  private isLogged() {
    return this.authenticationService.isLogged();
  }

  onSignOut() {
    this.authenticationService.logout();
    this.router.navigate(['/events']);
  }

  onSignIn() {
    this.router.navigate(['/login']);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
