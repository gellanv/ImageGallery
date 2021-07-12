import { Injectable } from "@angular/core";
import { HttpClient} from '@angular/common/http';
import { IGallery } from '../gallery.interface';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()

export class GalleryService{

    private url = "/api/Galleries";

    constructor(private http: HttpClient) {}

    GetGalleries(){    
    return this.http.get<IGallery[]>(this.url)
    }
    
    getGalleryThumb(galleryId: number): string {
        return `/galleries/${galleryId}/thumb`;
      }
}