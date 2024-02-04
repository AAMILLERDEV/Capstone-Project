import { Component, OnInit } from '@angular/core';
import { Settings } from 'src/models/Settings';
import { SettingsService } from 'src/services/settings.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public settings: Settings[] = [];

  public viewReady: boolean = false;

  constructor(private settingsService: SettingsService) {

  }

  async ngOnInit() {

    this.settings = await this.settingsService.getSettings();
    
    for (let i = 0; i < 5; i++){
      let originalSettings = this.settings[0];
      let copy = {...originalSettings};
      this.settings.push(copy)
      console.log(i)
    }

    this.viewReady = true;

  }

}
