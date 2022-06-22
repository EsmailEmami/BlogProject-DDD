import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UserRoutingModule} from './user-routing.module';
import {UserService} from "./services/user.service";
import { DashboardUpdatePasswordComponent } from './components/dashboard-update-password/dashboard-update-password.component';
import {SharedModule} from "../../shared/shared.module";
import { DashboardUpdateDashboardComponent } from './components/dashboard-update-dashboard/dashboard-update-dashboard.component';


@NgModule({
  declarations: [
    DashboardUpdatePasswordComponent,
    DashboardUpdateDashboardComponent
  ],
    imports: [
        CommonModule,
        UserRoutingModule,
        SharedModule
    ],
  providers: [
    UserService
  ],
  bootstrap: []
})
export class UserModule {
}
