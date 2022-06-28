import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {HubConnection, HubConnectionBuilder, IHttpConnectionOptions} from "@microsoft/signalr";
import {BehaviorSubject, Observable} from "rxjs";
import {UserForShowRequest} from "../../../core/models/requests/user/userForShowRequest";
import {TokenStorageService} from "../../../core/token-storage.service";
import {FilterUsersRequest} from "../../../core/models/requests/user/filterUsersRequest";
import {UpdateUserRequest} from "../../../core/models/requests/user/updateUserRequest";
import {UserRemovedRequest} from "../../../core/signalR/user/userRemovedRequest";

const CONTROLLER_NAME: string = 'userManager/'

@Injectable({
  providedIn: 'root'
})
export class UserService extends RestService {

  private hubConnection: HubConnection;

  // @ts-ignore
  private $newUser: BehaviorSubject<UserForShowRequest> = new BehaviorSubject<UserForShowRequest>(null);
  // @ts-ignore
  private $newAdmin: BehaviorSubject<UserForShowRequest> = new BehaviorSubject<UserForShowRequest>(null);
  // @ts-ignore
  private $removedAdmin: BehaviorSubject<UserRemovedRequest> = new BehaviorSubject<UserForShowRequest>(null);

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

  public receiveNewUser(): Observable<UserForShowRequest> {
    return this.$newUser;
  }

  public addReceiveNewAdminListener(): void {
    this.hubConnection.on("ReceiveNewAdmin", (user: UserForShowRequest) => {
      this.$newAdmin.next(user);
    });
  }

  public receiveNewAdmin(): Observable<UserForShowRequest> {
    return this.$newAdmin;
  }

  public addRemoveUserFromAdminListener(): void {
    this.hubConnection.on("ReceiveRemovedUserFromAdmin", (userId: string, fullName: string) => {
      const data = new UserRemovedRequest(userId, fullName);
      this.$removedAdmin.next(data);
    });
  }

  public receiveRemovedAdmin(): Observable<UserRemovedRequest> {
    return this.$removedAdmin;
  }


  public invokeAddNewAdmin(user: UserForShowRequest): void {
    this.hubConnection.invoke("AddNewAdmin", user).then();
  }

  public invokeRemoveUserFromAdmin(userId: string, fullName: string): void {
    this.hubConnection.invoke("RemoveUserFromAdmin", userId, fullName).then();
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

  public getUserForUpdate(userId: string): Promise<UpdateUserRequest> {
    let params = new HttpParams()
      .append('userId', userId);
    return this.get(CONTROLLER_NAME + 'get-user-for-update', params).toPromise();
  }

  public updateUser(user: UpdateUserRequest): Promise<void> {
    return this.put(CONTROLLER_NAME + 'update-user', user).toPromise();
  }
}
