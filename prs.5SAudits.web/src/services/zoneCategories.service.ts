import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { ZoneCategories } from 'src/models/ZoneCategories';

@Injectable({
  providedIn: 'root'
})

export class ZoneCategoriesService {

  constructor(private sharedService: SharedService) {

  }

  public GetZoneCategories(){
    return this.sharedService.get(`ZoneCategories/GetZoneCategories`);
  }

  public UpsertZoneCategories(zoneCategories: ZoneCategories){
    return this.sharedService.upsert(`ZoneCategories/UpsertZoneCategorie`, zoneCategories);
  }
  
}
