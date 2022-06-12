import { Injectable } from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CommentService extends RestService{

  constructor(http: HttpClient) {
    super(http);
  }
}
