export class AddBlogRequest {
  authorId: string;
  blogTitle: string;
  summary: string;
  description: string;
  imageFile: string;
  readTime: string;
  tags: string[];
  categories: string[];

  constructor(authorId: string, blogTitle: string, summary: string, description: string, imageFile: string, readTime: string, tags: string[], categories: string[]) {
    this.authorId = authorId;
    this.blogTitle = blogTitle;
    this.summary = summary;
    this.description = description;
    this.imageFile = imageFile;
    this.readTime = readTime;
    this.tags = tags;
    this.categories = categories;
  }
}
