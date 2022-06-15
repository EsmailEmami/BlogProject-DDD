export class BlogDetailRequest {
  blogId: string;
  blogTitle: string;
  summary: string;
  description: string;
  postedAt: Date;
  imageFile: string;
  commentsCount: number;

  constructor(blogId: string, blogTitle: string, summary: string, description: string, postedAt: Date, imageFile: string, commentsCount: number) {
    this.blogId = blogId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.description = description;
    this.postedAt = new Date(postedAt);
    this.imageFile = imageFile;
    this.commentsCount = commentsCount;
  }
}
