import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AlertModule} from 'ngx-bootstrap/alert'; 

import { GalleryService } from './services/gallery.service';

import { HeaderComponent } from './components/header/header.component';
import {FooterComponent} from './components/footer/footer.component'; 
import { NavbarComponent } from './components/header/navbar/navbar.component';
import {JumbotronComponent} from './components/header/jumbotron/jumbotron.component'; 
import {GalleryComponent} from './components/content/gallery/gallery.component';
import { AllGalleriesComponent } from './components/content/all-galleries/all-galleries.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    JumbotronComponent,
    FooterComponent,
    GalleryComponent,
    HeaderComponent,
    AllGalleriesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    TooltipModule.forRoot(),
    AlertModule.forRoot()
  ],
  providers: [
    GalleryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
