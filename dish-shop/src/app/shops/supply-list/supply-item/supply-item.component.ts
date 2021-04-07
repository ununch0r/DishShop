import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Supply } from 'src/app/models/supply.model';
import { SupplyService } from '../../http-services/supply.service';

@Component({
  selector: 'app-supply-item',
  templateUrl: './supply-item.component.html',
  styleUrls: ['./supply-item.component.css']
})
export class SupplyItemComponent implements OnInit {
  @Input() supply : Supply
  @Input() index : number

  constructor(
    private suppliesService: SupplyService,
    private router : Router,
    private route : ActivatedRoute
  ) { }

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

  onCancel(){
    this.suppliesService.cancelSupply(this.supply.id);
  }

  onReceive(){
    this.suppliesService.receiveSupply(this.supply.id);
  }
}
