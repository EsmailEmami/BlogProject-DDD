import {Component, OnInit} from '@angular/core';
import {TagService} from "../../services/tag.service";
import {TagForShowRequest} from "../../../../core/models/requests/tag/tagForShowRequest";

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
})
export class TagsComponent implements OnInit {
  public tags: TagForShowRequest[] = [];

  constructor(private tagService: TagService) {
  }

  ngOnInit(): void {
    this.tagService.getTags()
      .then(tags => this.tags = tags);
  }

}
