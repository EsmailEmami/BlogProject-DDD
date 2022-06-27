import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UserManagerRoutingModule} from './user-manager-routing.module';
import {UserService} from "./services/user.service";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UserManagerRoutingModule
  ],
  providers: [
    UserService
  ]
})
export class UserManagerModule {
}
