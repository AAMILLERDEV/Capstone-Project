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
    return this.sharedService.get(`Audits/GetAudits`);
  }

  public GetAuditByID(audit_ID: number){
    return this.sharedService.get(`Audits/GetAuditByID/${audit_ID}`);
  }

  public UpsertAudits(audit: Audits){
    return this.sharedService.upsert(`Audits/UpsertAudits`, audit);
  }

  public GetAuditNumber(): Promise<number> {
    return this.sharedService.get(`Audits/GetAuditNumber`);
  }

  public SetAuditNumber(value: number){
    return this.sharedService.upsert(`Audits/SetAuditNumber/${value}`, null);
  }
  
}
