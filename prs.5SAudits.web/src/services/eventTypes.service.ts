import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { EventTypes } from 'src/models/EventTypes';

@Injectable({
  providedIn: 'root'
})

export class EventTypesService {

  constructor(private sharedService: SharedService) {

  }

  public getEventTypes(){
    return this.sharedService.get(`EventTypes/GetEventTypes`);
  }

  public upsertEventTypes(eventTypes: EventTypes){
    return this.sharedService.upsert(`EventTypes/UpsertEventTypes`, eventTypes);
  }
  
}
