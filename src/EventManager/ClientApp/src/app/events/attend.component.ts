import { Component, Inject } from '@angular/core';

@Component({
    selector: 'app-attend',
    templateUrl: './attend.component.html'
})

export class AttendComponent {
    submitted: boolean = false;

    model: any;


    constructor() {

    }

    onsubmit() {
        alert("submit event");
    }

    get diagnostic() { return JSON.stringify(this.model); }
}