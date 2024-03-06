import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { clearAuditForm, clearScoreForm, setFormForEditAudit } from 'src/app/sharedUtils';
import { AuditForm } from 'src/form-models/AuditForm';
import { Audits } from 'src/models/Audits';
import { CheckItem } from 'src/models/CheckItem';
import { Resources } from 'src/models/Resources';
import { Scores } from 'src/models/Scores';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { ScoringCriteria } from 'src/models/ScoringCriteria';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { Zones } from 'src/models/Zones';
import { AuditService } from 'src/services/audits.service';
import { CheckItemService } from 'src/services/checkItem.service';
import { ResourcesService } from 'src/services/resource.service';
import { ScoresService } from 'src/services/scores.service';
import { ScoringCategoriesService } from 'src/services/scoringCategories.service';
import { ScoringCriteriaService } from 'src/services/scoringCriteria.service';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';
import { ZonesService } from 'src/services/zones.service';

@Component({
  selector: 'app-edit-audit-form',
  templateUrl: './edit-audit-form.component.html',
  styleUrls: ['./edit-audit-form.component.scss']
})
export class EditAuditFormComponent implements OnInit {

  public scoringCategories: ScoringCategories[] = [];
  public checkItem: CheckItem[] = [];
  public zones: Zones[] = [];
  public zoneCategories: ZoneCategories[] = [];
  public scores: Scores[] = [];
  public audit!: Audits;
  public scoringCriteria: ScoringCriteria[] = [];

  public auditForm: FormGroup;
  public viewReady: boolean = false;

  constructor(private scoringCategoriesService: ScoringCategoriesService,
    private checkItemService: CheckItemService,
    private zonesService: ZonesService,
    private zoneCategoriesService: ZoneCategoriesService,
    private router: Router,
    private actRoute: ActivatedRoute,
    private auditService: AuditService,
    private scoringCriteriaService: ScoringCriteriaService,
    private scoreService: ScoresService,
    private resourcesService: ResourcesService){
    this.auditForm = AuditForm;
  }
  
  async ngOnInit() {
    let id = 0;
    this.actRoute.params.subscribe(async (params: Params) => {
      id = params["id"];
    })

    try {
      await this.getData(id);
      this.setForm();
      this.viewReady = true;
    } catch (error){
      console.log(error)
      this.router.navigateByUrl('/home')
    }
  }

  public async getData(id: number){
    this.audit = await this.auditService.GetAuditByID(id);
    this.scores = await this.scoreService.GetScoresByAudit(id);
    this.scoringCategories = await this.scoringCategoriesService.getScoringCategories();
    this.checkItem = await this.checkItemService.getCheckItem();
    this.zoneCategories = await this.zoneCategoriesService.GetZoneCategories();
    this.zones = await this.zonesService.GetZones();
    this.zones = this.zones.filter(x => x.zoneCategory_ID == this.zones.find(y => y.id == this.audit.zone_ID)?.zoneCategory_ID)
    this.scoringCategories.map(x => {
      x.score = this.scores.find(y => y.scoreCategory_ID == x.id)
    })

    this.scoringCriteria = await this.scoringCriteriaService.GetScoringCriteria();

  }

  public setForm(){
    setFormForEditAudit(this.auditForm)
    clearScoreForm(this.auditForm)
    clearAuditForm(this.auditForm)
    this.auditForm.controls['auditNumberControl'].setValue(this.audit.auditNumber)
    this.auditForm.controls['employeeNameControl'].setValue("Miller, Aaron")
    this.auditForm.controls['zoneCategoryControl'].setValue(this.zoneCategories.find(x => x.id == this.zones.find(y => y.id == this.audit.zone_ID)?.zoneCategory_ID)?.id)
    this.auditForm.controls['zoneControl'].setValue(this.audit.zone_ID)
    console.log(this.audit)
    if (this.scores.find(x => x.scoreCategory_ID == 1) != null){
      this.auditForm.controls['scoreControl'].setValue(this.scores.find(x => x.scoreCategory_ID == 1)?.score)
      this.auditForm.controls['commentsControl'].setValue(this.scores.find(x => x.scoreCategory_ID == 1)?.comments)
    }
  }

}