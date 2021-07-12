import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AlertModule} from 'ngx-bootstrap/alert';
import { NavbarComponent } from './navbar/navbar.component';
import {JumbotronComponent} from './jumbotron/jumbotron.component';     
import {FooterComponent} from './footer/footer.component'; 
import {GalleryComponent} from './gallery/gallery.component';
import { GalleryService } from './gallery/gallery.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    JumbotronComponent,
    FooterComponent,
    GalleryComponent  
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    TooltipModule.forRoot(),
    AlertModule.forRoot()
  ],
  providers: [GalleryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
