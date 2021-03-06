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

    return this.authenticationService.currentUser.pipe(
      map((response) => {
        if (response) {
          return true;
        } else {
          this.navigate(state.url);
          return false;
        }
      }), catchError(_ => {
        this.navigate(state.url);
        return of(false);
      }));
  }

  private navigate(url: string) {
    this.router.navigate(['login'], {
      queryParams: {
        returnUrl: url
      }
    }).then();
  }
}
