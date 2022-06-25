import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {CategoryService} from "../../services/category.service";
import {UpdateCategoryRequest} from "../../../../core/models/requests/category/updateCategoryRequest";
import {AddCategoryRequest} from "../../../../core/models/requests/category/addCategoryRequest";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
})
export class AddCategoryComponent implements OnInit {

  public categoryForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private categoryService: CategoryService) {
  }

  ngOnInit(): void {
    this.categoryForm = this.formBuilder.group({
      categoryTitle: ['',
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

    const request = new AddCategoryRequest(
      this.controls['categoryTitle'].value
    );

    this.categoryService.addCategory(request)
      .then((data) => {
        this.activeModal.close(data);
      });
  }

  closeModal() {
    this.activeModal.close();
  }

}
