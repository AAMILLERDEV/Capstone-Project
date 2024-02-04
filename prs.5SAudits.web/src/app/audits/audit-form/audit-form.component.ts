import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-audit-form',
  templateUrl: './audit-form.component.html',
  styleUrls: ['./audit-form.component.scss']
})
export class AuditFormComponent implements OnInit {

  public currentTab: string = 'form';
  public viewReady: boolean = false;
  public parentFormGroup!: FormGroup;

  constructor(public controlContainer: ControlContainer){

  }

  async ngOnInit() {
    this.parentFormGroup = this.controlContainer.control as FormGroup;
   this.viewReady = true;
  }

}
