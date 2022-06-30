import {Component, OnInit} from '@angular/core';
import {RoleForShowRequest} from "../../../../core/models/requests/role/roleForShowRequest";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {NotificationService} from "../../../../core/services/notification.service";
import {UpdateRoleComponent} from "../../components/update-role/update-role.component";
import {AddRoleComponent} from "../../components/add-role/add-role.component";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
})
export class RolesComponent implements OnInit {

  public roles: RoleForShowRequest[] = [];

  constructor(private modalService: NgbModal,
              private notificationService: NotificationService,
              private route: ActivatedRoute,) {
  }

  ngOnInit(): void {

    this.route.data.subscribe(data => {
      this.roles = data['roles'];
    });
  }

  addRole() {
    const modalRef = this.modalService.open(AddRoleComponent);

    modalRef.result.then((role: RoleForShowRequest) => {
      if (role) {
        this.roles.unshift(role);
        this.notificationService.showSuccess('مقام با موفقیت اضافه شد.');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }

  editRole(roleId: string) {
    const modalRef = this.modalService.open(UpdateRoleComponent);
    modalRef.componentInstance.roleId = roleId;

    modalRef.result.then((role: RoleForShowRequest) => {
      if (role) {
        const existedRole: RoleForShowRequest | undefined = this.roles.find(x => x.id == role.id);
        if (existedRole != undefined) {
          this.roles[this.roles.indexOf(existedRole)] = role;
        }

        this.notificationService.showSuccess('مقام با موفقیت ویرایش شد.');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }
}
