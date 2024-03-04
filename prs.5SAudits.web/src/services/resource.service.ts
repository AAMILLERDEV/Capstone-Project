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
    return this.sharedService.get(`Resources/GetResources/${audit_ID}`);
  }

  public upsertResources(resource: Resources){
    return this.sharedService.upsert(`Resources/UpsertResources`, resource);
  }

}
