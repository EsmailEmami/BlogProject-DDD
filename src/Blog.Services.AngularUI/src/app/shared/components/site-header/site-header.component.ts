import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../../core/services/auth.service";
import {User} from "../../../core/models/User";
import {CategoryService} from "../../../modules/category/services/category.service";
import {CategoryForShowRequest} from "../../../core/models/requests/category/categoryForShowRequest";

@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html'
})
export class SiteHeaderComponent implements OnInit {

  public user!: User;
  public categories: CategoryForShowRequest[] = [];

  constructor(private authService: AuthService,
              private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => this.user = user);

    this.categoryService.getCategories()
      .then(categories => this.categories = categories);
  }

}
