import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UsersResolver} from "./resolvers/users.resolver";

const routes: Routes = [
  {
    path: '', redirectTo: '/user/users', pathMatch: 'full'
  },
  {
    path: 'users',
    loadChildren: () => import('./pages/users/users.module').then(m => m.UsersModule),
    resolve: {'users': UsersResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserManagerRoutingModule {
}
