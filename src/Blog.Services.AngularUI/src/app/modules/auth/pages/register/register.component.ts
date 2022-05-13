import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {AccountService} from "../../services/account.service";
import {NotificationService} from "../../../../core/services/notification.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {RegisterUserRequest} from "../../../../core/models/requests/user/RegisterUserRequest";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  public registerForm!: FormGroup;
  public loading = false;
  private returnUrl!: '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: [
        '',
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)
      ],
      lastName: [
        '',
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)
      ],
      email: ['',
        Validators.required,
        Validators.maxLength(100),
        Validators.email
      ],
      password: ['',
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(50)
      ],
      confirmPassword: ['',
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(50)
      ],
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get controls() {
    return this.registerForm.controls;
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    const register = new RegisterUserRequest(
      this.controls['firstName'].value,
      this.controls['lastName'].value,
      this.controls['email'].value,
      this.controls['password'].value,
      this.controls['confirmPassword'].value,
    );

    this.accountService.registerUser(register)
      .then(_ => {
        this.notificationService.showSuccess("ثبت نام با موفقیت انجام شد.");
        this.router.navigate([this.returnUrl]).then();
      });

    this.loading = false;
  }

}
