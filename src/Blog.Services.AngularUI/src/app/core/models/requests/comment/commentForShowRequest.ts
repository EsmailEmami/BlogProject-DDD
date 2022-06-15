export class CommentForShowRequest {
  commentId: string;
  fullName: string;
  title: string;
  commentMessage: string;
  commentDate: Date;


  constructor(commentId: string, fullName: string, title: string, commentMessage: string, commentDate: Date) {
    this.commentId = commentId;
    this.fullName = fullName;
    this.title = title;
    this.commentMessage = commentMessage;
    this.commentDate = new Date(commentDate);
  }
}
