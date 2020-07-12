import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';


//Components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AttendComponent } from './events/attend.component';
import { AttendListComponent } from './events/attend-list.component';
import { EventListComponent } from './events/event-list.component';
import { LoginComponent } from './login/login.component';

//Services
import { AttendService } from './services/attend.service';
import { EventService } from './services/event.service';
import { AuthenticationService } from './services/authentication.service';
import { AuthGuard } from './guards/auth_guard';
import { NgbDateMomentParserFormatter } from './helpers/ngbDateMomentParserFormatter';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AttendComponent,
    AttendListComponent,
    EventListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'attend', component: AttendComponent },
      { path: 'events', component: EventListComponent },
      { path: 'eventsattendees', component: AttendListComponent },
      { path: 'newevent', component: AttendListComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent }
    ])
  ],
  providers: [
    AuthGuard,
    AttendService,
    EventService,
    AuthenticationService,
    {
      provide: NgbDateParserFormatter,
      useFactory: () => { return new NgbDateMomentParserFormatter("MM-DD-YYYY") }
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
