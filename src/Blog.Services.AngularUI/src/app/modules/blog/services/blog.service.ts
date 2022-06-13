import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {AddBlogRequest} from "../../../core/models/requests/blog/addBlogRequest";
import {UpdateBlogRequest} from "../../../core/models/requests/blog/updateBlogRequest";
import {TagForShowRequest} from "../../../core/models/requests/tag/tagForShowRequest";
import {CategoryForShowRequest} from "../../../core/models/requests/category/categoryForShowRequest";
import {BlogDetailRequest} from "../../../core/models/requests/blog/blogDetailRequest";

const BLOG_CONTROLLER_NAME: string = 'blog/';
const TAG_CONTROLLER_NAME: string = 'tag/';
const Category_CONTROLLER_NAME: string = 'category/';

@Injectable({
  providedIn: 'root'
})

export class BlogService extends RestService {
  constructor(http: HttpClient) {
    super(http);
  }

  public addBlog(request: AddBlogRequest) {
    return this.post(BLOG_CONTROLLER_NAME + 'add-blog', request).toPromise();
  }

  public getBlogForUpdate(blogId: string) {
    const params = new HttpParams()
      .append('blogId', blogId);

    return this.get(BLOG_CONTROLLER_NAME + 'get-blog-for-update', params).toPromise();
  }

  public updateBlog(request: UpdateBlogRequest) {
    return this.post(BLOG_CONTROLLER_NAME + 'update-blog', request).toPromise();
  }

  public blogList() {
    return this.get(BLOG_CONTROLLER_NAME + 'blogs').toPromise();
  }

  public blogTags(blogId: string): Promise<TagForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(TAG_CONTROLLER_NAME + 'blog-tags', params).toPromise();
  }

  public blogCategories(blogId: string): Promise<CategoryForShowRequest[]> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(Category_CONTROLLER_NAME + 'blog-categories', params).toPromise();
  }

  public blogDetail(blogId: string): Promise<BlogDetailRequest> {
    const params = new HttpParams()
      .append('blogId', blogId);
    return this.get(BLOG_CONTROLLER_NAME + 'detail', params).toPromise();
  }
}
