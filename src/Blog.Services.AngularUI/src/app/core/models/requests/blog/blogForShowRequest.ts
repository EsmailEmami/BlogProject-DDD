export class BlogForShowRequest {
  blogId: string;
  blogTitle: string;
  summary: string;
  postedAt: Date;
  imageFile: string;
  commentsCount: number;
  tags: string[];

  constructor(blogId: string, blogTitle: string, summary: string, postedAt: Date, imageFile: string, commentsCount: number, tags: string[]) {
    this.blogId = blogId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.postedAt = postedAt;
    this.imageFile = imageFile;
    this.commentsCount = commentsCount;
    this.tags = tags;
  }
}
