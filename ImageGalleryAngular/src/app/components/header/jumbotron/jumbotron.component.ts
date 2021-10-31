import { Component } from '@angular/core';

@Component({
    selector: 'app-jumbotron',
    templateUrl: './jumbotron.component.html',
    styleUrls: ['./jumbotron.component.css']
})
export class JumbotronComponent {
    public headerContentTitle: string = 'All Lifes Moments Image Gallery';
    public headerContentNext: string = 'A beautiful display of your images';
}
