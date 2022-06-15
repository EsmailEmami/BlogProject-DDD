import {Component, Input, OnInit} from '@angular/core';
import {BlogService} from "../../services/blog.service";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";

@Component({
  selector: 'app-blog-detail-categories',
  templateUrl: './blog-detail-categories.component.html',
})
export class BlogDetailCategoriesComponent implements OnInit {

  @Input('blogId') public blogId!: string;

  public categories: CategoryForShowRequest[] = [];

  constructor(private blogService: BlogService) {
  }

  ngOnInit(): void {
    this.blogService.blogCategories(this.blogId)
      .then(categories => this.categories = categories);
  }
}
