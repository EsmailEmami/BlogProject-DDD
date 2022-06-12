import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BlogRoutingModule} from './blog-routing.module';
import {BlogService} from "./services/blog.service";
import {CommentService} from "./services/comment.service";


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    BlogRoutingModule
  ],
  exports: [
  ],
  providers: [
    BlogService,
    CommentService
  ]
})
export class BlogModule {
}
