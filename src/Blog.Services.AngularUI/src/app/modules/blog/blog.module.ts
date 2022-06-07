import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {BlogRoutingModule} from './blog-routing.module';
import {BlogService} from "./services/blog.service";
import { BlogListComponent } from './pages/blog-list/blog-list.component';
import {SharedModule} from "../../shared/shared.module";


@NgModule({
  declarations: [
    BlogListComponent
  ],
    imports: [
        CommonModule,
        BlogRoutingModule,
        SharedModule
    ],
  providers: [
    BlogService
  ]
})
export class BlogModule {
}
