import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CategoryRoutingModule} from './category-routing.module';
import {CategoryService} from "./services/category.service";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CategoryRoutingModule
  ],
  providers: [
    CategoryService
  ]
})
export class CategoryModule {
}
