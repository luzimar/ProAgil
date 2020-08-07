import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Constants } from '../utils/Constants';

@Pipe({
  name: 'DateTimeFormatPipe'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  transform(value: Date, args?: any): any {
    try{
      const formattedMonth = value.getMonth() < 12 ? value.getMonth() + 1 : value.getMonth();
      const day = value.getDate() < 10 ? '0' + value.getDate() : value.getDate();
      const month = value.getMonth() < 10 ? '0' + formattedMonth : formattedMonth;
      const year = value.getFullYear();
      const hour = value.getHours() < 10 ? '0' + value.getHours() : value.getHours();
      const minutes = value.getMinutes() < 10 ? '0' + value.getMinutes() : value.getMinutes();
      return `${day}/${month}/${year} ${hour}:${minutes}`;
    } catch {
      return value.toString();
    }
  }

}
