import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {AddBlogRequest} from "../../../core/models/requests/blog/addBlogRequest";
import {UpdateBlogRequest} from "../../../core/models/requests/blog/updateBlogRequest";

const CONTROLLER_NAME: string = 'blog/';

@Injectable({
  providedIn: 'root'
})

export class BlogService extends RestService {
  constructor(http: HttpClient) {
    super(http);
  }

  public addBlog(request: AddBlogRequest) {
    return this.post(CONTROLLER_NAME + 'AddBlog', request).toPromise();
  }

  public getBlogForUpdate(blogId: string) {
    const params = new HttpParams()
      .append('blogId', blogId);

    return this.get(CONTROLLER_NAME + 'get-blog-for-update', params).toPromise();
  }

  public updateBlog(request: UpdateBlogRequest) {
    return this.post(CONTROLLER_NAME + 'update-blog', request).toPromise();
  }

}
