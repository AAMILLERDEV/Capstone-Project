import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { CheckItem } from 'src/models/CheckItem';

@Injectable({
  providedIn: 'root'
})

export class CheckItemService {

  constructor(private sharedService: SharedService) {

  }

  public getCheckItem(){
    return this.sharedService.get(`CheckItem/GetCheckItem`);
  }

  public upsertCheckItem(checkItem: CheckItem){
    return this.sharedService.upsert(`CheckItem/UpsertCheckItem`, checkItem);
  }
  
}
