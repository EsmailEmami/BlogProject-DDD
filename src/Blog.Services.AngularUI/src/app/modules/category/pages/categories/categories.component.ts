import {Component, OnInit} from '@angular/core';
import {CategoryService} from "../../services/category.service";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";
import {UpdateCategoryRequest} from "../../../../core/models/requests/category/updateCategoryRequest";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {NotificationService} from "../../../../core/services/notification.service";
import {UpdateCategoryComponent} from "../../components/update-category/update-category.component";
import {AddCategoryComponent} from "../../components/add-category/add-category.component";

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
})
export class CategoriesComponent implements OnInit {
  public categories: CategoryForShowRequest[] = [];


  constructor(private categoryService: CategoryService,
              private modalService: NgbModal,
              private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.categoryService.getCategories()
      .then(categories => this.categories = categories);
  }

  newCategory() {
    const modalRef = this.modalService.open(AddCategoryComponent);

    modalRef.result.then((data: CategoryForShowRequest) => {
      if (data) {
        this.categories.unshift(data);
        this.notificationService.showSuccess('دسته بندی با موفقیت افزوده شد');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }

  updateCategory(categoryId: string) {
    const modalRef = this.modalService.open(UpdateCategoryComponent);
    modalRef.componentInstance.categoryId = categoryId;

    modalRef.result.then((data: UpdateCategoryRequest) => {
      if (data) {
        // @ts-ignore
        this.categories.find(x => x.categoryId == data.categoryId).categoryTitle = data.categoryTitle;

        this.notificationService.showSuccess('دسته بندی با موفقیت ویرایش شد');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }
}
