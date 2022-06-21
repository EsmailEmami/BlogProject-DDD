export class AddCommentRequest {
  userId: string;
  blogId: string;
  title: string;
  commentMessage: string;

  constructor(userId: string, blogId: string, title: string, commentMessage: string) {
    this.userId = userId;
    this.blogId = blogId;
    this.title = title;
    this.commentMessage = commentMessage;
  }
}
