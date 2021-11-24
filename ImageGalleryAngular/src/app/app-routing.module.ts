import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllGalleriesComponent } from './components/content/all-galleries/all-galleries.component';
import { GalleryComponent } from './components/content/gallery/gallery.component';

const routes: Routes =  [
  {path: '', component: AllGalleriesComponent},
  {path: 'galleries/:id', component: GalleryComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
