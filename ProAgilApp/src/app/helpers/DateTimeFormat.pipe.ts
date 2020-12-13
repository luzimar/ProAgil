import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'DateTimeFormatPipe'
})
export class DateTimeFormatPipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
      if (value === undefined){
        return '';
      }
      if(typeof value === 'string')
        return value;
      const options = { year: "numeric", month: "numeric", day: "numeric", hour: "numeric", minute: "numeric" };
      const teste = value.toLocaleDateString("pt-br", options);
      return teste;
  }

}
