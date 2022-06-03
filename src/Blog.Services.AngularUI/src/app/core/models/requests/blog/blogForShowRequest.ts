export class BlogForShowRequest {
  blogId: string;
  blogTitle: string;
  Tags: string[];

  constructor(blogId: string, blogTitle: string, Tags: string[]) {
    this.blogId = blogId;
    this.blogTitle = blogTitle;
    this.Tags = Tags;
  }
}
