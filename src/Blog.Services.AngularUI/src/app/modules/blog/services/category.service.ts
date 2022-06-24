import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {CategoryForShowRequest} from "../../../core/models/requests/category/categoryForShowRequest";

const CONTROLLER_NAME: string = 'category/';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getCategories(): Promise<CategoryForShowRequest[]> {
    return this.get(CONTROLLER_NAME + 'categories').toPromise();
  }

  public getBlogCategories(blogId: string): Promise<CategoryForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(CONTROLLER_NAME + 'blog-categories', params).toPromise();
  }
}
