import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlogDetailComponent } from './blog-detail.component';
import {RouterModule, Routes} from "@angular/router";
import {SharedModule} from "../../../../shared/shared.module";
import {BlogModule} from "../../blog.module";

const routes: Routes = [{path: '', component: BlogDetailComponent}];

@NgModule({
  declarations: [
    BlogDetailComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
    BlogModule,
  ]
})
export class BlogDetailModule { }
