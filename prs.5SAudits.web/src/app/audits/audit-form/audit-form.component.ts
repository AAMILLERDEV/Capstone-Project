import { Component, Input, OnInit } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Audits } from 'src/models/Audits';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { CheckItem } from 'src/models/CheckItem';
import { CheckItemService } from 'src/services/checkItem.service';
import { ToastrService } from 'ngx-toastr';
import { Zones } from 'src/models/Zones';
import { ZonesService } from 'src/services/zones.service';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';
import { AuditStatus } from 'src/models/AuditStatus';
import { AuditService } from 'src/services/audits.service';
import { audit } from 'rxjs';
import { ScoresService } from 'src/services/scores.service';
import { Scores } from 'src/models/Scores';

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
  //@Input() public scores: Scores[] = []; Couldn't get this working for right now, saving for later since it's not super needed just yet
  public scores: number[] = [];
  public date: Date = new Date();
  public index: number = 0;
  public currentCategory!: ScoringCategories;
  public comments: string[] = [];
  public selectedZoneCategoryId!: number;
  public matchingZones: Zones[] = [];
  public currentAuditId!: number;

  constructor(private controlContainer: ControlContainer,
    private auditService: AuditService,
    private scoreService: ScoresService,
    //private commentService: CommentService,
    private toastr: ToastrService,
    private router: Router
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
        this.currentCategory = this.scoringCategories[this.index];
        this.updateScoreControls();
      }
    }
    else if (input == false) {
      if (this.index < 4 //&& this.parentFormGroup.valid
      ) {
        if (this.validateScore()) {
          this.saveScores();
          this.index++;
          this.currentCategory = this.scoringCategories[this.index];
          this.updateScoreControls()
          this.toastr.success("Item Saved!");
        }
      }
    }
  }

  public updateScoreControls() {
    this.parentFormGroup.controls['commentsControl'].setValue(this.comments[this.index]);
    this.parentFormGroup.controls['scoreControl'].setValue(this.scores[this.index]);
  }

  public saveScores() {
    this.comments[this.index] = this.parentFormGroup.controls['commentsControl'].value;
    this.scores[this.index] = this.parentFormGroup.controls['scoreControl'].value;
    let newScore: Scores = {
      id: Number(`${this.currentAuditId}${this.currentCategory.id}`), //Generate a unique ID for each score that is based on audit:category for easy sorting
      scoreCategory_ID: this.currentCategory.id,
      score: this.scores[this.index],
      comments: this.parentFormGroup.controls['commentsControl'].value,
      audit_ID: this.currentAuditId
    }

    console.log(newScore);

    try {
      this.scoreService.UpsertScores(newScore);

    } catch (error) {
      console.log(error);
    }
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

    if (this.parentFormGroup.controls['zoneControl'].value) {

      let auditForm: Audits = {
        id: 1, //This doesn't matter because it auto generates a new id on the backend anyway
        auditStatus_ID: 0, //Fix later once auditstatus table has data
        employeeId: 0, //Update this once employee login is implemented
        dateStarted: new Date(),
        department_ID: this.parentFormGroup.controls['zoneControl'].value,
        dateCompleted: new Date(),
        notes: '',
        overallScore: 0
      }

      try {
        const response = await this.auditService.UpsertAudits(auditForm);
        this.currentAuditId = response;

        this.auditStarted = false;
        this.formReady = true;
        this.toastr.success("Item Saved!");
      } catch (error) {
        this.toastr.error("There was an error starting the audit.");
        console.log(error);
      }
    }
  }

  public async submitAudit() {
    //This method definitely needs to be fleshed out more, just putting something temp in to make it work...
    if (this.validateScore()) {

      // Need to update audit to have the finished date and overallScore
      this.saveScores();
      this.toastr.success("Item Saved!");

      this.router.navigate(['home']);
    }
  }
}