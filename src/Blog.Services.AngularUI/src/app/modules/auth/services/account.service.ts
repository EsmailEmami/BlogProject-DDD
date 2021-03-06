import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {RegisterUserRequest} from "../../../core/models/requests/user/registerUserRequest";

const CONTROLLER_NAME: string = 'account/';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public registerUser(request: RegisterUserRequest) {
    return this.post(CONTROLLER_NAME + 'register', request).toPromise();
  }

}
