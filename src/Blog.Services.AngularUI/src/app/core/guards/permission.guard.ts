import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {catchError, map, Observable, of} from 'rxjs';
import {AuthService} from "../services/auth.service";

@Injectable({
  providedIn: 'root'
})
export class PermissionGuard implements CanActivate {
  constructor(
    private authenticationService: AuthService,
    private router: Router
  ) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    let roles: string[] = route.data['roles'];

    return this.authenticationService.checkPermission(roles).pipe(
      map((response) => {
        if (response) {
          return true;
        } else {
          this.navigate();
          return false;
        }
      }), catchError(_ => {
        this.navigate();
        return of(false);
      }));
  }

  private navigate() {
    this.router.navigate(['404']).then();
  }
}
