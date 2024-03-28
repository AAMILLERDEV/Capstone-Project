import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Audits } from 'src/models/Audits';
import { AuditService } from 'src/services/audits.service';
import { EventLogsService } from 'src/services/eventLogs.service';
import { ScoringCriteriaService } from 'src/services/scoringCriteria.service';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';
import { ZonesService } from 'src/services/zones.service';
import * as bootstrap from 'bootstrap';
import { DeletedAudit } from 'src/models/DeletedAudits';
import { FormGroup } from '@angular/forms';
import { DeletionForm, ScoringCriteriaForm, ZoneCategoryForm, ZonesForm } from 'src/form-models/ModalForms';
import { ToastrService } from 'ngx-toastr';
import { ZoneCategories } from 'src/models/ZoneCategories';
import { Zones } from 'src/models/Zones';

@Component({
  selector: 'app-dt-viewer',
  templateUrl: './dt-viewer.component.html',
  styleUrls: ['./dt-viewer.component.scss']
})
export class DtViewerComponent implements OnInit {

  public tableData: any[] = [];

  public dtReady: boolean = false; 

  public deleteModal!: bootstrap.Modal;
  public zonesModal!: bootstrap.Modal;
  public zoneCategoriesModal!: bootstrap.Modal;
  public scoringCriteriaModal!: bootstrap.Modal;

  public allowDelete: boolean = false;
  public allowEdit: boolean = false;
  public allowAdd: boolean = false;

  public deletionForm: FormGroup;
  public zoneForm: FormGroup;
  public zoneCategoryForm: FormGroup;
  public scoringCriteriaForm: FormGroup;

  public zoneCategories: ZoneCategories[] = [];

  public selectedRecord: any;
  public tableKey: (string|number)[] = ["", 0];

  constructor(private activatedRoute: ActivatedRoute,
    private auditService: AuditService,
    private zoneService: ZonesService,
    private zoneCategoryService: ZoneCategoriesService,
    private eventLogService: EventLogsService,
    private scoringCriteriaService: ScoringCriteriaService,
    private toastrService: ToastrService) {
      this.deletionForm = DeletionForm;
      this.zoneForm = ZonesForm;
      this.zoneCategoryForm = ZoneCategoryForm;
      this.scoringCriteriaForm = ScoringCriteriaForm;
  }

  ngOnInit(): void {
    try {
      this.routeGrabber();
      this.deleteModal = bootstrap.Modal.getOrCreateInstance('#deleteModal', {keyboard: true});
      this.zonesModal = bootstrap.Modal.getOrCreateInstance('#zonesModal', {keyboard: true});
      this.zoneCategoriesModal = bootstrap.Modal.getOrCreateInstance('#zoneCategoriesModal', {keyboard: true});
      this.scoringCriteriaModal = bootstrap.Modal.getOrCreateInstance('#scoringCriteriaModal', {keyboard: true});

    } catch (error){
      console.log(error)
    }

  }

  refresh(){

  }

  private async routeGrabber(){
    let dtType = this.activatedRoute.params.subscribe((x: Params) => {
      let param = x['view'];
      this.dataInitializer(param);
    })
  }

  private async dataInitializer(route: string){
    switch(route) {
      case "audits": {
        this.tableData = await this.auditService.GetAudits()
        this.allowDelete = true
        this.dtReady = true
        this.tableKey = ["Audit", 1]
        break;
      }
      case "zones": {
        this.tableData = await this.zoneService.GetZones()
        this.zoneCategories = await this.zoneCategoryService.GetZoneCategories();
        this.allowDelete = true
        this.allowAdd = true
        this.allowEdit = true
        this.dtReady = true
        this.tableKey = ["Zone", 2]
        break;
      }
      case "zoneCategories": {
        this.tableData = await this.zoneCategoryService.GetZoneCategories()
        this.allowAdd = true
        this.allowEdit = true
        this.dtReady = true
        this.tableKey = ["Zone Category", 3]
        break;
      }
      case "systemEvents": {
        this.tableData = await this.eventLogService.getEventLogs()
        this.dtReady = true
        this.tableKey = ["System Event", 4]
        break;
      }
      case "scoringCriteria": {
        this.tableData = await this.scoringCriteriaService.GetScoringCriteria()
        this.allowEdit = true
        this.dtReady = true
        this.tableKey = ["Scoring Criteria", 5]
        break;
      }
      case "deletedAudits": {
        this.tableData = await this.auditService.GetDeletedAudits()
        this.dtReady = true
        this.tableKey = ["Deleted Audits", 6]
        break;
      }
      default: {
        this.tableData = []
        this.dtReady = true
        break;
      }
    }
  }

  public dbRecordHandler(record: any){
    this.selectedRecord = record;
  }

  public closeModals(){
    this.deleteModal.hide();
    this.zonesModal.hide();
    this.zoneCategoriesModal.hide();
    this.scoringCriteriaModal.hide();
  }

  public openModal(editMode: boolean){
    switch(this.tableKey[0]){
      case "Audit":
        break;
      case "Zone":
        if (editMode){
          this.zoneForm.controls['zoneNameControl'].setValue(this.selectedRecord.zoneName)
          this.zoneForm.controls['zoneCategoryControl'].setValue(this.selectedRecord.zoneCategory_ID)
        }
        this.zonesModal.show();
        break;
      case "Zone Category":
        if (editMode){
          this.zoneCategoryForm.controls['categoryNameControl'].setValue(this.selectedRecord.categoryName)
          this.zoneCategoryForm.controls['targetControl'].setValue(this.selectedRecord.target)
        }
        this.zoneCategoriesModal.show();
        break;
      case "System Event":
        break;
      case "Scoring Criteria":
        if (editMode){
          this.scoringCriteriaForm.controls['descriptionControl'].setValue(this.selectedRecord.description)
        }
        this.scoringCriteriaModal.show();
        break;
      default:
        break;
    }
  }

  public openDeleteModal(){
    if (this.selectedRecord == undefined){
      this.toastrService.error("Please select a record first")
      return
    }
    this.deleteModal.show();
  }

  public recordDeletionHandler(){
    switch(this.tableKey[0]){
      case "Audit":

        break;
      case "Zone":
        this.zonesModal.show();
        break;
      case "Zone Category":
        break;
      case "System Event":
        break;
      case "Scoring Criteria":
        break;
      default:
        break;
    }
  }


  public async deleteRecord(){
    this.selectedRecord.isDeleted = true;

    if (this.tableKey[0] == "Audit"){

      if (this.deletionForm.valid){
        let deletedAudit: DeletedAudit = {
          audit_ID: this.selectedRecord.id,
          employee_ID: 999,
          id: 0,
          reason: this.deletionForm.controls['reasonControl'].value
        };
  
        await this.auditService.DeleteAudit(deletedAudit);
        await this.auditService.UpsertAudits(this.selectedRecord);
        this.toastrService.success("Success, audit has been deleted")
        this.deleteModal.hide();
        return;
      }

      this.toastrService.error("Please include a reason")
      return;

    } else if (this.tableKey[0] == "Zone"){
      await this.zoneService.UpsertZones(this.selectedRecord);
    }
    else if (this.tableKey[0] == "Scoring Criteria"){
      await this.scoringCriteriaService.UpsertScoringCriteria(this.selectedRecord);
    }

    this.deleteModal.hide();
  }


  public async upsertRecord(editMode: boolean){
    switch(this.tableKey[0]){
      case "Zone":
        if (editMode){
          this.selectedRecord.zoneName = this.zoneForm.controls['zoneNameControl'].value;
          this.selectedRecord.zoneCategory_ID = this.zoneForm.controls['zoneCategoryControl'].value;
          await this.zoneService.UpsertZones(this.selectedRecord);
          this.toastrService.success(`Zone ${this.selectedRecord.zoneName} has been updated`)
          this.routeGrabber();
          this.closeModals();
          this.zoneForm.reset();
          return;
        }

        let zone: Zones = {
          id: 0,
          zoneCategory_ID: this.zoneForm.controls['zoneCategoryControl'].value,
          zoneName: this.zoneForm.controls['zoneNameControl'].value,
          isDeleted: false
        };
        await this.zoneService.UpsertZones(zone);
        this.toastrService.success(`Zone ${zone.zoneName} has been added`)
        this.routeGrabber();
        this.closeModals();
        this.zoneForm.reset();
        break;

      case "Zone Category":
        if (editMode){
          this.selectedRecord.categoryName = this.zoneCategoryForm.controls['categoryNameControl'].value;
          this.selectedRecord.target = this.zoneCategoryForm.controls['targetControl'].value;
          await this.zoneCategoryService.UpsertZoneCategories(this.selectedRecord);
          this.toastrService.success(`Zone Category ${this.selectedRecord.categoryName} has been updated`)
          this.routeGrabber();
          this.closeModals();
          this.zoneCategoryForm.reset();
          return;
        }

        let zoneCategory: ZoneCategories = {
          id: 0,
          categoryName: this.zoneCategoryForm.controls['categoryNameControl'].value,
          target: this.zoneCategoryForm.controls['targetControl'].value
        };
        await this.zoneCategoryService.UpsertZoneCategories(zoneCategory);
        this.toastrService.success(`Zone Category ${this.selectedRecord.categoryName} has been added`)
        this.routeGrabber();
        this.closeModals();
        this.zoneCategoryForm.reset();
        break;

      case "Scoring Criteria":
        this.selectedRecord.description= this.scoringCriteriaForm.controls['descriptionControl'].value;
        await this.scoringCriteriaService.UpsertScoringCriteria(this.selectedRecord);
        this.toastrService.success(`Scoring Criteria has been updated`)
        this.routeGrabber();
        this.closeModals();
        this.scoringCriteriaForm.reset();
        break;
      default:
        break;
    }
  }


}
