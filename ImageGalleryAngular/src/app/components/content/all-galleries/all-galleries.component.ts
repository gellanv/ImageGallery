import { Component, OnInit } from '@angular/core';
import { GalleryService } from '../../../services/gallery.service';
import { IGallery } from '../../../interface/gallery';

@Component({
    selector: 'app-all-galleries',
    templateUrl: './all-galleries.component.html',
    styleUrls: ['./all-galleries.component.css'],
    providers: [GalleryService]
})
export class AllGalleriesComponent implements OnInit {
    public galleries: IGallery[] = [];
    constructor(public galleryService: GalleryService) {
    }
    ngOnInit() {
        this.galleryService.GetGalleries().subscribe(res => {
            this.galleries = res;
        })
    }
    public dellGallery(event: any) {
        const button = event.target as HTMLButtonElement;
        let Id: number = +button.id;
        this.galleryService.DeleteGallery(Id);
        this.galleries.forEach((item, index) => {
            if (item.id === Id) this.galleries.splice(index, 1);
        });
    }
}