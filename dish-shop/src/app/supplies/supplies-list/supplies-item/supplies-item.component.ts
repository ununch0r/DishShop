import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SupplyService } from 'src/app/http-services/supply.service';
import { Supply } from 'src/app/models/supply.model';

@Component({
  selector: 'app-supplies-item',
  templateUrl: './supplies-item.component.html',
  styleUrls: ['./supplies-item.component.css']
})
export class SuppliesItemComponent implements OnInit {
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
}
