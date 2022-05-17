import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {BlogService} from "../../services/blog.service";
import {AddBlogRequest} from "../../../../core/models/requests/blog/addBlogRequest";
import {NotificationService} from "../../../../core/services/notification.service";

@Component({
  selector: 'app-add-blog',
  templateUrl: './add-blog.component.html'
})
export class AddBlogComponent implements OnInit {

  public blogForm!: FormGroup;
  public loading = false;

  private userId!: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private blogService: BlogService,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {

    this.userId = this.authService.userId || '';

    if (!this.userId) {
      this.router.navigate(['']).then();
    }

    this.blogForm = this.formBuilder.group({
      blogTitle: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(150)
        ])
      ],
      summary: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(50),
          Validators.maxLength(1000)
        ])
      ],
      description: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(2000)
        ])
      ],
      imageFile: ['',
        Validators.required
      ],
      readTime: ['',
        Validators.compose([
          Validators.required,
          Validators.maxLength(10)
        ])
      ]
    });
  }

  get controls() {
    return this.blogForm.controls;
  }

  uploadFile(event: any) {
    this.blogForm.patchValue({
      imageFile: event
    });
  }

  onSubmit() {
    if (this.blogForm.invalid) {
      return;
    }
    this.loading = true;

    const request = new AddBlogRequest(
      "270c45dd-6bdc-46ca-8113-d06914be6ac5",
      this.controls['blogTitle'].value,
      this.controls['summary'].value,
      this.controls['description'].value,
      this.controls['imageFile'].value,
      this.controls['readTime'].value,
    );

    this.blogService.addBlog(request)
      .then(_ => {
        this.notificationService.showSuccess("مقاله با موفقیت منتشر شد.");
        this.router.navigate(['']).then(_ => this.blogForm.reset());
      });

    this.loading = false;
  }
}
