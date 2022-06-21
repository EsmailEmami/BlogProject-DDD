import {Component, Input, OnInit} from '@angular/core';
import {CommentService} from "../../services/comment.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NotificationService} from "../../../../core/services/notification.service";
import {LoaderService} from "../../../../core/services/loader.service";
import {AuthService} from "../../../../core/services/auth.service";
import {Router} from "@angular/router";
import {AddCommentRequest} from "../../../../core/models/requests/comment/addCommentRequest";

@Component({
  selector: 'app-blog-detail-add-comment',
  templateUrl: './blog-detail-add-comment.component.html',
})
export class BlogDetailAddCommentComponent implements OnInit {

  @Input('blogId') public blogId!: string;
  public addCommentForm!: FormGroup;
  private userId!: string | null;

  constructor(private commentService: CommentService,
              private formBuilder: FormBuilder,
              private notificationService: NotificationService,
              private loaderService: LoaderService,
              private authService: AuthService,
              private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.commentService.startHub().then(() => this.commentService.setActiveRoom(this.blogId));

    this.userId = this.authService.userId;

    this.addCommentForm = this.formBuilder.group({
      title: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(150),
        ])
      ],
      commentMessage: ['',
        Validators.compose([
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(1000)
        ])
      ]
    });
  }

  get controls() {
    return this.addCommentForm.controls;
  }

  onSubmit() {
    if (this.addCommentForm.invalid) {
      return;
    }

    if (!this.userId) {
      this.notificationService.showError('شما باید به حساب کاربری خود وارد شوید');
      this.router.navigate(['login'], {
        queryParams: {
          returnUrl: this.router.routerState.snapshot.url
        }
      })
    }

    this.loaderService.start();

    const comment = new AddCommentRequest(
      this.userId as string,
      this.blogId,
      this.controls['title'].value,
      this.controls['commentMessage'].value,
    );

    this.commentService.addComment(comment)
      .then(_ => this.notificationService.showSuccess('بازخورد شما با موفقیت ثبت شد'))

    this.loaderService.stop();
  }
}
