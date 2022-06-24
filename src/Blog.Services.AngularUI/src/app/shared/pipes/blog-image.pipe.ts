import { Pipe, PipeTransform } from '@angular/core';
import {blogImagePath} from "../../core/constants/pathConstants";

@Pipe({
  name: 'blogImage'
})
export class BlogImagePipe implements PipeTransform {

  transform(value: string): string {
    return blogImagePath + value;
  }

}
