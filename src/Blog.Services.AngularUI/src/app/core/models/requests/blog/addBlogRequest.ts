export class AddBlogRequest {
  authorId: string;
  blogTitle: string;
  summary: string;
  description: string;
  file: File;
  readTime: string;

  constructor(authorId: string, blogTitle: string, summary: string, description: string, file: File, readTime: string) {
    this.authorId = authorId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.description = description;
    this.file = file;
    this.readTime = readTime;
  }
}
