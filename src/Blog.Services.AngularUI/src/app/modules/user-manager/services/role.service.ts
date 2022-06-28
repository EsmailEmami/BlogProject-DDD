import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {RoleForShowRequest} from "../../../core/models/requests/role/roleForShowRequest";

const CONTROLLER_NAME: string = 'role/'

@Injectable({
  providedIn: 'root'
})
export class RoleService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getRoles(): Promise<RoleForShowRequest[]> {
    return this.get(CONTROLLER_NAME + 'roles').toPromise();
  }
}
