import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Data} from "@angular/router";
import {BlogForShowRequest} from "../../../../core/models/requests/blog/blogForShowRequest";

@Component({
  selector: 'app-category-blogs',
  templateUrl: './category-blogs.component.html',
})
export class CategoryBlogsComponent implements OnInit {

  public blogs: BlogForShowRequest[] = [];

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      this.blogs = data['blogs'];
    });
  }

}
