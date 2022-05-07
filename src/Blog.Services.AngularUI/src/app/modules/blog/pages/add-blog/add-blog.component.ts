import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {BlogService} from "../../services/blog.service";
import {AddBlogRequest} from "../../../../core/models/requests/blog/addBlogRequest";
import {User} from "../../../../core/models/User";
import {NotificationService} from "../../../../core/services/notification.service";

@Component({
  selector: 'app-add-blog',
  templateUrl: './add-blog.component.html',
  styles: []
})
export class AddBlogComponent implements OnInit {

  public blogForm!: FormGroup;
  public loading = false;
  public errors!: string[];

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

    const user: User | null = this.authService.currentUser;

    if (!user) {
      this.router.navigate(['']).then();
    }

    this.userId = user?.id || '';

    this.blogForm = this.formBuilder.group({
      blogTitle: ['',
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(150)
      ],
      summary: ['',
        Validators.required,
        Validators.minLength(50),
        Validators.maxLength(1000)
      ],
      description: ['',
        Validators.required,
        Validators.minLength(2000)
      ],
      imageFile: ['',
        Validators.required
      ],
      readTime: ['',
        Validators.required,
        Validators.maxLength(10)
      ],
    });
  }

  get controls() {
    return this.blogForm.controls;
  }

  onSubmit() {
    if (this.blogForm.invalid) {
      return;
    }
    this.loading = true;

    const request = new AddBlogRequest(
      this.userId,
      this.controls['blogTitle'].value,
      this.controls['summary'].value,
      this.controls['description'].value,
      this.controls['imageFile'].value,
      this.controls['readTime'].value,
    )

    this.blogService.addBlog(request)
      .then(data => {
        this.notificationService.showSuccess("مقاله با موفقیت منتشر شد.");
        this.router.navigate(['']).then();
      }, error => {
        for (const message of error.errors) {
          this.errors.push(message);
        }
      });

    this.loading = false;
  }
}
