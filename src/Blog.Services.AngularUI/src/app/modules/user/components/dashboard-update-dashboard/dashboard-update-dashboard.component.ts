import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {UserService} from "../../services/user.service";
import {AuthService} from "../../../../core/services/auth.service";
import {UserDashboardRequest} from "../../../../core/models/requests/user/userDashboardRequest";

@Component({
  selector: 'app-dashboard-update-dashboard',
  templateUrl: './dashboard-update-dashboard.component.html',
})
export class DashboardUpdateDashboardComponent implements OnInit {

  public dashboardForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private userService: UserService,
              private authService: AuthService) {
  }

  ngOnInit(): void {

    this.userService.getUserDashboard().then((user) => {

      this.dashboardForm = this.formBuilder.group({
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
      });

    }, (error) => {
      this.activeModal.dismiss();
    });

  }

  get controls() {
    return this.dashboardForm.controls;
  }

  onSubmit() {
    if (this.dashboardForm.invalid) {
      return;
    }

    const userData = new UserDashboardRequest(
      this.controls['firstName'].value,
      this.controls['lastName'].value,
      this.controls['email'].value
    );

    this.userService.updateDashboard(userData).then(() => {
      this.dashboardForm.reset();

      this.authService.updateCurrentUser(userData);

      this.activeModal.close(userData);
    });

  }

  closeModal() {
    this.activeModal.close();
  }
}
