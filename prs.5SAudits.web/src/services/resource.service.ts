import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Resources } from 'src/models/Resources';

@Injectable({
  providedIn: 'root'
})

export class ResourcesService {

  constructor(private sharedService: SharedService) {

  }

  public getResources(audit_ID: number){
    return this.sharedService.get(`Resources/GetResourcesByAuditId/${audit_ID}`);
  }

  public upsertResources(resource: Resources){
    return this.sharedService.upsert(`Resources/UpsertResources`, resource);
  }

  public deleteResource(resource_ID: number){
    return this.sharedService.delete(`Resources/DeleteResource/${resource_ID}`);
  }

}
