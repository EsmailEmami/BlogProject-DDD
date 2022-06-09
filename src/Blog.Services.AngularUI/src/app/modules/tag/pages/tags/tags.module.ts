import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TagsComponent } from './tags.component';
import {RouterModule, Routes} from "@angular/router";

const routes: Routes = [{path: '', component: TagsComponent}];

@NgModule({
  declarations: [
    TagsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class TagsModule { }
