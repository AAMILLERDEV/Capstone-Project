import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AuditForm } from 'src/form-models/AuditForm';

@Component({
  selector: 'app-edit-audit-form',
  templateUrl: './edit-audit-form.component.html',
  styleUrls: ['./edit-audit-form.component.scss']
})
export class EditAuditFormComponent implements OnInit {

  public auditForm: FormGroup;

  constructor(){
    this.auditForm = AuditForm;
  }
  
  async ngOnInit() {
    
  }

  public async getData(){
    
  }

}
