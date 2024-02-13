import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { clearAuditForm, clearScoreForm, setFormForNewAudit } from 'src/app/sharedUtils';
import { AuditForm } from 'src/form-models/AuditForm';
import { CheckItem } from 'src/models/CheckItem';
import { ScoringCategories } from 'src/models/ScoringCategories';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { Zones } from 'src/models/Zones';
import { CheckItemService } from 'src/services/checkItem.service';
import { ScoringCategoriesService } from 'src/services/scoringCategories.service';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';
import { ZonesService } from 'src/services/zones.service';

@Component({
  selector: 'app-new-audit-form',
  templateUrl: './new-audit-form.component.html',
  styleUrls: ['./new-audit-form.component.scss']
})
export class NewAuditFormComponent implements OnInit {

  public scoringCategories: ScoringCategories[] = [];
  public checkItem: CheckItem[] = [];
  public zones: Zones[] = [];
  public zoneCategories: ZoneCategories[] = [];

  public auditForm: FormGroup;
  public viewReady: boolean = false;

  constructor(private scoringCategoriesService: ScoringCategoriesService,
    private checkItemService: CheckItemService,
    private zonesService: ZonesService,
    private zoneCategoriesService: ZoneCategoriesService,
    private router: Router){
    this.auditForm = AuditForm;
  }

  async ngOnInit() {
    try {
      this.setForm();
      await this.getData();
      this.viewReady = true;
    } catch (error){
      console.log(error)
      this.router.navigateByUrl('home')
    }

  }

  public async getData(){
    this.scoringCategories = await this.scoringCategoriesService.getScoringCategories();
    this.checkItem = await this.checkItemService.getCheckItem();
    this.zones = await this.zonesService.GetZones();
    this.zoneCategories = await this.zoneCategoriesService.GetZoneCategories();
  }

  public setForm(){
    clearScoreForm(this.auditForm)
    clearAuditForm(this.auditForm)
    setFormForNewAudit(this.auditForm)
    this.auditForm.controls['auditNumberControl'].setValue("TEST")
    this.auditForm.controls['employeeNameControl'].setValue("Miller, Aaron")
  }

}
