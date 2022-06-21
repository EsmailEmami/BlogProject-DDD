import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BlogRoutingModule} from './blog-routing.module';
import {BlogService} from "./services/blog.service";
import {CommentService} from "./services/comment.service";
import {BlogDetailCommentsComponent} from './components/blog-detail-comments/blog-detail-comments.component';
import {BlogDetailTagsComponent} from './components/blog-detail-tags/blog-detail-tags.component';
import {BlogDetailCategoriesComponent} from './components/blog-detail-categories/blog-detail-categories.component';
import {SharedModule} from "../../shared/shared.module";
import { BlogDetailAddCommentComponent } from './components/blog-detail-add-comment/blog-detail-add-comment.component';


@NgModule({
  declarations: [
    BlogDetailCommentsComponent,
    BlogDetailTagsComponent,
    BlogDetailCategoriesComponent,
    BlogDetailAddCommentComponent
  ],
  imports: [
    CommonModule,
    BlogRoutingModule,
    SharedModule
  ],
    exports: [
        BlogDetailTagsComponent,
        BlogDetailCategoriesComponent,
        BlogDetailCommentsComponent,
        BlogDetailAddCommentComponent
    ],
  providers: [
    BlogService,
    CommentService
  ]
})
export class BlogModule {
}
