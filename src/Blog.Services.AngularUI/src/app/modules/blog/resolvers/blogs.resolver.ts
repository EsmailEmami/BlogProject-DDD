import {Injectable} from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import {BlogForShowRequest} from "../../../core/models/requests/blog/blogForShowRequest";
import {BlogService} from "../services/blog.service";

@Injectable({
  providedIn: 'root'
})
export class BlogsResolver implements Resolve<BlogForShowRequest[]> {

  constructor(
    private router: Router,
    private blogService: BlogService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<BlogForShowRequest[]> {
    return this.blogService.blogList();
  }
}
