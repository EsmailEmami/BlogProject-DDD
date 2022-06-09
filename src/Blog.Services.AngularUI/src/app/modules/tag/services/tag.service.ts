import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient} from "@angular/common/http";
import {TagForShowRequest} from "../../../core/models/requests/tag/tagForShowRequest";

const CONTROLLER_NAME: string = 'tag/';

@Injectable({
  providedIn: 'root'
})
export class TagService extends RestService {

  constructor(http: HttpClient) {
    super(http);
  }

  public getTags(): Promise<TagForShowRequest[]> {
    return this.get(CONTROLLER_NAME + 'tags').toPromise();
  }
}
