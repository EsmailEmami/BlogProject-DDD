import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AddBlogComponent} from './add-blog.component';
import {RouterModule, Routes} from "@angular/router";
import {LoginComponent} from "../../../auth/pages/login/login.component";
import {ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../../../../shared/shared.module";

const routes: Routes = [{path: '', component: AddBlogComponent}];

@NgModule({
  declarations: [
    AddBlogComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class AddBlogModule {
}
