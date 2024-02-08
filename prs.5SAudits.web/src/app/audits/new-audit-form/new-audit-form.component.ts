import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AuditForm } from 'src/form-models/AuditForm';

@Component({
  selector: 'app-new-audit-form',
  templateUrl: './new-audit-form.component.html',
  styleUrls: ['./new-audit-form.component.scss']
})
export class NewAuditFormComponent implements OnInit {

  public auditForm: FormGroup;

  constructor(){
    this.auditForm = AuditForm;
  }

  async ngOnInit() {

    this.auditForm.controls['auditNumberControl'].disable();
    
  }

  public async getData(){
    
  }

}
