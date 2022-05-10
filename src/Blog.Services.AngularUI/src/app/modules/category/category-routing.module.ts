import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: '/category/add', pathMatch: 'full'
  },
  {
    path: 'add',
    loadChildren: () => import('./pages/add-category/add-category.module').then(m => m.AddCategoryModule)
  },
  {
    path: 'update',
    loadChildren: () => import('./pages/update-category/update-category.module').then(m => m.UpdateCategoryModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule {
}
