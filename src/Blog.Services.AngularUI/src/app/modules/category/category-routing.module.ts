import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: '/category/add-category', pathMatch: 'full'
  },
  {
    path: 'add-category',
    loadChildren: () => import('./pages/add-category/add-category.module').then(m => m.AddCategoryModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule {
}
