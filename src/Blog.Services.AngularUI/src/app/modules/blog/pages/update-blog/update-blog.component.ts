import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {BlogService} from "../../services/blog.service";
import {NotificationService} from "../../../../core/services/notification.service";
import {UpdateBlogRequest} from "../../../../core/models/requests/blog/updateBlogRequest";
import {blogImagePath} from "../../../../core/constants/pathConstants";

@Component({
  selector: 'app-update-blog',
  templateUrl: './update-blog.component.html',
})
export class UpdateBlogComponent implements OnInit {

  public blogForm!: FormGroup;
  public loading = false;
  private blog!: UpdateBlogRequest;
  public imageSrc: string = blogImagePath;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private blogService: BlogService,
    private notificationService: NotificationService
  ) {
  }

  ngOnInit(): void {

    const blogId: string = this.route.snapshot.params['blogId'];

    if (!blogId) {
      this.router.navigate(['']).then();
    }

    this.blogService.getBlogForUpdate(blogId)
      .then((data: UpdateBlogRequest) => {
        this.blog = data;

        this.imageSrc = this.imageSrc + this.blog.imageFile;

        this.blogForm = this.formBuilder.group({
          blogTitle: [this.blog.blogTitle,
            Validators.compose([
              Validators.required,
              Validators.minLength(5),
              Validators.maxLength(150)
            ])
          ],
          summary: [this.blog.summary,
            Validators.compose([
              Validators.required,
              Validators.minLength(50),
              Validators.maxLength(1000)
            ])
          ],
          description: [this.blog.description,
            Validators.compose([
              Validators.required,
              Validators.minLength(2000)
            ])
          ],
          imageFile: [this.blog.imageFile,
            Validators.required
          ],
          readTime: [this.blog.readTime,
            Validators.compose([
              Validators.required,
              Validators.maxLength(10)
            ])
          ]
        });

      }, () => {
        this.router.navigate(['']).then();
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

    const request = new UpdateBlogRequest(
      this.blog.id,
      this.blog.authorId,
      this.controls['blogTitle'].value,
      this.controls['summary'].value,
      this.controls['description'].value,
      this.controls['imageFile'].value,
      this.controls['readTime'].value,
    );

    this.blogService.updateBlog(request)
      .then(_ => {
        this.notificationService.showSuccess("مقاله با موفقیت ویرایش شد.");
        this.router.navigate(['']).then(_ => this.blogForm.reset());
      });

    this.loading = false;
  }

}
