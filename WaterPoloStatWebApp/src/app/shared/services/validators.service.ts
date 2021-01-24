import { Injectable } from '@angular/core';
import { AbstractControl, ValidatorFn } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidatorsService {

  constructor() { }
  compare2Field(comp: AbstractControl): ValidatorFn {
    return (c: AbstractControl): { [key: string]: boolean } | null => {
      if (c.value != comp.value) {
        return { 'compare2Field': true };
      }
      return null;
    };
  }
}
