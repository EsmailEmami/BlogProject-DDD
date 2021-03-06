import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../../../core/services/auth.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {NotificationService} from "../../../../core/services/notification.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  public loginForm!: FormGroup;
  public loading = false;
  private returnUrl!: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthService,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['',
        Validators.compose([
          Validators.required,
          Validators.maxLength(100),
          Validators.email
        ])
      ],
      password: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(50)
        ])
      ]
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get controls() {
    return this.loginForm.controls;
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.controls['email'].value, this.controls['password'].value)
      .subscribe(data => {
        this.notificationService.showSuccess('ورود موفقیت آمیز بود')
        this.router.navigate([this.returnUrl]).then(_ => this.loginForm.reset());
      });

    this.loading = false;
  }
}
