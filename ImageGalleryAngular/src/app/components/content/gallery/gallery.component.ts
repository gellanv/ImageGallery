import { Component, OnInit } from '@angular/core';
import { GalleryService } from '../../../services/gallery.service';
import { IGallery } from '../../../interface/gallery';
import { IGalleryImage } from '../../../interface/gallery-image';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { NgZone } from '@angular/core';

@Component({
    selector: 'app-gallery',
    templateUrl: './gallery.component.html',
    styleUrls: ['./gallery.component.css'],
    providers: [GalleryService]
})
export class GalleryComponent {
    private galleryId: number = -1;
    public gallery: IGallery = {};
    public galleryImages: IGalleryImage[] = [];
    private subscription: Subscription;

    constructor(public galleryService: GalleryService, private ngZone: NgZone, private router: Router, private activateRoute: ActivatedRoute) {
        this.subscription = activateRoute.params.subscribe(params => this.galleryId = params['id']);

        this.galleryService.GetGallery(this.galleryId).subscribe(res => {
            this.gallery = res as IGallery;
        })
        this.galleryService.GetGalleryImages(this.galleryId).subscribe(res => {
            res.forEach(x => x.photo = "/api/GalleryImages/" + x.id);
            this.galleryImages = res;
        })
    }
    ngOnInit() { }
    public dellGalleryImage(event: any) {
        const button = event.target as HTMLButtonElement;
        let Id: number = +button.id;
        this.galleryService.DeleteGalleryImage(Id);
        this.galleryImages.forEach((item, index) => {
            if (item.id === Id) this.galleryImages.splice(index, 1);
        });
    }
}