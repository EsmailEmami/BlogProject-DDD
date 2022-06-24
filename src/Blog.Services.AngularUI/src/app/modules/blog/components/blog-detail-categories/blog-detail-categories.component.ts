import {Component, Input, OnInit} from '@angular/core';
import {BlogService} from "../../services/blog.service";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";
import {CategoryService} from "../../services/category.service";

@Component({
  selector: 'app-blog-detail-categories',
  templateUrl: './blog-detail-categories.component.html',
})
export class BlogDetailCategoriesComponent implements OnInit {

  @Input('blogId') public blogId!: string;

  public categories: CategoryForShowRequest[] = [];

  constructor(private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    this.categoryService.getBlogCategories(this.blogId)
      .then(categories => this.categories = categories);
  }
}
