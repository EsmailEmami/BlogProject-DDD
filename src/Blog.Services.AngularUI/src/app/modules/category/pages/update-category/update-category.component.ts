import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {CategoryService} from "../../services/category.service";
import {NotificationService} from "../../../../core/services/notification.service";
import {UpdateCategoryRequest} from "../../../../core/models/requests/category/updateCategoryRequest";

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
})
export class UpdateCategoryComponent implements OnInit {

  public categoryForm!: FormGroup;
  public loading = false;
  public errors!: string[];
  private categoryId!: string;
  private category!: UpdateCategoryRequest;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private categoryService: CategoryService,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {

    this.categoryId = this.route.snapshot.params['categoryId'];

    if (!this.categoryId) {
      this.router.navigate(['']).then();
    }

    this.categoryService.getCategoryForUpdate(this.categoryId)
      .then((data: UpdateCategoryRequest) => {
        this.category = data;
      }, error => {
        this.router.navigate(['']).then();
      });

    this.categoryForm = this.formBuilder.group({
      categoryTitle: [this.category.categoryTitle,
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20)
        ])
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

    const request = new UpdateCategoryRequest(
      this.category.categoryId,
      this.controls['categoryTitle'].value
    );

    this.categoryService.updateCategory(request)
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
