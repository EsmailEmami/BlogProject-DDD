import {Injectable} from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import {FilterUsersRequest} from "../../../core/models/requests/user/filterUsersRequest";
import {UserService} from "../services/user.service";

@Injectable({
  providedIn: 'root'
})
export class AdminsResolver implements Resolve<FilterUsersRequest> {

  constructor(private userService: UserService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<FilterUsersRequest> {

    let pageId: number = 1;
    if (route.queryParams['pageId'] != null) {
      pageId = parseInt(route.queryParams['pageId'], 0);
    }

    const search: string | null = route.queryParams['search'];

    return this.userService.getAdmins(pageId, 5, search!);
  }
}

