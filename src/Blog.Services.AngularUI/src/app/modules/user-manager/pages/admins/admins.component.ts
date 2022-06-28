import {Component, OnInit} from '@angular/core';
import {FilterUsersRequest} from "../../../../core/models/requests/user/filterUsersRequest";
import {UserService} from "../../services/user.service";
import {ActivatedRoute, Router} from "@angular/router";
import {NotificationService} from "../../../../core/services/notification.service";
import {UrlGenerator} from "../../../../core/generators/urlGenerator";
import {UpdateUserComponent} from "../../components/update-user/update-user.component";
import {UserForShowRequest} from "../../../../core/models/requests/user/userForShowRequest";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {UpdateUserRequest} from "../../../../core/models/requests/user/updateUserRequest";

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
              private notificationService: NotificationService,
              private modalService: NgbModal) {
  }

  ngOnInit(): void {
    this.userService.startHub().then(() => {
      this.userService.addReceiveNewAdminListener();
      this.userService.addRemoveUserFromAdminListener();
    });

    this.route.data.subscribe(data => {
      this.admins = data['admins'];
      this.pages = [];
      for (let i = this.admins.startPage; i <= this.admins.endPage; i++) {
        this.pages.push(i);
      }
    });

    this.userService.receiveNewAdmin().subscribe(user => {
      if (user != null) {
        if (!this.admins.users.find(x => x.userId == user.userId)) {
          this.admins.users.unshift(user);
          this.notificationService.showSuccess('کاربر ' + user.fullName + ' به ادمین ها اضافه شد');
        }
      }
    });

    this.userService.receiveRemovedAdmin().subscribe((data) => {
      if (data) {
        const existedUser: UserForShowRequest | undefined = this.admins.users.find(x => x.userId == data.userId);
        if (existedUser) {
          this.admins.users.splice(this.admins.users.indexOf(existedUser), 1);
        }

        this.notificationService.showError('کاربر ' + data.fullName + ' از ادمین ها خارج شد');
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

  editAdmin(userId: string) {
    const modalRef = this.modalService.open(UpdateUserComponent);
    modalRef.componentInstance.userId = userId;

    modalRef.result.then((user: UserForShowRequest) => {
        if (user) {
          const lastUser: UserForShowRequest | undefined = this.admins.users.find(x => x.userId == user.userId);

          if (lastUser != undefined) {
            this.admins.users[this.admins.users.indexOf(lastUser)] = user;
          }
        }
      }
    ).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }
}
