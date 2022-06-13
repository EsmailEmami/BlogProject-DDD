import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {BlogsResolver} from "./resolvers/blogs.resolver";
import {BlogDetailResolver} from "./resolvers/blog-detail.resolver";

const routes: Routes = [
  {
    path: 'detail/:blogId',
    loadChildren: () => import('./pages/blog-detail/blog-detail.module').then(m => m.BlogDetailModule),
    resolve: {'blog': BlogDetailResolver}
  },
  {
    path: 'add',
    loadChildren: () => import('./pages/add-blog/add-blog.module').then(m => m.AddBlogModule)
  },
  {
    path: 'update/:blogId',
    loadChildren: () => import('./pages/update-blog/update-blog.module').then(m => m.UpdateBlogModule)
  },
  {
    path: 'blogs',
    loadChildren: () => import('./pages/blog-list/blog-list.module').then(m => m.BlogListModule),
    resolve: {'blogs': BlogsResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BlogRoutingModule {
}
