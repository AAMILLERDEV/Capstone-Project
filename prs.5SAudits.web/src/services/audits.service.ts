import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Audits } from 'src/models/Audits';
import { DeletedAudit } from 'src/models/DeletedAudits';

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

  public GetDeletedAudits(): Promise<DeletedAudit[]> {
    return this.sharedService.get(`DeletedAudits/GetDeletedAudits`);
  }

  public SetAuditNumber(value: number){
    return this.sharedService.upsert(`Audits/SetAuditNumber/${value}`, null);
  }

  public DeleteAudit(audit: DeletedAudit){
    return this.sharedService.upsert(`DeletedAudits/InsertDeletedAudit`, audit)
  }
  
}
