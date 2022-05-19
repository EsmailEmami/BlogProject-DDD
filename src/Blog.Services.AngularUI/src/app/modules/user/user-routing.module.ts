import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DashboardResolver} from "./resolvers/dashboard.resolver";

const routes: Routes = [
  {
    path: '', redirectTo: 'account/dashboard', pathMatch: 'full'
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardModule),
    resolve: {'dashboard': DashboardResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule {
}
