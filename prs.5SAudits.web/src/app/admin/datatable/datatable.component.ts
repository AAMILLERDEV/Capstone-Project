import { KeyValuePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

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
  public filterList: string[][] = [];

  public selectedRow?: any = null;
  public selectedRowIndex: number | null = null;

  @Output() recordSelected: EventEmitter<any> = new EventEmitter();

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

  private manageSelectionStyle(res: number, remove: boolean){
    let row = document.getElementById(res.toString())!
    if (remove){
      row.classList.remove("table-active")
      return
    }
    row.classList.add("table-active")
  }

  public selectRow(row: any, index: number){
    if (this.selectedRow == null){
      this.selectedRow = row
      this.selectedRowIndex = index
    } else if (this.selectedRow == row){
      this.manageSelectionStyle(this.selectedRowIndex as number, true)
      this.selectedRow = null
      this.selectedRowIndex = null
      this.emitRecord(undefined)
      return;
    }

    this.manageSelectionStyle(this.selectedRowIndex as number, true)
    this.selectedRow = row
    this.selectedRowIndex = index;
    this.manageSelectionStyle(index, false)
    this.emitRecord(this.selectedRow)
  }

  public emitRecord(selectedRow: any){
    this.recordSelected.emit(selectedRow)
  }

  public recordSearch(col: string, val: string){
    this.dtData = [...this.tableData];

    if (this.filterList.find(x => x[0] == col) == null){
      this.filterList.push([col, val])
    } else {
      let i = this.filterList.findIndex(x => x[0] == col)
      this.filterList[i] = [col, val]
    }

    for (let x of this.filterList){
      this.dtData = this.dtData.filter(y => (y[x[0]].toString()).toLowerCase().includes((x[1] as string).toLowerCase()))
    }

    if (this.dtData.length == 0){
      this.dtData = [{ Loading: "No results found" }]
    }

    if (val == "" && !this.filterList.length){
      this.onPageChange(this.currentPage)
    }
  }

  private addSpaceBetweenLetters(str: string): string {
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
