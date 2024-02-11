import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { ScoringCategories } from 'src/models/ScoringCategories';

@Injectable({
  providedIn: 'root'
})

export class ScoringCategoriesService {

  constructor(private sharedService: SharedService) {

  }

  public getScoringCategories(){
    return this.sharedService.get(`ScoringCategories/GetScoringCategories`);
  }

  public upsertScoringCategories(scoringCategories: ScoringCategories){
    return this.sharedService.upsert(`ScoringCategories/UpsertScoringCategories`, scoringCategories);
  }
  
}
