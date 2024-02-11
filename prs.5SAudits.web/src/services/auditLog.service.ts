import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { AuditLog } from 'src/models/AuditLog';

@Injectable({
  providedIn: 'root'
})

export class AuditLogService {

  constructor(private sharedService: SharedService) {

  }

  public GetAuditLog(){
    return this.sharedService.get(`AuditLog/GetAuditLog`);
  }

  public UpsertAuditLog(auditLog: AuditLog){
    return this.sharedService.upsert(`AuditLog/UpsertAuditLog`, auditLog);
  }
  
}
