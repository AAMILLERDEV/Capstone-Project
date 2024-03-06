import { KeyValuePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss'],
  providers: [KeyValuePipe]
})
export class DatatableComponent implements OnInit {

  @Input() public tableData: any[] = [];

  public dtData: any[] = [];

  public keyList: string[][] = [];
  public dtReady: boolean = false;
  public currentPage: number = 1;
  public itemsPerPage: number = 25;
  public pageList: number[] = [];

  constructor() {

  }

  ngOnInit() {
    try {
      if (this.tableData){
        this.syncData();
      }
    } catch (error){
      console.log(error)
    }

  }

  syncData(){
    if (this.tableData) {
      let objList = Object.keys(this.tableData[0]).sort()

      for (let x of objList){
        this.keyList.push([x, this.addSpaceBetweenLetters(x).replace("_", " ").toUpperCase()])
      }

      this.dtData = this.tableData.slice(this.currentPage - 1, this.itemsPerPage)
      this.pageList = Array(Math.ceil(this.tableData.length / this.itemsPerPage))
      this.dtReady = true;
    }
  }

  recordSearch(col: string, val: string){
    this.dtData = this.tableData.filter(x => x[col].toString().includes(val.toLowerCase()));

    if (this.dtData.length == 0){
      this.dtData = [{ Loading: "No results found" }];
    }

    if (val == ""){
      this.onPageChange(this.currentPage)
    }
  }

   addSpaceBetweenLetters(str: string): string {
    return str.replace(/([a-z])([A-Z])/g, '$1 $2');
  }

  onPageChange(page: number) {
    if (page == 0){
      return;
    }

    if (page > this.pageList.length){
      return;
    }

    this.currentPage = page;

    this.dtData = this.tableData.slice((this.currentPage - 1) * this.itemsPerPage, ((this.currentPage - 1) * this.itemsPerPage) + this.itemsPerPage);
  }

  requestData(){

  }

}
