export class AddBlogRequest {
  authorId: string;
  blogTitle: string;
  summary: string;
  description: string;
  imageFile: string;
  readTime: string;

  constructor(authorId: string, blogTitle: string, summary: string, description: string, imageFile: string, readTime: string) {
    this.authorId = authorId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.description = description;
    this.imageFile = imageFile;
    this.readTime = readTime;
  }
}
