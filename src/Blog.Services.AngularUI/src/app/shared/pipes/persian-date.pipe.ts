import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'persianDate'
})
export class PersianDatePipe implements PipeTransform {
  transform(value: Date): string {
      return new Date(value).toLocaleDateString('fa-IR');
  }
}
