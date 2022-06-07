import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SiteHeaderComponent} from './components/site-header/site-header.component';
import {SiteFooterComponent} from './components/site-footer/site-footer.component';
import {ImagePickerComponent} from './components/image-picker/image-picker.component';
import {NgxImageCompressService} from "ngx-image-compress";
import {RouterModule} from "@angular/router";
import { BlogComponent } from './components/blog/blog.component';
import {CoreModule} from "../core/core.module";

@NgModule({
  declarations: [
    SiteHeaderComponent,
    SiteFooterComponent,
    ImagePickerComponent,
    ImagePickerComponent,
    BlogComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    CoreModule
  ],
    exports: [
        SiteHeaderComponent,
        SiteFooterComponent,
        ImagePickerComponent,
        ReactiveFormsModule,
        FormsModule,
        BlogComponent
    ],
  providers: [
    NgxImageCompressService
  ]

})
export class SharedModule {
}
