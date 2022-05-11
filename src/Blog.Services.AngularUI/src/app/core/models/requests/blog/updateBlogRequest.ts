export class UpdateBlogRequest {
  blogId:string
  authorId: string;
  blogTitle: string;
  summary: string;
  description: string;
  imageFile: string;
  readTime: string;

  constructor(blogId:string, authorId: string, blogTitle: string, summary: string, description: string, imageFile: string, readTime: string) {
    this.blogId = blogId;
    this.authorId = authorId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.description = description;
    this.imageFile = imageFile;
    this.readTime = readTime;
  }
}
