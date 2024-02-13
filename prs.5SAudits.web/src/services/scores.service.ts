import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Scores } from 'src/models/Scores';

@Injectable({
  providedIn: 'root'
})

export class ScoresService {

  constructor(private sharedService: SharedService) {

  }

  public GetScores(){
    return this.sharedService.get(`Scores/GetScores`);
  }

  public GetScoresByAudit(audit_ID: number){
    return this.sharedService.get(`Scores/GetScoresByAuditID/${audit_ID}`);
  }

  public UpsertScores(scores: Scores){
    return this.sharedService.upsert(`Scores/UpsertScores`, scores);
  }
  
}
