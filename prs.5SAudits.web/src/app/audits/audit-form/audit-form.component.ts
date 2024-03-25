import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { ControlContainer, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Audits } from 'src/models/Audits';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { CheckItem } from 'src/models/CheckItem';
import { ToastrService } from 'ngx-toastr';
import { Zones } from 'src/models/Zones';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { AuditService } from 'src/services/audits.service';
import { ScoresService } from 'src/services/scores.service';
import { Scores } from 'src/models/Scores';
import { clearScoreForm, returnNumArray } from 'src/app/sharedUtils';
import { document } from 'ngx-bootstrap/utils';
import { ScoringCriteria } from 'src/models/ScoringCriteria';
import { Resources } from 'src/models/Resources';
import { ResourcesService} from 'src/services/resource.service';

@Component({
  selector: 'app-audit-form',
  templateUrl: './audit-form.component.html',
  styleUrls: ['./audit-form.component.scss']
})
export class AuditFormComponent implements OnInit {

  public currentTab: string = 'form';
  public viewReady: boolean = false;
  public parentFormGroup!: FormGroup;

  @Input() public formReady: boolean = false;
  @Input() public auditStarted: boolean = true;
  @Input() public audit!: Audits;
  @Input() public scoringCategories: ScoringCategories[] = [];
  @Input() public checkItem: CheckItem[] = [];
  @Input() public zones: Zones[] = [];
  @Input() public zoneCategories: ZoneCategories[] = [];
  @Input() public scores: Scores[] = [];
  @Input() public editMode: boolean = false;
  @Input() public matchingZones: Zones[] = [];
  @Input() public scoringCriteria: ScoringCriteria[] = [];
  @Input() public resources: Resources[] = [];
  
  public numberArray: Number[] = returnNumArray()
  public date: Date | string = new Date().toLocaleString();
  public index: number = 0;
  public comments: string[] = [];
  public selectedZoneCategory_ID!: number;

  constructor(private controlContainer: ControlContainer,
    private auditService: AuditService,
    private scoreService: ScoresService,
    private toastr: ToastrService,
    private resourcesService: ResourcesService,
    private router: Router
  ) {
    console.log(this.scoringCategories)
  }

  async ngOnInit() {
    this.parentFormGroup = this.controlContainer.control as FormGroup;
    this.viewReady = true;
  }

  //Manager for navigating different scoring categories using a class index and boolean param
  public async collectionManager(input: boolean){
    await this.saveScores();
    if (input) {
      this.index--;
      this.updateScoreFields();
      return;
    }
    this.index++;
    this.scores.find(x => x.scoreCategory_ID == this.scoringCategories[this.index].id)?.comments
    this.updateScoreFields();
  }

  //Save scores method that creates a new score if needed, else grabs the existing one and updates it
  public async saveScores() {
    if (this.parentFormGroup.controls['scoreControl'].value == null){
      return;
    }

    let score = this.initializeNewScore();

    if (this.scores.find(x => x.scoreCategory_ID == this.scoringCategories[this.index].id) != null){
      score = this.scores.find(x => x.scoreCategory_ID == this.scoringCategories[this.index].id)!
    } 

    if (this.parentFormGroup.controls['scoreControl'].value != null){
      score.score = this.parentFormGroup.controls['scoreControl'].value
    }

    if (this.parentFormGroup.controls['commentsControl'].value != null && this.parentFormGroup.controls['commentsControl'].value.trim() != ''){
      score.comments = this.parentFormGroup.controls['commentsControl'].value
    }

    if (score.score != null){
      console.log(score);
      let res = await this.scoreService.UpsertScores(score);
      if (res > 0){
        score.id = res;
        if (this.scores.find(x => x.id == score.id) == null){
          this.scores.push(score)
        }
      }
    }
  }


  //Method that updates the scores fields if the score exists, else clears it for new entries
  public updateScoreFields(){
    if (this.scores.find(x => x.scoreCategory_ID == this.scoringCategories[this.index].id) != null){
      this.parentFormGroup.controls['commentsControl'].setValue(this.scores.find(x => x.scoreCategory_ID == this.scoringCategories[this.index].id)?.comments)
      this.parentFormGroup.controls['scoreControl'].setValue(this.scores.find(x => x.scoreCategory_ID == this.scoringCategories[this.index].id)?.score)
      return;
    }
    clearScoreForm(this.parentFormGroup)
  }

  //Styling removing method (may or may not be kept)
  public removeSelectionStyle(id: string){
    let selection = document.getElementById(id);
    selection.classList.remove("is-invalid")
  }

  //Zone updating method for zone categories based on form zone cat input
  public updateZoneCategory(){
    this.matchingZones = this.zones.filter(x => x.zoneCategory_ID == this.parentFormGroup.controls['zoneCategoryControl'].value);
    this.parentFormGroup.controls['zoneControl'].enable();
  }

  //Method to create and return a new score object
  public initializeNewScore(): Scores{
    let score: Scores = {
      audit_ID: this.audit.id!,
      comments: null,
      id: 0,
      score: 0,
      scoreCategory_ID: this.scoringCategories[this.index].id,
      isDeleted: false
    };
    return score
  }

  //method to create new audit record and navigate to scoring form
  public async startAudit() {
    console.log(this.parentFormGroup.controls['zoneControl'].value)
    if (this.parentFormGroup.controls['zoneControl'].value != '') {

      let auditNumber: number = await this.auditService.GetAuditNumber();
      const currentDate = new Date().getFullYear().toString().slice(-2);

      let audit: Audits = {
        id: 0,
        auditStatus_ID: 1, 
        employee_ID: 999,
        dateStarted: new Date(),
        zone_ID: parseInt(this.parentFormGroup.controls['zoneControl'].value),
        dateCompleted: null,
        notes: null,
        overallScore: 0,
        isDeleted: false,
        auditNumber: `${currentDate}-${auditNumber}`
      }

      try {
        const response = await this.auditService.UpsertAudits(audit);
        audit.id = response;
        this.audit = audit;
        this.proceedToScores();
        this.toastr.success("Audit Started");
        await this.auditService.SetAuditNumber(auditNumber + 1);
        return;
      } catch (error) {
        this.toastr.error("There was an error starting the audit.");
        console.log(error);
      }
    }

    this.toastr.error("Please select a zone to proceed")
  }

  //simple method to flip forms
  public proceedToScores(){
    this.auditStarted = false;
    this.formReady = true;
  }

  //Simple audit score submission, notifier and navigator
  public async submitAudit() {
    await this.saveScores();
    await this.sumAuditScores();
    await this.updateAuditStatus();
    this.toastr.success("Audit successfully updated");
    this.router.navigate(['home']);
  }

  //Check the criteria to update the status of the audit
  public async updateAuditStatus() {
    //We start with the status being complete and lower it if needed
    let tempStatus_ID = 3;

    if (this.audit.id) {
      let resources: Resources[] = await this.resourcesService.getResources(this.audit.id);
      console.log(resources);
      console.log(this.scores);

      if (this.scores.length < 5) {
        //If there isn't 5 scores filled in we know to just exit as incomplete
        tempStatus_ID = 1;
      }
      else {
        for (let score of this.scores) {
          //If any score is null it's just automatically incomplete
          if (score.score == null) {
            tempStatus_ID = 1;
            break;
          }
          //If score isn't perfect, we check if there's a before photo for it
          if (score.score < 5) {
            if (resources.some(resource => resource.score_ID == score.scoreCategory_ID && resource.isDeleted == false && resource.isAfter == false )) {
              //Then, we check if there's an after photo, and if not, we set the StatusID to 2
              if (!resources.some(resource => resource.score_ID == score.scoreCategory_ID && resource.isDeleted == false && resource.isAfter == true )) {
                tempStatus_ID = 2;
              }
            }
            else {
              //If there's no before photo, StatusID is set to 1 and we exit the loop so it isn't overwritten
              tempStatus_ID = 1;
              break;
            }
          }
        }
      }
      
    }

    console.log("Status after checks: " + tempStatus_ID);

    if (tempStatus_ID != this.audit.auditStatus_ID) {
      this.audit.auditStatus_ID = tempStatus_ID;

      let response = await this.auditService.UpsertAudits(this.audit);
      
      if (response > 0) {
        console.log("Updated Status to: " + tempStatus_ID);
      }
    }

  }

  public async ngOnDestroy() {
    await this.sumAuditScores();
    await this.updateAuditStatus();
  }

  public async sumAuditScores() {
    let overallScore = 0;
    console.log(this.scores);
    for (let score of this.scores) {

      overallScore += Number(score.score);
    }

    if (this.scores.length == 5){
      this.audit.auditStatus_ID = 3;
    }

    this.audit.overallScore = overallScore;
    await this.auditService.UpsertAudits(this.audit);
  }

}