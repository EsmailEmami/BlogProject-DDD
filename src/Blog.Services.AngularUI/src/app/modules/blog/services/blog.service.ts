import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {AddBlogRequest} from "../../../core/models/requests/blog/addBlogRequest";
import {IFailedResponseResult, ISuccessResponseResult} from "../../../core/common/IResponseResult";

@Injectable({
  providedIn: 'root'
})

export class BlogService extends RestService {
  constructor(http: HttpClient) {
    super(http);
  }

  public addBlog(request: AddBlogRequest) {
    return this.post('blog/AddBlog', request).toPromise();
  }
}
