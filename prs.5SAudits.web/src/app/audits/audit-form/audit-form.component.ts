import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Audits } from 'src/models/Audits';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { ScoringCategoriesService } from 'src/services/scoringCategories.service'
import { Settings } from 'src/models/Settings';
import { SettingsService } from 'src/services/settings.service';
import { CheckItem } from 'src/models/CheckItem';
import { CheckItemService } from 'src/services/checkItem.service';

@Component({
  selector: 'app-audit-form',
  templateUrl: './audit-form.component.html',
  styleUrls: ['./audit-form.component.scss']
})
export class AuditFormComponent implements OnInit {

  public currentTab: string = 'form';
  public viewReady: boolean = false;
  @Input() public formReady: boolean = true;
  @Input() public auditStarted: boolean = false;
  public parentFormGroup!: FormGroup;
  public settings: Settings[] = [];
  public scoringCategories: ScoringCategories[] = [];
  public checkItem: CheckItem[] = [];
  public date: Date = new Date();
  public index: number = 0;
  public currentCategory!: ScoringCategories;

  constructor(private controlContainer: ControlContainer,
    private settingsService: SettingsService,
    private scoringCategoriesService: ScoringCategoriesService,
    private checkItemService: CheckItemService
    ){
  }

  async ngOnInit() {
    this.parentFormGroup = this.controlContainer.control as FormGroup;

    this.settings = await this.settingsService.getSettings();

    this.scoringCategories = await this.scoringCategoriesService.getScoringCategories();
    console.log(this.scoringCategories);
    this.currentCategory = this.scoringCategories[this.index];

    this.checkItem = await this.checkItemService.getCheckItem();
    console.log(this.checkItem);

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

    this.currentCategory = this.scoringCategories[this.index];
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
