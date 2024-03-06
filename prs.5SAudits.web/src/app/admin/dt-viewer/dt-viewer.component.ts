import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { AuditService } from 'src/services/audits.service';
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

  constructor(private activatedRoute: ActivatedRoute,
    private auditService: AuditService,
    private zoneService: ZonesService,
    private zoneCategoryService: ZoneCategoriesService) {

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
        this.dtReady = true
        break;
      }
      case "zones": {
        this.tableData = await this.zoneService.GetZones()
        this.dtReady = true
        break;
      }
      case "zoneCategories": {
        this.tableData = await this.zoneCategoryService.GetZoneCategories()
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



}
