import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {AddCategoryRequest} from "../../../core/models/requests/category/addCategoryRequest";
import {UpdateCategoryRequest} from "../../../core/models/requests/category/updateCategoryRequest";
import {CategoryForShowRequest} from "../../../core/models/requests/category/categoryForShowRequest";

const CONTROLLER_NAME: string = 'category/';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public addCategory(request: AddCategoryRequest): Promise<CategoryForShowRequest> {
    return this.post(CONTROLLER_NAME + 'add-category', request).toPromise();
  }

  public getCategoryForUpdate(categoryId: string) {
    const params = new HttpParams()
      .append('categoryId', categoryId);

    return this.get(CONTROLLER_NAME + 'get-category-for-update', params).toPromise();
  }

  public updateCategory(request: UpdateCategoryRequest) {
    return this.put(CONTROLLER_NAME + 'update-category', request).toPromise();
  }

  public getCategories(): Promise<CategoryForShowRequest[]> {
    return this.get(CONTROLLER_NAME + 'categories').toPromise();
  }
}
