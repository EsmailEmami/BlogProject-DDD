import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {BlogRoutingModule} from './blog-routing.module';
import {BlogService} from "./services/blog.service";
import {CommentService} from "./services/comment.service";
import {BlogDetailCommentsComponent} from './components/blog-detail-comments/blog-detail-comments.component';
import {BlogDetailTagsComponent} from './components/blog-detail-tags/blog-detail-tags.component';
import {BlogDetailCategoriesComponent} from './components/blog-detail-categories/blog-detail-categories.component';
import {SharedModule} from "../../shared/shared.module";
import {CategoryService} from "./services/category.service";
import {TagService} from "./services/tag.service";

@NgModule({
  declarations: [
    BlogDetailCommentsComponent,
    BlogDetailTagsComponent,
    BlogDetailCategoriesComponent
  ],
  imports: [
    CommonModule,
    BlogRoutingModule,
    SharedModule
  ],
    exports: [
        BlogDetailTagsComponent,
        BlogDetailCategoriesComponent,
        BlogDetailCommentsComponent
    ],
  providers: [
    BlogService,
    CommentService,
    CategoryService,
    TagService
  ]
})
export class BlogModule {
}
