import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RolesResolver} from "./resolvers/roles.resolver";

const routes: Routes = [
  {
    path: '', redirectTo: '/role/roles', pathMatch: 'full'
  },
  {
    path: 'roles',
    loadChildren: () => import('./pages/roles/roles.module').then(m => m.RolesModule),
    resolve: {'roles': RolesResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleManagerRoutingModule {
}
