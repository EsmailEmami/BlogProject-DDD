import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'persianDate'
})
export class PersianDatePipe implements PipeTransform {

  transform(value: Date): string {
    return value.toLocaleDateString('fa-IR');
  }
}
