import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoleManagerRoutingModule } from './role-manager-routing.module';
import { UpdateRoleComponent } from './components/update-role/update-role.component';
import {RoleService} from "./services/role.service";
import {SharedModule} from "../../shared/shared.module";
import { AddRoleComponent } from './components/add-role/add-role.component';


@NgModule({
  declarations: [
    UpdateRoleComponent,
    AddRoleComponent
  ],
  imports: [
    CommonModule,
    RoleManagerRoutingModule,
    SharedModule
  ],
  providers:[
    RoleService
  ]
})
export class RoleManagerModule { }
