import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Audits } from 'src/models/Audits';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { ScoringCategoriesService } from 'src/services/scoringCategories.service'
import { CheckItem } from 'src/models/CheckItem';
import { CheckItemService } from 'src/services/checkItem.service';
import { ToastrService } from 'ngx-toastr';

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
  public scoringCategories: ScoringCategories[] = [];
  public checkItem: CheckItem[] = [];
  public date: Date = new Date();
  public index: number = 0;
  public currentCategory!: ScoringCategories;
  public scores: number[] = [];
  public comments: string[] = [];

  constructor(private controlContainer: ControlContainer,
    private scoringCategoriesService: ScoringCategoriesService,
    private checkItemService: CheckItemService,
    private toastr: ToastrService
    ){
  }

  async ngOnInit() {
    this.parentFormGroup = this.controlContainer.control as FormGroup;

    this.scoringCategories = await this.scoringCategoriesService.getScoringCategories();
    console.log(this.scoringCategories);
    this.currentCategory = this.scoringCategories[this.index];

    this.checkItem = await this.checkItemService.getCheckItem();
    console.log(this.checkItem);

    this.viewReady = true;

    this.toastr.success("Item Saved!")

  }

  public collectionManager(input: String){

    this.comments[this.index] = this.parentFormGroup.controls['commentsControl'].value;
    this.scores[this.index] = this.parentFormGroup.controls['scoreControl'].value;

    //Probably wanna push up the comments and score for the current index to the DB here?
    //
    //

    if (input == "prev") {
      if (this.index > 0) {
        this.index--;
      }
    }
    else if (input == "next") {
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
