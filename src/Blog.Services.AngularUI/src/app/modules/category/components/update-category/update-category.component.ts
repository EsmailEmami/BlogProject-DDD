import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CategoryService} from "../../services/category.service";
import {UpdateCategoryRequest} from "../../../../core/models/requests/category/updateCategoryRequest";

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
})
export class UpdateCategoryComponent implements OnInit {

  @Input() private categoryId!: string;
  public categoryForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    if (this.categoryId == null) {
      this.activeModal.dismiss('متاسفانه مشکلی پیش آمده است! لطفا دوباره تلاش کنید.');
    }

    this.categoryService.getCategoryForUpdate(this.categoryId)
      .then((data: UpdateCategoryRequest) => {
        this.categoryForm = this.formBuilder.group({
          categoryTitle: [data.categoryTitle,
            Validators.compose([
              Validators.required,
              Validators.minLength(3),
              Validators.maxLength(20)
            ])
          ],
        });
      }, () => {
        this.activeModal.dismiss();
      });
  }

  get controls() {
    return this.categoryForm.controls;
  }

  onSubmit() {
    if (this.categoryForm.invalid) {
      return;
    }

    const request = new UpdateCategoryRequest(
      this.categoryId,
      this.controls['categoryTitle'].value
    );

    this.categoryService.updateCategory(request)
      .then(() => {
        this.activeModal.close(request);
        this.categoryForm.reset();
      });
  }

  closeModal() {
    this.activeModal.close();
  }
}
