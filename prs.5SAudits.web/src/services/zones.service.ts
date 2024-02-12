import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Zones } from 'src/models/Zones';

@Injectable({
  providedIn: 'root'
})

export class ZonesService {

  constructor(private sharedService: SharedService) {

  }

  public GetZones(){
    return this.sharedService.get(`Zones/GetZones`);
  }

  public UpsertZones(zones: Zones){
    return this.sharedService.upsert(`Zones/UpsertZones`, zones);
  }
  
}