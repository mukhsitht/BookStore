import { Directive, Input } from '@angular/core'
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms'

@Directive({
  selector: '[validatePrice]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting: ValidatePriceDirective,
    multi: true
  }]
})
export class ValidatePriceDirective implements Validator {
  @Input('validatePrice') price: string = '';

  validate(control: AbstractControl): ValidationErrors | null {
    return control.value <= 0 ? { validatePrice: true } : null;
  }
}
