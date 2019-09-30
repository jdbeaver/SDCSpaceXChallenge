import { Component } from '@angular/core';
import { MatButton, MatTable, MatSelect, MatLabel, MatInput, MatOption } from '@angular/material';

//import services
import { SDCSpaceXService } from '../../services/sdcspacexService'

//typically not placed here but
//adding for expediance!
export interface Status {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public dataSource: any;
  public lpstatus: string = "all";
  public limit: string = "2";
  displayedColumns: string[] = ['id', 'full_name', 'status'];

  allstatus: Status[] = [
    { value: 'all-0', viewValue: 'all' },
    { value: 'active-1', viewValue: 'active' },
    { value: 'under construction-2', viewValue: 'under construction' },
    { value: 'retired-3', viewValue: 'retired' }
  ];

  defaultStatus = 'all-0';
  //statusvalue = 'all'
  limitvalue = "0";
  

  //public defaultStatus = "all"
  constructor(private sdcspacexService: SDCSpaceXService) {

  }

  changeStatus(statusvalue) {
    //easier to get this value is forms were used, again
    //just to demonstrate API so quickly placed!
    this.lpstatus = statusvalue.source.selected.viewValue;
  }

  getLPInfo() {
    //get filter values
    this.limit = this.limitvalue
    this.sdcspacexService.getLPInfo(this.lpstatus, this.limit).subscribe((res) => {
      this.dataSource=res;
    })
  }




}
