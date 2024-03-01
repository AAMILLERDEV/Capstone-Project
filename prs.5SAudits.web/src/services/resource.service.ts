import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { CheckItem } from 'src/models/CheckItem';
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

  public upsertResource(resource: Resources){
    return this.sharedService.upsert(`Resources/UpsertResource`, resource);
  }
  
}
