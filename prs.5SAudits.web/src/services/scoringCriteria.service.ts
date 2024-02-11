import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { ScoringCriteria } from 'src/models/ScoringCriteria';

@Injectable({
  providedIn: 'root'
})

export class ScoringCriteriaService {

  constructor(private sharedService: SharedService) {

  }

  public GetScoringCriteria(){
    return this.sharedService.get(`ScoringCriteria/GetScoringCriteria`);
  }

  public UpsertScoringCriteria(ins: ScoringCriteria){
    return this.sharedService.upsert(`ScoringCriteria/UpsertScoringCriteria`, ins);
  }
  
}
