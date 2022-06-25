import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CategoryRoutingModule} from './category-routing.module';
import {CategoryService} from "./services/category.service";
import { UpdateCategoryComponent } from './components/update-category/update-category.component';
import {SharedModule} from "../../shared/shared.module";
import { AddCategoryComponent } from './components/add-category/add-category.component';


@NgModule({
  declarations: [
    UpdateCategoryComponent,
    AddCategoryComponent
  ],
    imports: [
        CommonModule,
        CategoryRoutingModule,
        SharedModule
    ],
  providers: [
    CategoryService
  ]
})
export class CategoryModule {
}
