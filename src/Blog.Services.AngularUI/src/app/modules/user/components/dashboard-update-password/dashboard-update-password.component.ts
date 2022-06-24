import {Component, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {AuthService} from "../../../../core/services/auth.service";
import {UpdateUserPasswordRequest} from "../../../../core/models/requests/user/updateUserPasswordRequest";

@Component({
  selector: 'app-dashboard-update-password',
  templateUrl: './dashboard-update-password.component.html',
})
export class DashboardUpdatePasswordComponent implements OnInit {

  public passwordForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private authService: AuthService) {
  }

  ngOnInit(): void {

    this.passwordForm = this.formBuilder.group({
      currentPassword: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50)
        ])
      ],
      newPassword: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50)
        ])
      ],
      confirmNewPassword: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50)
        ])
      ],
    });
  }

  get controls() {
    return this.passwordForm.controls;
  }

  onSubmit() {
    if (this.passwordForm.invalid) {
      return;
    }

    const password = new UpdateUserPasswordRequest(
      this.authService.userId as string,
      this.controls['currentPassword'].value,
      this.controls['newPassword'].value,
      this.controls['confirmNewPassword'].value
    );

    this.userService.updatePassword(password).then(() => {
      this.passwordForm.reset();

      this.activeModal.close('رمز عبور شما با موفقیت تغییر کرد');
    });

  }

  closeModal() {
    this.activeModal.close();
  }
}
