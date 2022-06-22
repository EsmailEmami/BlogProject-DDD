import {Component, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../services/user.service";
import {UserDashboardRequest} from "../../../../core/models/requests/user/userDashboardRequest";
import {AuthService} from "../../../../core/services/auth.service";

@Component({
  selector: 'app-dashboard-update-password',
  templateUrl: './dashboard-update-password.component.html',
})
export class DashboardUpdatePasswordComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }

}
