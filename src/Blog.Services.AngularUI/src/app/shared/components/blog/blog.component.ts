import {Component, Input, OnInit} from '@angular/core';
import {BlogForShowRequest} from "../../../core/models/requests/blog/blogForShowRequest";
import {blogImagePath} from "../../../core/constants/pathConstants";

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html'
})
export class BlogComponent implements OnInit {

  @Input('blog') public blog!: BlogForShowRequest;

  constructor() {
  }

  ngOnInit(): void {
  }

}
