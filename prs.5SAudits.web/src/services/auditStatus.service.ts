import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { AuditStatus } from 'src/models/AuditStatus';

@Injectable({
  providedIn: 'root'
})

export class AuditStatusService {

  constructor(private sharedService: SharedService) {

  }

  public GetAuditStatuses(){
    return this.sharedService.get(`AuditStatus/GetAuditStatuses`);
  }

  public UpsertAuditStatus(auditStatus: AuditStatus){
    return this.sharedService.upsert(`Actions/UpsertAuditStatus`, auditStatus);
  }
  
}
