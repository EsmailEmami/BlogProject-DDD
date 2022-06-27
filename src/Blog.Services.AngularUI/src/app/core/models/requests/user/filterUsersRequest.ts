import {BasePaging} from "../../basePaging";
import {UserForShowRequest} from "./userForShowRequest";

export class FilterUsersRequest implements BasePaging {
  users: UserForShowRequest[];
  search: string;
  activePage: number;
  endPage: number;
  pageId: number;
  pagesCount: number;
  skipEntity: number;
  startPage: number;
  takeEntity: number;

  constructor(users: UserForShowRequest[], search: string, activePage: number, endPage: number, pageId: number, pagesCount: number, skipEntity: number, startPage: number, takeEntity: number) {
    this.users = users;
    this.search = search;
    this.activePage = activePage;
    this.endPage = endPage;
    this.pageId = pageId;
    this.pagesCount = pagesCount;
    this.skipEntity = skipEntity;
    this.startPage = startPage;
    this.takeEntity = takeEntity;
  }
}
