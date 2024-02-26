import { Component, OnInit } from '@angular/core';
import { Audits } from 'src/models/Audits';
import { AuditService } from 'src/services/audits.service';
import { formatDate } from '../sharedUtils';
import { ZonesService } from 'src/services/zones.service';
import { Zones } from 'src/models/Zones';
import { Scores } from 'src/models/Scores';
import { ScoresService } from 'src/services/scores.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public auditsListing: Audits[] = [];
  public filteredAudits: Audits[] = [];

  public viewReady: boolean = false;

  constructor(private auditService: AuditService,
    private scoresServices: ScoresService,
    private zonesSerivce: ZonesService) {

  }

  async ngOnInit() {

    this.auditsListing = await this.auditService.GetAudits();
    let zones: Zones[] = await this.zonesSerivce.GetZones();

    this.auditsListing.map(async x => {
      x.zoneName = zones.find(y => y.id == x.zone_ID)?.zoneName

      if (x.id != null) {
        x.overallScore = await this.sumAuditScores(x.id);
      }

    });

    this.filteredAudits = this.auditsListing;

    this.viewReady = true;

  }

  async sumAuditScores(id: number) {
    let overallScore = 0;

    let thisAuditScores = await this.scoresServices.GetScoresByAudit(id);

    for (let score of thisAuditScores) {
       overallScore += score.score;
    }

    return overallScore;
  }

  dateFormatter(val: string | Date){
    return formatDate(val)
  }

  filterByZone(val: string){
    this.filteredAudits = this.auditsListing.filter(x => x.zoneName!.toLowerCase().includes(val.toLowerCase()));
  }

  filterByAuditNumber(val: string){
    console.log(val)
    this.filteredAudits = this.auditsListing.filter(x => x.id! == parseInt(val));

    if (val == ''){
      this.filteredAudits = this.auditsListing;
    }
  }

}
