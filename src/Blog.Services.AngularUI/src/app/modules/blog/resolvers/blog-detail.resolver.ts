import {Injectable} from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import {Observable, of} from 'rxjs';
import {BlogService} from "../services/blog.service";
import {BlogDetailRequest} from "../../../core/models/requests/blog/blogDetailRequest";

@Injectable({
  providedIn: 'root'
})
export class BlogDetailResolver implements Resolve<BlogDetailRequest | null> {

  constructor(private blogService: BlogService,
              private router: Router) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<BlogDetailRequest | null> {
    return this.blogService.blogDetail(route.params['blogId'])
      .then(data => data, error => {
        this.router.navigate(['404']);
        return null;
      });
  }
}
