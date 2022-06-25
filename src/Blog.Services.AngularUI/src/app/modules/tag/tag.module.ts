import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TagRoutingModule } from './tag-routing.module';
import {TagService} from "./services/tag.service";
import { AddTagComponent } from './components/add-tag/add-tag.component';
import {SharedModule} from "../../shared/shared.module";
import {UpdateTagComponent} from "./components/update-tag/update-tag.component";


@NgModule({
  declarations: [
    UpdateTagComponent,
    AddTagComponent
  ],
  imports: [
    CommonModule,
    TagRoutingModule,
    SharedModule
  ],
  providers: [
    TagService
  ]
})
export class TagModule { }
