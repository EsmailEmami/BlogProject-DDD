import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Data} from "@angular/router";
import {BlogForShowRequest} from "../../../../core/models/requests/blog/blogForShowRequest";

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html'
})
export class BlogListComponent implements OnInit {

  public blogs: BlogForShowRequest[] = [];

  constructor(
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      this.blogs = data['blogs'];
    });
  }
}
