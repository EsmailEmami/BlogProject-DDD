import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {ActivatedRoute, Data} from "@angular/router";
import {UserDashboardRequest} from "../../../../core/models/requests/user/userDashboardRequest";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {NotificationService} from "../../../../core/services/notification.service";
import {
  DashboardUpdateDashboardComponent
} from "../../components/dashboard-update-dashboard/dashboard-update-dashboard.component";
import {
  DashboardUpdatePasswordComponent
} from "../../components/dashboard-update-password/dashboard-update-password.component";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements OnInit {
  public dashboard!: UserDashboardRequest;

  constructor(
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      this.dashboard = data['dashboard'];
    });
  }

  editDashboard() {
    const modalRef = this.modalService.open(DashboardUpdateDashboardComponent);

    modalRef.result.then((user: UserDashboardRequest) => {
      if (user) {
        this.dashboard = user;
        this.notificationService.showSuccess('مشخصات شما با موفقیت ویرایش شد.');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }

  editPassword() {
    const modalRef = this.modalService.open(DashboardUpdatePasswordComponent);

    modalRef.result.then((data: string) => {
      if (data) {
        this.notificationService.showSuccess(data);
      }
    });
  }
}
