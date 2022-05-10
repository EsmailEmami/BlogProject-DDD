import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AddCategoryComponent} from './add-category.component';
import {RouterModule, Routes} from "@angular/router";
import {SharedModule} from "../../../../shared/shared.module";

const routes: Routes = [{path: '', component: AddCategoryComponent}];

@NgModule({
  declarations: [
    AddCategoryComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class AddCategoryModule {
}
