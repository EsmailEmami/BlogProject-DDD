import {Component, OnInit} from '@angular/core';
import {CategoryService} from "../../services/category.service";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
})
export class CategoriesComponent implements OnInit {
  public categories: CategoryForShowRequest[] = [];


  constructor(private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    this.categoryService.getCategories()
      .then(categories => this.categories = categories);
  }
}
