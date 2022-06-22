import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SiteHeaderComponent} from './components/site-header/site-header.component';
import {SiteFooterComponent} from './components/site-footer/site-footer.component';
import {ImagePickerComponent} from './components/image-picker/image-picker.component';
import {NgxImageCompressService} from "ngx-image-compress";
import {BlogComponent} from './components/blog/blog.component';
import {RouterModule} from "@angular/router";
import {PersianDatePipe} from "./pipes/persian-date.pipe";
import {SeparatePipe} from "./pipes/separate.pipe";
import { BlogImagePipe } from './pipes/blog-image.pipe';
import { PersianDateTimePipe } from './pipes/persian-date-time.pipe';

@NgModule({
  declarations: [
    SiteHeaderComponent,
    SiteFooterComponent,
    ImagePickerComponent,
    PersianDatePipe,
    SeparatePipe,
    BlogComponent,
    BlogImagePipe,
    PersianDateTimePipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    SiteHeaderComponent,
    SiteFooterComponent,
    ImagePickerComponent,
    PersianDatePipe,
    PersianDateTimePipe,
    SeparatePipe,
    BlogImagePipe,
    BlogComponent,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    NgxImageCompressService
  ]

})
export class SharedModule {
}
