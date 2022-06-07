import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {SharedModule} from "./shared/shared.module";
import {CoreModule} from "./core/core.module";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {AuthInterceptor} from "./core/interceptor/auth.interceptor";
import {ServerErrorInterceptor} from "./core/interceptor/error.interceptor";
import {AppRoutingModule} from "./app-routing.module";
import { BlogListComponent } from './src/app/modules/blog/pages/blog-list/blog-list.component';
import { ClsComponent } from './cls/cls.component';

@NgModule({
  declarations: [
    AppComponent,
    BlogListComponent,
    ClsComponent
  ],
  imports: [
    SharedModule,
    CoreModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ServerErrorInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
