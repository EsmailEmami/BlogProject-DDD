import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: '/category/categories', pathMatch: 'full'
  },
  {
    path: 'add',
    loadChildren: () => import('./pages/add-category/add-category.module').then(m => m.AddCategoryModule)
  },
  {
    path: 'update/:categoryId',
    loadChildren: () => import('./pages/update-category/update-category.module').then(m => m.UpdateCategoryModule)
  },
  {
    path: 'categories',
    loadChildren: () => import('./pages/categories/categories.module').then(m => m.CategoriesModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule {
}
