import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {RoleService} from "../../services/role.service";
import {UpdateRoleRequest} from "../../../../core/models/requests/role/updateRoleRequest";
import {RoleForShowRequest} from "../../../../core/models/requests/role/roleForShowRequest";

@Component({
  selector: 'app-update-role',
  templateUrl: './update-role.component.html',
})
export class UpdateRoleComponent implements OnInit {

  @Input() private roleId!: string;
  public roleForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private roleService: RoleService) {
  }

  ngOnInit(): void {
    if (this.roleId == null) {
      this.activeModal.dismiss('متاسفانه مشکلی پیش آمده است! لطفا دوباره تلاش کنید.');
    }

    this.roleService.getRoleForUpdate(this.roleId)
      .then((data: UpdateRoleRequest) => {
        this.roleForm = this.formBuilder.group({
          roleName: [data.roleName,
            Validators.compose([
              Validators.required,
              Validators.minLength(3),
              Validators.maxLength(20)
            ])
          ],
        });
      }, () => {
        this.activeModal.dismiss();
      });
  }

  get controls() {
    return this.roleForm.controls;
  }

  onSubmit() {
    if (this.roleForm.invalid) {
      return;
    }

    const request = new UpdateRoleRequest(
      this.roleId,
      this.controls['roleName'].value
    );

    this.roleService.updateRole(request)
      .then(() => {
        const roleForShow = new RoleForShowRequest(request.roleId, request.roleName);
        this.activeModal.close(roleForShow);
        this.roleForm.reset();
      });
  }

  closeModal() {
    this.activeModal.close();
  }

}
