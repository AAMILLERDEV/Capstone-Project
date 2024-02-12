import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
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

  constructor(private scoringCategoriesService: ScoringCategoriesService,
    private checkItemService: CheckItemService,
    private zonesService: ZonesService,
    private zoneCategoriesService: ZoneCategoriesService){
    this.auditForm = AuditForm;
  }

  async ngOnInit() {

    this.auditForm.controls['auditNumberControl'].disable();
    this.auditForm.controls['employeeNameControl'].disable();

    this.scoringCategories = await this.scoringCategoriesService.getScoringCategories();
    console.log(this.scoringCategories);

    this.checkItem = await this.checkItemService.getCheckItem();
    console.log(this.checkItem);

    this.zones = await this.zonesService.GetZones();
    console.log(this.zones);

    this.zoneCategories = await this.zoneCategoriesService.GetZoneCategories();
    console.log(this.zoneCategories);
    
  }

  public async getData(){
    
  }

}
