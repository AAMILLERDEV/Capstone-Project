import { Component, Input, OnInit } from '@angular/core';
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

  public numberArray: Number[] = returnNumArray()
  public date: Date | string = new Date().toLocaleString();
  public index: number = 0;
  public comments: string[] = [];
  public selectedZoneCategory_ID!: number;

  constructor(private controlContainer: ControlContainer,
    private auditService: AuditService,
    private scoreService: ScoresService,
    private toastr: ToastrService,
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
      let res = await this.scoreService.UpsertScores(score);
      if (res > 0){
        score.id = res;
        this.scores.push(score)
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
      scoreCategory_ID: this.scoringCategories[this.index].id
    };
    return score
  }

  //method to create new audit record and navigate to scoring form
  public async startAudit() {
    console.log(this.parentFormGroup.controls['zoneControl'].value)
    if (this.parentFormGroup.controls['zoneControl'].value != '') {
      let audit: Audits = {
        id: 0,
        auditStatus_ID: 1, 
        employee_ID: 999,
        dateStarted: new Date(),
        zone_ID: parseInt(this.parentFormGroup.controls['zoneControl'].value),
        dateCompleted: null,
        notes: null,
        overallScore: 0
      }

      try {
        const response = await this.auditService.UpsertAudits(audit);
        audit.id = response;
        this.audit = audit;
        this.proceedToScores();
        this.toastr.success("Audit Started");
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
    this.toastr.success("Audit successfully updated");
    this.router.navigate(['home']);
  }
}