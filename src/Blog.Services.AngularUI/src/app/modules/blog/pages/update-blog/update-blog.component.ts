import {AfterViewChecked, Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AuthService} from "../../../../core/services/auth.service";
import {BlogService} from "../../services/blog.service";
import {NotificationService} from "../../../../core/services/notification.service";
import {UpdateBlogRequest} from "../../../../core/models/requests/blog/updateBlogRequest";
import {CategoryService} from "../../services/category.service";
import {TagService} from "../../services/tag.service";
import {CategoryForShowRequest} from "../../../../core/models/requests/category/categoryForShowRequest";
import {TagForShowRequest} from "../../../../core/models/requests/tag/tagForShowRequest";

declare function multiSelectDropdown(): any;

@Component({
  selector: 'app-update-blog',
  templateUrl: './update-blog.component.html',
})
export class UpdateBlogComponent implements OnInit, AfterViewChecked {

  public blogForm!: FormGroup;
  public blog!: UpdateBlogRequest;
  public categories: CategoryForShowRequest[] = [];
  public tags: TagForShowRequest[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private blogService: BlogService,
    private notificationService: NotificationService,
    private categoryService: CategoryService,
    private tagService: TagService
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
          imageFile: [''],
          readTime: [this.blog.readTime,
            Validators.compose([
              Validators.required,
              Validators.maxLength(10)
            ])
          ],
          categories: [this.blog.categories,
            Validators.compose([
              Validators.required
            ])
          ],
          tags: [this.blog.tags,
            Validators.compose([
              Validators.required
            ])
          ]
        });

      }, () => {
        this.router.navigate(['']).then();
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

    const request = new UpdateBlogRequest(
      this.blog.id,
      this.blog.authorId,
      this.controls['blogTitle'].value,
      this.controls['summary'].value,
      this.controls['description'].value,
      this.controls['imageFile'].value,
      this.controls['readTime'].value,
      this.controls['tags'].value,
      this.controls['categories'].value,
    );

    this.blogService.updateBlog(request)
      .then(_ => {
        this.notificationService.showSuccess("مقاله با موفقیت ویرایش شد.");
        this.router.navigate(['blog/blogs']).then(_ => this.blogForm.reset());
      });
  }

}
