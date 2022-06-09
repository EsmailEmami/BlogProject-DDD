import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TagRoutingModule } from './tag-routing.module';
import { UpdateTagComponent } from './pages/update-tag/update-tag.component';
import {TagService} from "./services/tag.service";


@NgModule({
  declarations: [
    UpdateTagComponent
  ],
  imports: [
    CommonModule,
    TagRoutingModule
  ],
  providers: [
    TagService
  ]
})
export class TagModule { }
