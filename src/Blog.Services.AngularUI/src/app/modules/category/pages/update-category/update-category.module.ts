import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UpdateCategoryComponent} from './update-category.component';
import {SharedModule} from "../../../../shared/shared.module";
import {RouterModule, Routes} from "@angular/router";

const routes: Routes = [
  {path: '', redirectTo: '/', pathMatch: 'full'},
  {path: ':categoryId', component: UpdateCategoryComponent},
];

@NgModule({
  declarations: [
    UpdateCategoryComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class UpdateCategoryModule {
}
