import {NgModule, Optional, SkipSelf} from '@angular/core';
import {HttpClientModule} from "@angular/common/http";
import {ToastrModule} from "ngx-toastr";
import {AuthService} from "./services/auth.service";
import {NotificationService} from "./services/notification.service";
import {LocalStorageService} from "./services/local-storage.service";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
  imports: [
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({
      progressBar: true,
      progressAnimation: 'increasing',
      extendedTimeOut: 3000
    })
  ],
  providers: [
    AuthService,
    BrowserAnimationsModule,
    ToastrModule,
    NotificationService,
    LocalStorageService,
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() core: CoreModule) {
    if (core) {
      throw new Error('You should import core module only in the root module');
    }
  }
}
