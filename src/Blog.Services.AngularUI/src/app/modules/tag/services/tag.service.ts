import {Injectable} from '@angular/core';
import {RestService} from "../../../core/services/http/rest.service";
import {HttpClient, HttpParams} from "@angular/common/http";
import {TagForShowRequest} from "../../../core/models/requests/tag/tagForShowRequest";
import {AddTagRequest} from "../../../core/models/requests/tag/addTagRequest";
import {UpdateTagRequest} from "../../../core/models/requests/tag/updateTagRequest";

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

  public addTag(tag: AddTagRequest): Promise<TagForShowRequest> {
    return this.post(CONTROLLER_NAME + 'add-tag', tag).toPromise();
  }

  public getTagForUpdate(tagId: string): Promise<UpdateTagRequest> {
    const params = new HttpParams()
      .append('tagId', tagId);
    return this.get(CONTROLLER_NAME + 'get-tag-for-update', params).toPromise();
  }

  public updateTag(tag: UpdateTagRequest): Promise<void> {
    return this.put(CONTROLLER_NAME + 'update-tag', tag).toPromise();
  }
}
