export class UpdateCategoryRequest {
  categoryId: string;
  categoryTitle: string;

  constructor(categoryId: string, categoryTitle: string) {
    this.categoryId = categoryId;
    this.categoryTitle = categoryTitle;
  }
}
