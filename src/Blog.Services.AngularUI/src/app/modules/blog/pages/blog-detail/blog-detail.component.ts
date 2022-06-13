import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Data} from "@angular/router";
import {BlogDetailRequest} from "../../../../core/models/requests/blog/blogDetailRequest";

@Component({
  selector: 'app-blog-detail',
  templateUrl: './blog-detail.component.html',
})
export class BlogDetailComponent implements OnInit {

  public blog!: BlogDetailRequest;

  constructor(private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      this.blog = data['blog'];
    });
  }

}
