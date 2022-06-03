import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BlogsResolver} from "./resolvers/blogs.resolver";

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/blog-list/blog-list.module').then(m => m.BlogListModule),
    resolve: {'blogs': BlogsResolver}
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
