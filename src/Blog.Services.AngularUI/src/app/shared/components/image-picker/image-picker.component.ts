import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild
} from '@angular/core';
import {NgxImageCompressService} from "ngx-image-compress";

@Component({
  selector: 'app-image-picker',
  templateUrl: './image-picker.component.html',
})
export class ImagePickerComponent implements OnInit {

  @Output() imagePick = new EventEmitter<string>();
  @ViewChild('filePicker') filePicker!: ElementRef<HTMLInputElement>;
  @Input('src') public imageSrc!: string;

  public selectedImage: string = 'assets/img/placeholder-image.png';

  constructor(private imageCompress: NgxImageCompressService) {
  }

  ngOnInit() {
    if (this.imageSrc) {
      this.selectedImage = this.imageSrc;
    }
  }

  onPickImage() {
    this.imageCompress.uploadFile().then(({image, orientation}) => {
      this.imageCompress.compressFile(image, orientation, 50, 90).then(
        result => {
          this.selectedImage = result;
          this.imagePick.emit(result);
        }
      );
    });
    return;
  }

}
