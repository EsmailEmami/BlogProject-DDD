import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: '/tag/tags', pathMatch: 'full'
  },
  {
    path :'tags',
    loadChildren : () => import('./pages/tags/tags.module').then(m=> m.TagsModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TagRoutingModule { }
