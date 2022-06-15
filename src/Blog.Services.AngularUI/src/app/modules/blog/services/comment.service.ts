import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CommentForShowRequest} from "../../../core/models/requests/comment/commentForShowRequest";

const CONTROLLER_NAME: string = 'comment/'

@Injectable({
  providedIn: 'root'
})
export class CommentService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public blogComments(blogId: string): Promise<CommentForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(CONTROLLER_NAME + 'blog-comments', params).toPromise();
  }
}
