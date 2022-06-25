import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {TagService} from "../../services/tag.service";
import {AddTagRequest} from "../../../../core/models/requests/tag/addTagRequest";
import {UpdateTagRequest} from "../../../../core/models/requests/tag/updateTagRequest";

@Component({
  selector: 'app-update-tag',
  templateUrl: './update-tag.component.html',
})
export class UpdateTagComponent implements OnInit {

  @Input() private tagId!: string;
  public tagForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private tagService: TagService) {
  }

  ngOnInit(): void {
    this.tagService.getTagForUpdate(this.tagId).then((data) => {
      this.tagForm = this.formBuilder.group({
        tagName: [data.tagName,
          Validators.compose([
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(20)
          ])
        ],
      });
    });
  }

  get controls() {
    return this.tagForm.controls;
  }

  onSubmit() {
    if (this.tagForm.invalid) {
      return;
    }

    const request = new UpdateTagRequest(
      this.tagId,
      this.controls['tagName'].value
    );

    this.tagService.updateTag(request)
      .then(() => {
        this.activeModal.close(request);
      });
  }

  closeModal() {
    this.activeModal.close();
  }
}
