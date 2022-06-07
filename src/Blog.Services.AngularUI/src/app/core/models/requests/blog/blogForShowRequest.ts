export class BlogForShowRequest {
  blogId: string;
  blogTitle: string;
  summary: string;
  postedAt: Date;
  imageFile: string;
  commentsCount: number;
  Tags: string[];

  constructor(blogId: string, blogTitle: string, summary: string, postedAt: Date, imageFile: string, commentsCount: number, Tags: string[]) {
    this.blogId = blogId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.postedAt = postedAt;
    this.imageFile = imageFile;
    this.commentsCount = commentsCount;
    this.Tags = Tags;
  }
}
