import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'persianDateTime'
})
export class PersianDateTimePipe implements PipeTransform {
  transform(value: Date): string {
    return new Date(value).toLocaleDateString('fa-IR', {
      year: 'numeric',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit'
    });
  }
}
