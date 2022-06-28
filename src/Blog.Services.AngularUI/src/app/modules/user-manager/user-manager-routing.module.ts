import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UsersResolver} from "./resolvers/users.resolver";
import {AdminsResolver} from "./resolvers/admins.resolver";

const routes: Routes = [
  {
    path: '', redirectTo: '/user/users', pathMatch: 'full'
  },
  {
    path: 'users',
    loadChildren: () => import('./pages/users/users.module').then(m => m.UsersModule),
    resolve: {'users': UsersResolver}
  },
  {
    path: 'admins',
    loadChildren: () => import('./pages/admins/admins.module').then(m => m.AdminsModule),
    resolve: {'admins': AdminsResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserManagerRoutingModule {
}
