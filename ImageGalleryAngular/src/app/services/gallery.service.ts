import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { IGallery } from '../interface/gallery';
import { IGalleryImage } from "../interface/gallery-image";
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()

export class GalleryService {
  public status: string = "";
  public errorMessage: string = "";
  private url = "/api/Galleries";
  private urlImgs = "/api/GalleryImages";

  constructor(private http: HttpClient) { }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.errorMessage = error;
      console.error(error);
      return of(result as T);
    };
  }

  public GetGalleries(): Observable<IGallery[]> {
    return this.http.get<IGallery[]>(this.url)
      .pipe(
        catchError(this.handleError<IGallery[]>('GetGalleries', []))
      );
  }

  public GetGallery(Id: number): Observable<IGallery[]> {
    let currentUrl = this.url + '/' + Id;
    return this.http.get<IGallery[]>(currentUrl)
      .pipe(
        catchError(this.handleError<IGallery[]>('GetGalleries', []))
      );
  }

  public GetGalleryImages(Id: number): Observable<IGalleryImage[]> {
    return this.http.get<IGalleryImage[]>(this.urlImgs + '?galleryId=' + Id)
      .pipe(
        catchError(this.handleError<IGalleryImage[]>('GetGalleries', []))
      );
  }

  public DeleteGallery(Id: number) {
    let currentUrl = this.url + '/' + Id;
    this.http.delete(currentUrl).subscribe({
      next: data => {
        this.status = 'Delete successful';
      },
      error: error => {
        this.errorMessage = error.message;
      }
    });
  }

  public DeleteGalleryImage(Id: number) {
    let currentUrl = this.urlImgs + '/' + Id;
    this.http.delete(currentUrl).subscribe({
      next: data => {
        this.status = 'Delete successful';
      },
      error: error => {
        this.errorMessage = error.message;
      }
    });
  }

  public PostGallery() { }
  public PutGallery() { }

  public PostGalleryImage() { }
  public PutGalleryImage() { }

}