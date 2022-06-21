import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CommentForShowRequest} from "../../../core/models/requests/comment/commentForShowRequest";
import {HubConnection, HubConnectionBuilder, IHttpConnectionOptions} from "@microsoft/signalr";
import {TokenStorageService} from "../../../core/token-storage.service";
import {environment} from "../../../../environments/environment";
import {AddCommentRequest} from "../../../core/models/requests/comment/addCommentRequest";

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
      .withUrl('https://localhost:44320/CommentHub', options)
      .build();
  }

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

  public addReceiveNewCommentListener(): void {
    this.hubConnection.on('ReceiveNewComment', (data: CommentForShowRequest) => {
      console.log(data);
    });
  }

  public setActiveRoom(blogId: string) {
    this.hubConnection.invoke('SetActiveBlogRoom', blogId).then(() => {
      this.addReceiveNewCommentListener();
    });
  }

  public blogComments(blogId: string): Promise<CommentForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(CONTROLLER_NAME + 'blog-comments', params).toPromise();
  }

  public addComment(comment: AddCommentRequest) {
    return this.post(CONTROLLER_NAME + 'add-comment', comment).toPromise();
  }
}
