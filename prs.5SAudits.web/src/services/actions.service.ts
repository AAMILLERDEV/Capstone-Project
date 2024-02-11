import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Actions } from 'src/models/Actions';

@Injectable({
  providedIn: 'root'
})

export class ActionsService {

  constructor(private sharedService: SharedService) {

  }

  public GetActions(){
    return this.sharedService.get(`Actions/GetActions`);
  }

  public UpsertActions(actions: Actions){
    return this.sharedService.upsert(`Actions/UpsertActions`, actions);
  }
  
}
