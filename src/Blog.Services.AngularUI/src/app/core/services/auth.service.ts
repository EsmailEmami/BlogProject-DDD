import {Injectable} from '@angular/core';
import {RestService} from "./http/rest.service";
import {TokenStorageService} from "../token-storage.service";
import {HttpClient} from "@angular/common/http";
import {LocalStorageService} from "./local-storage.service";
import {Router} from "@angular/router";
import {map, Subject} from "rxjs";
import {NotificationService} from "./notification.service";
import {appConstants} from "../constants/appConstants";
import {User} from "../models/User";

@Injectable({
  providedIn: 'root'
})
export class AuthService extends RestService {
  private isLogged = new Subject<boolean>();

  // Observable string streams
  isLoggedAnnounced$ = this.isLogged.asObservable();

  constructor(http: HttpClient,
              private tokenStorageToken: TokenStorageService,
              private localStorageService: LocalStorageService,
              private router: Router,
              private notificationService: NotificationService) {
    super(http);
  }

  public get currentUser(): User | null {
    const storedCustomerData = this.localStorageService
      .getValueByKey(appConstants.storedUser);

    if (storedCustomerData) {
      const storedCustomer = JSON.parse(storedCustomerData);
      return storedCustomer as User;
    }

    return null;
  }

  login(email: string, password: string) {
    return this.post("account/login", {email, password})
      .pipe(map(result => {
        const data = result.data;

        // login successful if there's a jwt token in the response
        if (data.token) {
          this.tokenStorageToken.saveToken(data.token);

          // store user details and jwt token in local storage to keep user logged in between page refreshes
          this.localStorageService.setValue(appConstants.storedUser, JSON.stringify(data));
          this.isLogged.next(true);
        } else {
          for (const error of data.errors) {
            this.notificationService.showError(error);
          }
        }

        return result;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem(appConstants.storedUser);
    this.tokenStorageToken.clearToken();

    // broadcasting to listeners
    this.isLogged.next(false);

    // redirects
    this.router.navigate(["/login"]);
  }
}
