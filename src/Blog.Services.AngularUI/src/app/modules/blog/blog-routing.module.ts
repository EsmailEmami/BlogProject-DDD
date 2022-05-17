import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: '/blog/add', pathMatch: 'full'
  },
  {
    path: 'add',
    loadChildren: () => import('./pages/add-blog/add-blog.module').then(m => m.AddBlogModule)
  },
  {
    path: 'update/:blogId',
    loadChildren: () => import('./pages/update-blog/update-blog.module').then(m => m.UpdateBlogModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BlogRoutingModule {
}
