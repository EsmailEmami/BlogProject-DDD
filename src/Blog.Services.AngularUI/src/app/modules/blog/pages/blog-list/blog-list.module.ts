import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {BlogListComponent} from "./blog-list.component";
import {SharedModule} from "../../../../shared/shared.module";

const routes: Routes = [{path: '', component: BlogListComponent}];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class BlogListModule { }
