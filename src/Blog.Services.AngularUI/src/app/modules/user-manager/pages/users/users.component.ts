import {Component, OnInit} from '@angular/core';
import {UserService} from "../../services/user.service";
import {ActivatedRoute, Router} from "@angular/router";
import {FilterUsersRequest} from "../../../../core/models/requests/user/filterUsersRequest";
import {UrlGenerator} from "../../../../core/generators/urlGenerator";
import {NotificationService} from "../../../../core/services/notification.service";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styles: []
})
export class UsersComponent implements OnInit {

  public users!: FilterUsersRequest;
  public pages: number[] = [];

  constructor(private userService: UserService,
              private route: ActivatedRoute,
              private router: Router,
              private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.userService.startHub().then(() => {
      this.userService.addReceiveNewUserListener();
    });

    this.route.data.subscribe(data => {
      this.users = data['users'];
      this.pages = [];
      for (let i = this.users.startPage; i <= this.users.endPage; i++) {
        this.pages.push(i);
      }
    });

    this.userService.receiveNewUserListener().subscribe((user) => {
      if (user != null) {
        this.users.users.unshift(user);
        this.notificationService.showSuccess('کاربر جدیدی ثبت نام کرد');
      }
    });
  }

  getUsers(pageId?: number) {
    if (pageId != null) {
      this.users.pageId = pageId;
    }

    this.router.navigate([UrlGenerator.getCurrentUrlWithoutParams(this.router)], {
      queryParams: {
        pageId: this.users.pageId,
        search: this.users.search
      }
    }).then(() => {
      this.userService.getUsers(this.users.pageId, this.users.takeEntity, this.users.search).then((users) => {
        this.users = users;
        this.pages = [];
        for (let i = users.startPage; i <= users.endPage; i++) {
          this.pages.push(i);
        }
      })
    });
  }
}
