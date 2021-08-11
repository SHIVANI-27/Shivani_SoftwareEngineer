import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'customerFilter'
})
export class SearchPipe implements PipeTransform {

  transform(value: any, args?: any): any {
      debugger
    if (!args) {
      return value;
    }
    return value.filter((val) => {
      let rVal = (  (val.FirstName && val.FirstName.toLowerCase().includes(args)) || (val.LastName && val.LastName.toLowerCase().includes(args)) || (val.Subject && val.Subject.toLowerCase().includes(args))
      || (val.Class && val.Class.toLowerCase().includes(args)));
      return rVal;
    })

  }

}