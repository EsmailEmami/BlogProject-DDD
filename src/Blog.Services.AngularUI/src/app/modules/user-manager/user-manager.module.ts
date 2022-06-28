import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UserManagerRoutingModule} from './user-manager-routing.module';
import {UserService} from "./services/user.service";
import { UpdateUserComponent } from './components/update-user/update-user.component';
import {SharedModule} from "../../shared/shared.module";
import {RoleService} from "./services/role.service";


@NgModule({
  declarations: [
    UpdateUserComponent
  ],
  imports: [
    CommonModule,
    UserManagerRoutingModule,
    SharedModule
  ],
  providers: [
    UserService,
    RoleService
  ]
})
export class UserManagerModule {
}
