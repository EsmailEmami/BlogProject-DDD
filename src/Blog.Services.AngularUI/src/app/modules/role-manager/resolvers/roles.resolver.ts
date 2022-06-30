import {Injectable} from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import {Observable, of} from 'rxjs';
import {RoleForShowRequest} from "../../../core/models/requests/role/roleForShowRequest";
import {RoleService} from "../services/role.service";

@Injectable({
  providedIn: 'root'
})
export class RolesResolver implements Resolve<RoleForShowRequest[]> {

  constructor(private roleService: RoleService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<RoleForShowRequest[]> {
    return this.roleService.getRoles();
  }
}
