import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UpdateBlogComponent} from './update-blog.component';
import {RouterModule, Routes} from "@angular/router";
import {SharedModule} from "../../../../shared/shared.module";

const routes: Routes = [{path: '', component: UpdateBlogComponent}];

@NgModule({
  declarations: [
    UpdateBlogComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class UpdateBlogModule {
}
