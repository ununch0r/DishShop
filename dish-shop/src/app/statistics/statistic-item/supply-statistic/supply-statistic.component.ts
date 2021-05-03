import { Component, Input, OnInit } from '@angular/core';
import { Shop } from 'src/app/models/shop.model';
import { Supply } from 'src/app/models/supply.model';

@Component({
  selector: 'app-supply-statistic',
  templateUrl: './supply-statistic.component.html',
  styleUrls: ['./supply-statistic.component.css']
})
export class SupplyStatisticComponent implements OnInit {
  @Input() supply : Supply
  @Input() index : number


  constructor() { }

  ngOnInit(): void {
  }

  getBackgroundColor(){
    if(this.supply.status.name ==='Received'){
      return '#92FF94';
    } else if(this.supply.status.name === 'In progress'){
      return '#F1FFA2';
    } else if (this.supply.status.name === 'Canceled'){
      return '#FFA390';
    }
  }
}
