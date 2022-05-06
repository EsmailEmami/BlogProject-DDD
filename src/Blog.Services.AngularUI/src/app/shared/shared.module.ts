import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { SiteHeaderComponent } from './components/site-header/site-header.component';
import { SiteFooterComponent } from './components/site-footer/site-footer.component';

@NgModule({
    declarations: [
        SiteHeaderComponent,
        SiteFooterComponent
    ],
  exports: [
    SiteHeaderComponent,
    SiteFooterComponent
  ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
    ]
})
export class SharedModule {
}
