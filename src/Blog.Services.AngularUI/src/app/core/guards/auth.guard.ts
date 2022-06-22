import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {catchError, map, Observable, of} from 'rxjs';
import {AuthService} from "../services/auth.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private authenticationService: AuthService,
    private router: Router
  ) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    if (route.data['allowAnonymous'] != undefined && route.data['allowAnonymous'] == true) {
      return true;
    }


    return this.authenticationService.currentUser.pipe(map((response) => {
      if (response) {
        return true;
      }
      this.router.navigate(['login'], {
        queryParams: {
          returnUrl: state.url
        }
      });

      return false;

    }), catchError(_ => {

      this.router.navigate(['login'], {
        queryParams: {
          returnUrl: state.url
        }
      });

      return of(false);
    }));
  }
}
