import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {AddCategoryRequest} from "../../../core/models/requests/category/addCategoryRequest";
import {UpdateCategoryRequest} from "../../../core/models/requests/category/updateCategoryRequest";

const CONTROLLER_NAME: string = 'category/';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public addCategory(request: AddCategoryRequest) {
    return this.post(CONTROLLER_NAME + 'add-category', request).toPromise();
  }

  public updateCategory(request: UpdateCategoryRequest) {
    return this.put(CONTROLLER_NAME + 'update-category', request).toPromise();
  }

}
