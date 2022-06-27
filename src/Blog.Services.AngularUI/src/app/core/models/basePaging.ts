export abstract class BasePaging {
  abstract pageId: number;
  abstract pagesCount: number;
  abstract activePage: number;
  abstract startPage: number;
  abstract endPage: number;
  abstract takeEntity: number;
  abstract skipEntity: number;
}
