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
import { AttendComponent } from './attend/attend-registration.component';
import { AttendListComponent } from './attend/attend-list.component';
import { EventListComponent } from './events/event-list.component';
import { EventRegistrationComponent } from './events/event-registration.component';
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
    EventRegistrationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: EventListComponent, pathMatch: 'full' },
      { path: 'attendtoevent', component: AttendComponent },
      { path: 'events', component: EventListComponent },
      { path: 'eventsattendees', component: AttendListComponent },
      { path: 'registerevent', component: EventRegistrationComponent, canActivate: [AuthGuard] },
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
