import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Audits } from 'src/models/Audits';
import { AuditService } from 'src/services/audits.service';
import { EventLogsService } from 'src/services/eventLogs.service';
import { ZoneCategoriesService } from 'src/services/zoneCategories.service';
import { ZonesService } from 'src/services/zones.service';

@Component({
  selector: 'app-dt-viewer',
  templateUrl: './dt-viewer.component.html',
  styleUrls: ['./dt-viewer.component.scss']
})
export class DtViewerComponent implements OnInit {

  public tableData: any[] = [];

  public dtReady: boolean = false; 

  public allowDelete: boolean = false;
  public allowEdit: boolean = false;
  public allowAdd: boolean = false;

  constructor(private activatedRoute: ActivatedRoute,
    private auditService: AuditService,
    private zoneService: ZonesService,
    private zoneCategoryService: ZoneCategoriesService,
    private eventLogService: EventLogsService) {

  }

  ngOnInit(): void {
    try {
      this.routeGrabber();
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
        break;
      }
      case "zones": {
        this.tableData = await this.zoneService.GetZones()
        this.allowDelete = true
        this.allowAdd = true;
        this.allowEdit = true;
        this.dtReady = true
        break;
      }
      case "zoneCategories": {
        this.tableData = await this.zoneCategoryService.GetZoneCategories()
        this.allowDelete = true
        this.allowAdd = true;
        this.allowEdit = true;
        this.dtReady = true
        break;
      }
      case "systemEvents": {
        this.tableData = await this.eventLogService.getEventLogs()
        this.dtReady = true
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

  }



}
