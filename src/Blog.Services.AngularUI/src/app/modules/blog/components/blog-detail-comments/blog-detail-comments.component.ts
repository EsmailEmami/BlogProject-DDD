import {Component, Input, OnInit} from '@angular/core';
import {CommentService} from "../../services/comment.service";
import {CommentForShowRequest} from "../../../../core/models/requests/comment/commentForShowRequest";

@Component({
  selector: 'app-blog-detail-comments',
  templateUrl: './blog-detail-comments.component.html',
})
export class BlogDetailCommentsComponent implements OnInit {

  @Input('blogId') public blogId!: string;

  public comments: CommentForShowRequest[] = [];

  constructor(private commentService: CommentService) {
  }

  ngOnInit(): void {
    this.commentService.blogComments(this.blogId)
      .then(comments => this.comments = comments);
  }

}
