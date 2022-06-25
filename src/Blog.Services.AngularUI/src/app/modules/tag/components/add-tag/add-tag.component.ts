import {Component, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {TagService} from "../../services/tag.service";
import {AddCategoryRequest} from "../../../../core/models/requests/category/addCategoryRequest";
import {AddTagRequest} from "../../../../core/models/requests/tag/addTagRequest";

@Component({
  selector: 'app-add-tag',
  templateUrl: './add-tag.component.html',
})
export class AddTagComponent implements OnInit {

  public tagForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private tagService: TagService) {
  }

  ngOnInit(): void {
    this.tagForm = this.formBuilder.group({
      tagName: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20)
        ])
      ],
    });
  }

  get controls() {
    return this.tagForm.controls;
  }

  onSubmit() {
    if (this.tagForm.invalid) {
      return;
    }

    const request = new AddTagRequest(
      this.controls['tagName'].value
    );

    this.tagService.addTag(request)
      .then((data) => {
        this.activeModal.close(data);
      });
  }

  closeModal() {
    this.activeModal.close();
  }
}
