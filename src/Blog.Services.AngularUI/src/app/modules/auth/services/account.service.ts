import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {RegisterUserRequest} from "../../../core/models/requests/user/RegisterUserRequest";

@Injectable({
  providedIn: 'root'
})
export class AccountService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public registerUser(request: RegisterUserRequest) {
    return this.post('account/register', request).toPromise();
  }

}
