import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Audits } from 'src/models/Audits';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { CheckItem } from 'src/models/CheckItem';
import { CheckItemService } from 'src/services/checkItem.service';
import { ToastrService } from 'ngx-toastr';
import { Zones } from 'src/models/Zones';
import { ZonesService } from 'src/services/zones.service';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';

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
  @Input() public scoringCategories: ScoringCategories[] = [];
  @Input() public checkItem: CheckItem[] = [];
  @Input() public zones: Zones[] = [];
  @Input() public zoneCategories: ZoneCategories[] = [];
  public date: Date = new Date();
  public index: number = 0;
  public currentCategory!: ScoringCategories;
  public scores: number[] = [];
  public comments: string[] = [];
  public selectedZoneCategoryId!: number;
  public matchingZones: Zones[] = [];

  constructor(private controlContainer: ControlContainer,
    private toastr: ToastrService
    ){
  }

  async ngOnInit() {
    this.parentFormGroup = this.controlContainer.control as FormGroup;

    console.log("categories in form: " + this.scoringCategories);
    if (this.scoringCategories.length > 0) {
      this.currentCategory = this.scoringCategories[this.index];
    }

    this.viewReady = true;

    this.parentFormGroup.controls['zoneControl'].disable();
    this.parentFormGroup.controls['zoneControl'].setValue(null);
    this.parentFormGroup.controls['zoneCategoryControl'].setValue(null);

  }

  public collectionManager(input: boolean){

    if (input == true) {
      if (this.index > 0) {
        if (this.validateScore()) {
          this.saveScores();
          this.toastr.success("Item Saved!");
        }
        this.index--;
        this.updateScoreControls();
      }
    }
    else if (input == false) {
      if (this.index < 4 //&& this.parentFormGroup.valid
      ) {
        if (this.validateScore()) {
          this.saveScores();
          this.index++;
          this.updateScoreControls()
          this.toastr.success("Item Saved!");
        }
      }
    }

    this.currentCategory = this.scoringCategories[this.index];
    console.log(this.index);
  }

  public updateScoreControls() {
    this.parentFormGroup.controls['commentsControl'].setValue(this.comments[this.index]);
    this.parentFormGroup.controls['scoreControl'].setValue(this.scores[this.index]);
  }

  public saveScores() {
    this.comments[this.index] = this.parentFormGroup.controls['commentsControl'].value;
    this.scores[this.index] = this.parentFormGroup.controls['scoreControl'].value;
  }

  public validateScore() {
    let score = this.parentFormGroup.controls['scoreControl'].value
    if (score == null) {
      return false;
    }

    if (isNaN(score)) {
      return false;
    }

    if (score < 0 || score > 5) {
      return false;
    }

    return true;
  }

  public updateZoneCategory(){
    this.selectedZoneCategoryId = this.parentFormGroup.controls['zoneCategoryControl'].value;
    console.log(this.selectedZoneCategoryId);

    this.matchingZones = this.zones.filter(zone => zone.zoneCategory_ID == this.selectedZoneCategoryId);
    this.parentFormGroup.controls['zoneControl'].enable();
  }


  public async startAudit() {
    // let auditForm: Audits = {
    //   auditStatus_ID: 0,
    //   dateStarted: new Date(),
    //   department_ID: this.parentFormGroup.controls['zoneControl'].value,

    // }

    if (this.parentFormGroup.controls['zoneControl'].value) {
      this.auditStarted = false;
      this.formReady = true;
      this.toastr.success("Item Saved!");
    }

  }

}
