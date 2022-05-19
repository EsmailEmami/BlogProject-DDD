import {AfterContentInit, Component, OnInit} from '@angular/core';
import {AuthService} from "./core/services/auth.service";

declare function stopLoading(): any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterContentInit {
  title = 'صفحه اصلی';

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.authService.setCurrentUser();
  }

  ngAfterContentInit(): void {
    stopLoading();
  }
}
