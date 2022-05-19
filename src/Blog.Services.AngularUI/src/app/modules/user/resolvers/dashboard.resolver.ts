import {Injectable} from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import {UserService} from "../services/user.service";
import {UserDashboardRequest} from "../../../core/models/requests/user/userDashboardRequest";
import {delay} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DashboardResolver implements Resolve<UserDashboardRequest | null> {

  constructor(
    private router: Router,
    private userService: UserService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<UserDashboardRequest | null> {

    return this.userService.getUserDashboard()
      .then((data: UserDashboardRequest) => {
        return data;
      }, error => {
        this.router.navigate(['login']);
        return null;
      });
  }
}
