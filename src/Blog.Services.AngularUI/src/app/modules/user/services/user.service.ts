import { Injectable } from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {UserDashboardRequest} from "../../../core/models/requests/user/userDashboardRequest";

const CONTROLLER_NAME: string = 'user/';

@Injectable({
  providedIn: 'root'
})
export class UserService extends RestService{

  constructor(http: HttpClient) {
    super(http);
  }

  getUserDashboard():Promise<UserDashboardRequest>{
    return this.get(CONTROLLER_NAME + 'dashboard').toPromise();
  }
}
