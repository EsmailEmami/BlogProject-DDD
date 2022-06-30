import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {RoleForShowRequest} from "../../../core/models/requests/role/roleForShowRequest";
import {UpdateRoleRequest} from "../../../core/models/requests/role/updateRoleRequest";

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

  public getRoleForUpdate(roleId: string): Promise<UpdateRoleRequest> {
    const params = new HttpParams()
      .append('roleId', roleId);
    return this.get(CONTROLLER_NAME + 'get-role-for-update', params).toPromise();
  }

  public updateRole(role: UpdateRoleRequest): Promise<RoleForShowRequest> {
    return this.put(CONTROLLER_NAME + 'update-role', role).toPromise();
  }

  public addRole(roleName: string): Promise<RoleForShowRequest> {
    return this.post(CONTROLLER_NAME + 'add-role', JSON.stringify(roleName)).toPromise();
  }
}
