import { Component, OnInit } from '@angular/core';
import {GalleryService} from './gallery.service';
import { IGallery } from '../gallery.interface';

@Component ({
    selector:'app-gallery',
    templateUrl:'./gallery.component.html',
    styleUrls: ['./gallery.component.css'],
    providers: [GalleryService]
})
export class GalleryComponent {
   
    galleries: IGallery[] = [];  
    constructor(public galleryService: GalleryService) {   
    }

    // загрузка данных при старте component  
    ngOnInit() {
        this.galleryService.GetGalleries().subscribe(res=>{
            this.galleries=res;
        })  
    }
}