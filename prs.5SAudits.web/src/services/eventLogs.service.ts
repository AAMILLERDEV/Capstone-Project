import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { EventLogs } from 'src/models/EventLogs';

@Injectable({
  providedIn: 'root'
})

export class EventLogsService {

  constructor(private sharedService: SharedService) {

  }

  public getEventLogs(){
    return this.sharedService.get(`EventLogs/GetEventLogs`);
  }

  public upsertEventLogs(eventLogs: EventLogs){
    return this.sharedService.upsert(`EventLogs/UpsertEventLogs`, eventLogs);
  }
  
}
