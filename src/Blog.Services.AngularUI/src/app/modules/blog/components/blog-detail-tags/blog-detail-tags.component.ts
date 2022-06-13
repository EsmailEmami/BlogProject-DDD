import {Component, Input, OnInit} from '@angular/core';
import {BlogService} from "../../services/blog.service";
import {TagForShowRequest} from "../../../../core/models/requests/tag/tagForShowRequest";

@Component({
  selector: 'app-blog-detail-tags',
  templateUrl: './blog-detail-tags.component.html',
})
export class BlogDetailTagsComponent implements OnInit {

  @Input('blogId') public blogId!: string;

  public tags: TagForShowRequest[] = [];

  constructor(private blogService: BlogService) {
  }

  ngOnInit(): void {
    this.blogService.blogTags(this.blogId)
      .then(tags => this.tags = tags);
  }

}
