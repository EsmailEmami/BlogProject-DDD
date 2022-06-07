import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'separate'
})
export class SeparatePipe implements PipeTransform {

  transform(value: number): string {
    return Number(value).toLocaleString();
  }

}
