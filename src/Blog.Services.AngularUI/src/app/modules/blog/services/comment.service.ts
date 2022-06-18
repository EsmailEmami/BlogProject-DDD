import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CommentForShowRequest} from "../../../core/models/requests/comment/commentForShowRequest";
import {HubConnection, HubConnectionBuilder, IHttpConnectionOptions} from "@microsoft/signalr";
import {TokenStorageService} from "../../../core/token-storage.service";
import {environment} from "../../../../environments/environment";

const CONTROLLER_NAME: string = 'comment/'

@Injectable({
  providedIn: 'root'
})
export class CommentService extends RestService {

  private hubConnection: HubConnection;

  constructor(http: HttpClient,
              private token: TokenStorageService) {
    super(http);

    const options: IHttpConnectionOptions = {
      accessTokenFactory: () => {
        return token.getToken();
      }
    };

    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.apiUrl + 'CommentHub', options)
      .build();
  }

  public startHub(): void {
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public AddReceiveNewCommentListener(): void {
    this.hubConnection.on('ReceiveNewComment', (data: CommentForShowRequest) => {
      console.log(data)
    });
  }

  public blogComments(blogId: string): Promise<CommentForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(CONTROLLER_NAME + 'blog-comments', params).toPromise();
  }
}
