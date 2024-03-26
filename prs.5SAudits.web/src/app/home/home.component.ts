import { Component, OnInit } from '@angular/core';
import { Audits } from 'src/models/Audits';
import { AuditService } from 'src/services/audits.service';
import { formatDate } from '../sharedUtils';
import { ZonesService } from 'src/services/zones.service';
import { Zones } from 'src/models/Zones';
import { Scores } from 'src/models/Scores';
import { ScoresService } from 'src/services/scores.service';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { AuditStatusService } from 'src/services/auditStatus.service';
import { AuditStatus } from 'src/models/AuditStatus';
import { FormGroup } from '@angular/forms';
import { FilterForm } from 'src/form-models/FilterForm';
import { AuditLog } from 'src/models/AuditLog';
import { AuditLogService } from 'src/services/auditLog.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public auditsListing: Audits[] = [];
  public filteredAudits: Audits[] = [];
  public auditStatuses: AuditStatus[] = [];
  public filterForm!: FormGroup;
  public loggedAuditNumber: number = 0;
  public auditNumber?: string = "";
  public filterList: string[][] = [];

  public viewReady: boolean = false;

  constructor(private auditService: AuditService,
    private scoresService: ScoresService,
    private zonesSerivce: ZonesService,
    private zoneCategoryService: ZoneCategoriesService,
    private auditStatusService: AuditStatusService,
    private auditLogService: AuditLogService) {
      this.filterForm = FilterForm
  }

  async ngOnInit() {
    this.auditStatuses = await this.auditStatusService.GetAuditStatuses()
    this.auditsListing = await this.auditService.GetAudits()
    let zones: Zones[] = await this.zonesSerivce.GetZones()
    let zoneCategories: ZoneCategories[] = await this.zoneCategoryService.GetZoneCategories()

    this.loggedAuditNumber = (await this.auditLogService.GetAuditLog(999)).previousAudit_ID;
    
    this.auditsListing.map(async x => {
      x.zoneName = zones.find(y => y.id == x.zone_ID)?.zoneName;
      x.zoneCategoryName = zoneCategories.find(y => y.id == zones.find(z => z.id == x.zone_ID)?.zoneCategory_ID)?.categoryName
      x.targetScore = zoneCategories.find(y => y.id == zones.find(z => z.id == x.zone_ID)?.zoneCategory_ID)?.target
    });

    this.filteredAudits = this.auditsListing;

    if (this.loggedAuditNumber != 0){
      this.auditNumber = this.filteredAudits.find(x => x.id == this.loggedAuditNumber)?.auditNumber;
    }

    this.viewReady = true;

  }

  dateFormatter(val: string | Date){
    return formatDate(val)
  }

  public recordSearch(key: string, val: string){
    this.filteredAudits = [...this.auditsListing];


    if (this.filterList.find(x => x[0] == key) == null){
      this.filterList.push([key, val])
    } else {
      let i = this.filterList.findIndex(x => x[0] == key)
      this.filterList[i] = [key, val]
    }


    for (let x of this.filterList){
      this.filteredAudits = this.filteredAudits.filter(y => (y[x[0] as keyof Audits]!.toString()).toLowerCase().includes((x[1] as string).toLowerCase()))
    }

    if (val == "" && !this.filterList.length){
      this.filteredAudits = [...this.auditsListing];
    }
  }


  filterByZone(val: string){
    this.filteredAudits = this.auditsListing.filter(x => x.zoneName!.toLowerCase().includes(val.toLowerCase()))
  }

  filterByAuditNumber(val: string){
    this.filteredAudits = this.auditsListing.filter(x => x.auditNumber.includes(val))
    if (val == ''){
      this.filteredAudits = this.auditsListing
    }
  }

  filterByZoneCategory(val: string){
    this.filteredAudits = this.auditsListing.filter(x => x.zoneCategoryName!.toLowerCase().includes(val.toLowerCase()))
    if (val == ''){
      this.filteredAudits = this.auditsListing
    }
  }

  filterByAuditStatus(val: string){
    this.filteredAudits = this.auditsListing.filter(x => x.auditStatus_ID == parseInt(val))
    if (val == ''){
      this.filteredAudits = this.auditsListing
    }
  }

  public resetFilters(){
    this.filterForm.reset();
    this.filteredAudits = this.auditsListing;
  }

}
