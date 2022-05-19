import {Injectable} from '@angular/core';
import {RestService} from "./http/rest.service";
import {TokenStorageService} from "../token-storage.service";
import {HttpClient} from "@angular/common/http";
import {LocalStorageService} from "./local-storage.service";
import {Router} from "@angular/router";
import {BehaviorSubject, map, Observable, Subject} from "rxjs";
import {NotificationService} from "./notification.service";
import {appConstants} from "../constants/appConstants";
import {User} from "../models/User";

@Injectable({
  providedIn: 'root'
})
export class AuthService extends RestService {
  private isLogged = new Subject<boolean>();

  // @ts-ignore
  private currentUser$: BehaviorSubject<User> = new BehaviorSubject<User>(null);

  constructor(http: HttpClient,
              private tokenStorageToken: TokenStorageService,
              private localStorageService: LocalStorageService,
              private router: Router,
              private notificationService: NotificationService) {
    super(http);
  }

  setCurrentUser(): void {
    const storedUserData = this.localStorageService
      .getValueByKey(appConstants.storedUser);

    if (storedUserData) {
      const storedUser = JSON.parse(storedUserData);

      const expire: number = Date.parse(storedUser['expire'])

      if (!expire) {
        this.logout();

        // @ts-ignore
        this.currentUser$.next(null);
      } else {
        if (expire < Date.now()) {
          this.logout();

          // @ts-ignore
          this.currentUser$.next(null);
        }
      }

      this.currentUser$.next(storedUser as User);
    } else {
      // @ts-ignore
      this.currentUser$.next(null);
    }
  }

  public get currentUser(): Observable<User> {
    return this.currentUser$;
  }

  public get userId(): string | null {
    const storedUserData = this.localStorageService
      .getValueByKey(appConstants.storedUser);

    if (storedUserData) {
      const storedUser = JSON.parse(storedUserData);
      return storedUser.id as string;
    }
    return null;
  }

  login(email: string, password: string) {
    return this.post("account/login", {email, password})
      .pipe(map(data => {
        // login successful if there's a jwt token in the response
        if (data.token) {
          this.tokenStorageToken.saveToken(data.token);

          const user = new User(
            data.id,
            data.firstName,
            data.lastName,
            data.email
          );
          const date = new Date();

          let storedData: any = {
            id: data.id,
            firstName: data.firstName,
            lastName: data.lastName,
            email: data.email,
            expire: new Date(date.setDate(date.getDate() + 30)).toLocaleDateString()
          }

          // store user details and jwt token in local storage to keep user logged in between page refreshes
          this.localStorageService.setValue(appConstants.storedUser, JSON.stringify(storedData));

          this.currentUser$.next(user);

          this.isLogged.next(true);
        } else {
          data.forEach((error: string) => {
            this.notificationService.showError(error)
          })
        }

        return data;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem(appConstants.storedUser);
    this.tokenStorageToken.clearToken();

    // broadcasting to listeners
    this.isLogged.next(false);

    // @ts-ignore
    this.currentUser$.next(null);

    // redirects
    this.router.navigate(["/login"]);
  }
}
