import {Component, OnInit} from '@angular/core';
import {FilterUsersRequest} from "../../../../core/models/requests/user/filterUsersRequest";
import {UserService} from "../../services/user.service";
import {ActivatedRoute, Router} from "@angular/router";
import {NotificationService} from "../../../../core/services/notification.service";
import {UrlGenerator} from "../../../../core/generators/urlGenerator";

@Component({
  selector: 'app-admins',
  templateUrl: './admins.component.html',
})
export class AdminsComponent implements OnInit {

  public admins!: FilterUsersRequest;
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
      this.admins = data['admins'];
      this.pages = [];
      for (let i = this.admins.startPage; i <= this.admins.endPage; i++) {
        this.pages.push(i);
      }
    });

    this.userService.receiveNewUserListener().subscribe((user) => {
      if (user != null) {
        this.admins.users.unshift(user);
        this.notificationService.showSuccess('کاربر جدیدی ثبت نام کرد');
      }
    });
  }

  getAdmins(pageId?: number) {
    if (pageId != null) {
      this.admins.pageId = pageId;
    }

    this.router.navigate([UrlGenerator.getCurrentUrlWithoutParams(this.router)], {
      queryParams: {
        pageId: this.admins.pageId,
        search: this.admins.search
      }
    }).then(() => {
      this.userService.getAdmins(this.admins.pageId, this.admins.takeEntity, this.admins.search).then((admins) => {
        this.admins = admins;
        this.pages = [];
        for (let i = admins.startPage; i <= admins.endPage; i++) {
          this.pages.push(i);
        }
      })
    });
  }
}
