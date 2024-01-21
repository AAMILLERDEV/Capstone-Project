import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Settings } from 'src/models/Settings';

@Injectable({
  providedIn: 'root'
})

export class SettingsService {

  constructor(private sharedService: SharedService) {

  }

  public getSettings(){
    return this.sharedService.get(`Settings/GetSettings`);
  }

  public upsertSettings(settings: Settings){
    return this.sharedService.upsert(`Settings/UpsertSettings`, settings);
  }
  
}
