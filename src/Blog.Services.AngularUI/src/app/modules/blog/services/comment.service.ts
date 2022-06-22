import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CommentForShowRequest} from "../../../core/models/requests/comment/commentForShowRequest";
import {HubConnection, HubConnectionBuilder, IHttpConnectionOptions} from "@microsoft/signalr";
import {TokenStorageService} from "../../../core/token-storage.service";
import {AddCommentRequest} from "../../../core/models/requests/comment/addCommentRequest";
import {BehaviorSubject, Observable} from "rxjs";

const CONTROLLER_NAME: string = 'comment/'

@Injectable({
  providedIn: 'root'
})
export class CommentService extends RestService {

  private hubConnection: HubConnection;

  // @ts-ignore
  private $newComment: BehaviorSubject<CommentForShowRequest> = new BehaviorSubject<CommentForShowRequest>(null);

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

  public receiveNewCommentListener(): Observable<CommentForShowRequest> {
    return this.$newComment
  }

  private addReceiveNewCommentListener(): void {
    this.hubConnection.on('ReceiveNewComment', (data: CommentForShowRequest) => {
      if (data != null) {
        this.$newComment.next(data);
      }
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
