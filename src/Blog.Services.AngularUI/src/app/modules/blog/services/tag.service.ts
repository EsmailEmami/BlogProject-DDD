import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CategoryForShowRequest} from "../../../core/models/requests/category/categoryForShowRequest";
import {TagForShowRequest} from "../../../core/models/requests/tag/tagForShowRequest";

const CONTROLLER_NAME: string = 'tag/';

@Injectable({
  providedIn: 'root'
})
export class TagService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getTags(): Promise<TagForShowRequest[]> {
    return this.get(CONTROLLER_NAME + 'tags').toPromise();
  }

  public getBlogTags(blogId: string): Promise<TagForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(CONTROLLER_NAME + 'blog-tags', params).toPromise();
  }
}
