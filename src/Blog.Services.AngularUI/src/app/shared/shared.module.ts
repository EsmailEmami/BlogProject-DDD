import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SiteHeaderComponent} from './components/site-header/site-header.component';
import {SiteFooterComponent} from './components/site-footer/site-footer.component';
import {ImagePickerComponent} from './components/image-picker/image-picker.component';
import {NgxImageCompressService} from "ngx-image-compress";

@NgModule({
  declarations: [
    SiteHeaderComponent,
    SiteFooterComponent,
    ImagePickerComponent,
    ImagePickerComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  exports: [
    SiteHeaderComponent,
    SiteFooterComponent,
    ImagePickerComponent,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    NgxImageCompressService
  ]

})
export class SharedModule {
}
