export class TagForShowRequest {
  tagId: string;
  tagName: string;

  constructor(tagId: string, tagName: string) {
    this.tagId = tagId;
    this.tagName = tagName;
  }
}
