import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {BlogService} from "../../../blog/services/blog.service";
import {NotificationService} from "../../../../core/services/notification.service";
import {CategoryService} from "../../services/category.service";
import {AddBlogRequest} from "../../../../core/models/requests/blog/addBlogRequest";
import {AddCategoryRequest} from "../../../../core/models/requests/category/addCategoryRequest";

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html'
})
export class AddCategoryComponent implements OnInit {

  public categoryForm!: FormGroup;
  public loading = false;
  public errors!: string[];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private categoryService: CategoryService,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {
    this.categoryForm = this.formBuilder.group({
      categoryTitle: ['',
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20)
      ],
    });
  }

  get controls() {
    return this.categoryForm.controls;
  }

  onSubmit() {
    if (this.categoryForm.invalid) {
      return;
    }
    this.loading = true;

    const request = new AddCategoryRequest(
      this.controls['categoryTitle'].value
    );

    this.categoryService.addCategory(request)
      .then(data => {
        this.notificationService.showSuccess("مقاله با موفقیت منتشر شد.");
        this.router.navigate(['']).then();
      }, error => {
        for (const message of error.errors) {
          this.errors.push(message);
        }
      });

    this.loading = false;
  }

}
