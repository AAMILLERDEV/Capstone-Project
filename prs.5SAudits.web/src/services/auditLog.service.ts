import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { AuditLog } from 'src/models/AuditLog';

@Injectable({
  providedIn: 'root'
})

export class AuditLogService {

  constructor(private sharedService: SharedService) {

  }

  public GetAuditLog(employee_ID: number): Promise<AuditLog>{
    return this.sharedService.get(`AuditLog/GetAuditLog/${employee_ID}`);
  }

  public UpsertAuditLog(auditLog: AuditLog){
    return this.sharedService.upsert(`AuditLog/UpsertAuditLog`, auditLog);
  }
  
}
