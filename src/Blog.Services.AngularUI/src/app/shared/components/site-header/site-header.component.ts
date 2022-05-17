import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../../core/services/auth.service";
import {User} from "../../../core/models/User";

@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html'
})
export class SiteHeaderComponent implements OnInit {

  public user!: User;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => this.user = user);
  }

}
