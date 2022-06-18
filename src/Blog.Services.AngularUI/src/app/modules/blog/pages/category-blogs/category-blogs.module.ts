import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryBlogsComponent } from './category-blogs.component';
import {SharedModule} from "../../../../shared/shared.module";



@NgModule({
  declarations: [
    CategoryBlogsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class CategoryBlogsModule { }
