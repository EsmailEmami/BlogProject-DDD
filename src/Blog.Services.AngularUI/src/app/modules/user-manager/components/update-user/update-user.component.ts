import {AfterViewChecked, Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {UserDashboardRequest} from "../../../../core/models/requests/user/userDashboardRequest";
import {UpdateUserRequest} from "../../../../core/models/requests/user/updateUserRequest";
import {AuthService} from "../../../../core/services/auth.service";
import {RoleService} from "../../services/role.service";
import {RoleForShowRequest} from "../../../../core/models/requests/role/roleForShowRequest";
import {UserForShowRequest} from "../../../../core/models/requests/user/userForShowRequest";

declare function multiSelectDropdown(): any;

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
})
export class UpdateUserComponent implements OnInit, AfterViewChecked {

  @Input() private userId!: string;

  public userForm!: FormGroup;
  public roles: RoleForShowRequest[] = [];
  private hadRole: boolean = false;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private authService: AuthService,
              private roleService: RoleService) {
  }

  ngOnInit(): void {
    this.userService.startHub().then();

    if (!this.userId) {
      this.activeModal.dismiss('کاربر یافت نشد');
    }

    this.userService.getUserForUpdate(this.userId).then((user) => {

      if (user.roles.length > 0) {
        this.hadRole = true;
      }

      this.userForm = this.formBuilder.group({
        firstName: [user.firstName,
          Validators.compose([
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50)
          ])
        ],
        lastName: [user.lastName,
          Validators.compose([
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(50)
          ])
        ],
        email: [user.email,
          Validators.compose([
            Validators.required,
            Validators.maxLength(100),
            Validators.email
          ])
        ],
        roles: [user.roles]
      });

    }, (error) => {
      this.activeModal.dismiss();
    });

    this.roleService.getRoles().then((roles) => {
      this.roles = roles;
    })

  }

  ngAfterViewChecked(): void {
    multiSelectDropdown();
  }

  get controls() {
    return this.userForm.controls;
  }

  onSubmit() {
    if (this.userForm.invalid) {
      return;
    }

    const userData = new UpdateUserRequest(
      this.userId,
      this.controls['firstName'].value,
      this.controls['lastName'].value,
      this.controls['email'].value,
      this.controls['roles'].value,
    );

    this.userService.updateUser(userData).then(() => {
      this.userForm.reset();

      if (this.authService.userId == userData.id) {
        this.authService.updateCurrentUser(new UserDashboardRequest(userData.firstName, userData.lastName, userData.email));
      }

      const userForShow = new UserForShowRequest(userData.id, userData.fullName(), userData.email);

      if (this.hadRole && userData.roles.length <= 0) {
        this.userService.invokeRemoveUserFromAdmin(userData.id, userData.fullName());
      }

      if(!this.hadRole && userData.roles.length > 0){
        this.userService.invokeAddNewAdmin(userForShow);
      }

      this.activeModal.close(userForShow);
    });

  }

  closeModal() {
    this.activeModal.close();
  }
}
