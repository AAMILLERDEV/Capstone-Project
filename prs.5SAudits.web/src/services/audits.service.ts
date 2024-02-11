import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Audits } from 'src/models/Audits';

@Injectable({
  providedIn: 'root'
})

export class AuditService {

  constructor(private sharedService: SharedService) {

  }

  public GetAudits(){
    return this.sharedService.get(`Audit/GetAudits`);
  }

  public GetAuditByID(audit_ID: number){
    return this.sharedService.get(`Audit/GetAuditByID/${audit_ID}`);
  }

  public UpsertAudit(audit: Audits){
    return this.sharedService.upsert(`Audit/UpsertAudit`, audit);
  }
  
}
