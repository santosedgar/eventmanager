import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AttendComponent } from './events/attend.component';
import { AttendListComponent } from './events/attend-list.component';
import { EventListComponent } from './events/event-list.component';

//Services
import { AttendService } from './services/attend.service';
import { EventService } from './services/event.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AttendComponent,
    AttendListComponent,
    EventListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'attend', component: AttendComponent },
      { path: 'events', component: EventListComponent },
      { path: 'eventsattendees', component: AttendListComponent }
    ])
  ],
  providers: [
    AttendService,
    EventService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
