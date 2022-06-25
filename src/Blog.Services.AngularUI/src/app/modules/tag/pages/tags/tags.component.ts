import {Component, OnInit} from '@angular/core';
import {TagService} from "../../services/tag.service";
import {TagForShowRequest} from "../../../../core/models/requests/tag/tagForShowRequest";
import {AddTagComponent} from "../../components/add-tag/add-tag.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {NotificationService} from "../../../../core/services/notification.service";
import {UpdateTagComponent} from "../../components/update-tag/update-tag.component";
import {UpdateTagRequest} from "../../../../core/models/requests/tag/updateTagRequest";

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
})
export class TagsComponent implements OnInit {
  public tags: TagForShowRequest[] = [];

  constructor(private tagService: TagService,
              private modalService: NgbModal,
              private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.tagService.getTags()
      .then(tags => this.tags = tags);
  }

  newTag() {
    const modalRef = this.modalService.open(AddTagComponent);

    modalRef.result.then((data: TagForShowRequest) => {
      if (data) {
        this.tags.unshift(data);
        this.notificationService.showSuccess('تگ با موفقیت افزوده شد');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }

  updateTag(tagId: string) {
    const modalRef = this.modalService.open(UpdateTagComponent);
    modalRef.componentInstance.tagId = tagId;

    modalRef.result.then((data: UpdateTagRequest) => {
      if (data) {
        // @ts-ignore
        this.tags.find(x => x.tagId == data.tagId).tagName = data.tagName;
        this.notificationService.showSuccess('تگ با موفقیت ویرایش شد');
      }
    }).catch(e => {
      if (e) {
        this.notificationService.showError(e);
      }
    });
  }
}
