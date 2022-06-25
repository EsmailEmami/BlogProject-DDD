import {AfterViewChecked, AfterViewInit, Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {BlogService} from "../../services/blog.service";
import {AddBlogRequest} from "../../../../core/models/requests/blog/addBlogRequest";
import {NotificationService} from "../../../../core/services/notification.service";
import {LoaderService} from "../../../../core/services/loader.service";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";
import {TagForShowRequest} from "../../../../core/models/requests/tag/tagForShowRequest";
import {CategoryService} from "../../services/category.service";
import {TagService} from "../../services/tag.service";

declare function multiSelectDropdown(): any;

@Component({
  selector: 'app-add-blog',
  templateUrl: './add-blog.component.html'
})
export class AddBlogComponent implements OnInit, AfterViewChecked {

  public blogForm!: FormGroup;
  public categories: CategoryForShowRequest[] = [];
  public tags: TagForShowRequest[] = [];
  private userId!: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private blogService: BlogService,
    private notificationService: NotificationService,
    private loader: LoaderService,
    private categoryService: CategoryService,
    private tagService: TagService
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
      ],
      categories: ['',
        Validators.compose([
          Validators.required
        ])
      ],
      tags: ['',
        Validators.compose([
          Validators.required
        ])
      ]
    });

    this.categoryService.getCategories().then(categories => this.categories = categories);
    this.tagService.getTags().then(tags => this.tags = tags);
  }

  ngAfterViewChecked(): void {
    setTimeout(multiSelectDropdown, 1000)
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

    this.loader.start();

    const request = new AddBlogRequest(
      this.userId,
      this.controls['blogTitle'].value,
      this.controls['summary'].value,
      this.controls['description'].value,
      this.controls['imageFile'].value,
      this.controls['readTime'].value,
      this.controls['tags'].value,
      this.controls['categories'].value,
    );

    this.blogService.addBlog(request)
      .then(_ => {
        this.notificationService.showSuccess("مقاله با موفقیت منتشر شد.");
        this.router.navigate(['blog/blogs']).then(_ => this.blogForm.reset());
      });

    this.loader.stop();
  }
}
