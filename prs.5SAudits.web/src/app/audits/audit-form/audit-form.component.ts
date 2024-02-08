import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Audits } from 'src/models/Audits';
import { Settings } from 'src/models/Settings';
import { SettingsService } from 'src/services/settings.service';

@Component({
  selector: 'app-audit-form',
  templateUrl: './audit-form.component.html',
  styleUrls: ['./audit-form.component.scss']
})
export class AuditFormComponent implements OnInit {

  public currentTab: string = 'form';
  public viewReady: boolean = false;
  @Input() public formReady: boolean = false;
  @Input() public auditStarted: boolean = true;
  public parentFormGroup!: FormGroup;
  public settings: Settings[] = [];
  public date: Date = new Date();
  public index: number = 0;
  public currentSetting!: Settings;

  constructor(private controlContainer: ControlContainer,
    private settingsService: SettingsService){

  }

  async ngOnInit() {
    this.parentFormGroup = this.controlContainer.control as FormGroup;

    this.settings = await this.settingsService.getSettings();
    this.currentSetting = this.settings[this.index];
    for (let i = 0; i < 5; i++){
      let originalSettings = this.settings[0];
      let copy = {...originalSettings};
      this.settings.push(copy)
      console.log(i)
    }
    this.viewReady = true;

  }

  public collectionManager(input: String){
    if (input == "prev") {
      if (this.index > 0) {
        this.index--;
      }
    }
    else if (input == "next") {
      if (this.index < 4) {
        this.index++;
      }
    }

    this.currentSetting = this.settings[this.index];
    console.log(this.index);
  }


  public async startAudit() {
    // let auditForm: Audits = {
    //   auditStatus_ID: 0,
    //   dateStarted: new Date(),
    //   department_ID: this.parentFormGroup.controls['zoneControl'].value,

    // }

    this.auditStarted = false;
    this.formReady = true;
  }

}
