import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { SupportForm } from 'src/form-models/SupportForm';

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.scss']
})
export class SupportComponent {

  public supportForm: FormGroup;

  constructor(){
    this.supportForm = SupportForm;
  }

  public sendEmail(): void {

  }
}
