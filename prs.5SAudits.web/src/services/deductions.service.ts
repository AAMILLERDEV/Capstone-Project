import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Deductions } from 'src/models/Deductions';

@Injectable({
  providedIn: 'root'
})

export class DeductionsService {

  constructor(private sharedService: SharedService) {

  }

  public GetDeductions(){
    return this.sharedService.get(`Deductions/GetDeductions`);
  }

  public UpsertDeduction(deductions: Deductions){
    return this.sharedService.upsert(`Deductions/UpsertDeductions`, deductions);
  }
  
}
