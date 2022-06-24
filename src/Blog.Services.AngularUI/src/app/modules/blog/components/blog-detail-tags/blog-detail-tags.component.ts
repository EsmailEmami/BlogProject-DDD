import {Component, Input, OnInit} from '@angular/core';
import {BlogService} from "../../services/blog.service";
import {TagForShowRequest} from "../../../../core/models/requests/tag/tagForShowRequest";
import {TagService} from "../../services/tag.service";

@Component({
  selector: 'app-blog-detail-tags',
  templateUrl: './blog-detail-tags.component.html',
})
export class BlogDetailTagsComponent implements OnInit {

  @Input('blogId') public blogId!: string;

  public tags: TagForShowRequest[] = [];

  constructor(private tagService: TagService) {
  }

  ngOnInit(): void {
    this.tagService.getBlogTags(this.blogId)
      .then(tags => this.tags = tags);
  }

}
