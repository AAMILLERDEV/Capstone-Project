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

    console.log("cateogires in form: " + this.scoringCategories);
    if (this.scoringCategories.length > 0) {
      this.currentCategory = this.scoringCategories[this.index];
    }

    this.viewReady = true;

    this.toastr.success("Item Saved!")

  }

  public collectionManager(input: boolean){

    this.comments[this.index] = this.parentFormGroup.controls['commentsControl'].value;
    this.scores[this.index] = this.parentFormGroup.controls['scoreControl'].value;

    //Probably wanna push up the comments and score for the current index to the DB here?
    //
    //

    if (input == true) {
      if (this.index > 0) {
        this.index--;
      }
    }
    else if (input == false) {
      if (this.index < 4 //&& this.parentFormGroup.valid
      ) {
        this.index++;
      }
    }

    this.parentFormGroup.controls['commentsControl'].setValue(this.comments[this.index]);
    this.parentFormGroup.controls['scoreControl'].setValue(this.scores[this.index]);

    this.currentCategory = this.scoringCategories[this.index];
    console.log(this.index);
  }

  public updateZoneCategory(){
    this.selectedZoneCategoryId = this.parentFormGroup.controls['zoneCategoryControl'].value;
    console.log(this.selectedZoneCategoryId);

    this.matchingZones = this.zones.filter(zone => zone.zoneCategory_ID == this.selectedZoneCategoryId);
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
