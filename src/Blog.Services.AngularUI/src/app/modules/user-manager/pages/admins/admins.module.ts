import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AdminsComponent} from './admins.component';
import {RouterModule, Routes} from "@angular/router";
import {SharedModule} from "../../../../shared/shared.module";

const routes: Routes = [{path: '', component: AdminsComponent}]

@NgModule({
  declarations: [
    AdminsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class AdminsModule {
}
