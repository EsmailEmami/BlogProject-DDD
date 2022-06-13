import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BlogRoutingModule} from './blog-routing.module';
import {BlogService} from "./services/blog.service";
import {CommentService} from "./services/comment.service";
import {BlogDetailCommentsComponent} from './components/blog-detail-comments/blog-detail-comments.component';
import {BlogDetailTagsComponent} from './components/blog-detail-tags/blog-detail-tags.component';
import {BlogDetailCategoriesComponent} from './components/blog-detail-categories/blog-detail-categories.component';


@NgModule({
  declarations: [
    BlogDetailCommentsComponent,
    BlogDetailTagsComponent,
    BlogDetailCategoriesComponent
  ],
  imports: [
    CommonModule,
    BlogRoutingModule
  ],
  exports: [
    BlogDetailTagsComponent
  ],
  providers: [
    BlogService,
    CommentService
  ]
})
export class BlogModule {
}
