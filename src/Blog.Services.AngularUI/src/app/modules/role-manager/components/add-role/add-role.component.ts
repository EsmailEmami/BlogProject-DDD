import {Component, Input, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {RoleService} from "../../services/role.service";

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
})
export class AddRoleComponent implements OnInit {

  public roleForm!: FormGroup;

  constructor(private activeModal: NgbActiveModal,
              private formBuilder: FormBuilder,
              private roleService: RoleService) {
  }

  ngOnInit(): void {


    this.roleForm = this.formBuilder.group({
      roleName: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20)
        ])
      ],
    });
  }

  get controls() {
    return this.roleForm.controls;
  }

  onSubmit() {
    if (this.roleForm.invalid) {
      return;
    }

    this.roleService.addRole(this.controls['roleName'].value)
      .then((data) => {
        this.activeModal.close(data);
        this.roleForm.reset();
      });
  }

  closeModal() {
    this.activeModal.close();
  }
}
