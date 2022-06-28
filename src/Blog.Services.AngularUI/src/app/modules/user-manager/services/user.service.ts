import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {HubConnection, HubConnectionBuilder, IHttpConnectionOptions} from "@microsoft/signalr";
import {BehaviorSubject, Observable} from "rxjs";
import {UserForShowRequest} from "../../../core/models/requests/user/userForShowRequest";
import {TokenStorageService} from "../../../core/token-storage.service";
import {FilterUsersRequest} from "../../../core/models/requests/user/filterUsersRequest";

const CONTROLLER_NAME: string = 'userManager/'

@Injectable({
  providedIn: 'root'
})
export class UserService extends RestService {

  private hubConnection: HubConnection;

  // @ts-ignore
  private $newUser: BehaviorSubject<UserForShowRequest> = new BehaviorSubject<UserForShowRequest>(null);

  constructor(http: HttpClient,
              private token: TokenStorageService) {
    super(http);

    const options: IHttpConnectionOptions = {
      accessTokenFactory: () => {
        return token.getToken();
      }
    };

    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:44320/UserManagerHub', options)
      .build();
  }

  // ------------- SIGNALR -------------

  public startHub(): Promise<boolean> {
    return this.hubConnection
      .start()
      .then(() => {
        return true;
      })
      .catch(() => {
        return false;
      });
  }

  public addReceiveNewUserListener(): void {
    this.hubConnection.on('ReceiveRegisteredUser', (data: UserForShowRequest) => {
      if (data != null) {
        this.$newUser.next(data);
      }
    });
  }

  public receiveNewUserListener(): Observable<UserForShowRequest> {
    return this.$newUser;
  }

  // ------------- API -------------

  public getUsers(pageId: number, take: number, search?: string): Promise<FilterUsersRequest> {
    let params = new HttpParams()
      .append('pageId', pageId)
      .append('take', take)

    if (search) {
      params = params.append('search', search);
    }

    return this.get(CONTROLLER_NAME + 'users', params).toPromise();
  }

  public getAdmins(pageId: number, take: number, search?: string): Promise<FilterUsersRequest> {
    let params = new HttpParams()
      .append('pageId', pageId)
      .append('take', take)

    if (search) {
      params = params.append('search', search);
    }

    return this.get(CONTROLLER_NAME + 'admins', params).toPromise();
  }
}
