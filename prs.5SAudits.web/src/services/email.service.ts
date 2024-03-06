import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Deductions } from 'src/models/Deductions';
import { Email } from 'src/models/Email';

@Injectable({
  providedIn: 'root'
})

export class EmailService {

  constructor(private sharedService: SharedService) {

  }

  public SendEmail(email: Email){
    return this.sharedService.upsert(`Email/SendEmail`, email);
  }
  
}
