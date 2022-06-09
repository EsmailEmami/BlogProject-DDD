import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {BlogListComponent} from "./blog-list.component";
import {BlogModule} from "../../blog.module";
import {SharedModule} from "../../../../shared/shared.module";

const routes: Routes = [{path: '', component: BlogListComponent}];

@NgModule({
  declarations: [
    BlogListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    BlogModule,
    SharedModule,
  ]
})
export class BlogListModule { }
