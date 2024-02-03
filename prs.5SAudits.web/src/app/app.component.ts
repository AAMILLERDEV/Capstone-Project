import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private title: Title) {
    title.setTitle("PRS | 5S Audits")
  }
  ngOnInit() {
    
  }

  
}
