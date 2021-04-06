import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Shop } from 'src/app/models/shop.model';
import { SupplyStatus } from 'src/app/models/supply-status.model';
import { Supply } from 'src/app/models/supply.model';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-shop-detail',
  templateUrl: './shop-detail.component.html',
  styleUrls: ['./shop-detail.component.css']
})
export class ShopDetailComponent implements OnInit {
  shop: Shop;
  id : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private shopsService: ShopsStateService,
    private router: Router
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this.subscriptions.add(this.activatedRoute.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.shop = this.shopsService.getShop(this.id);
        console.log(this.shop);
      }
    ));

    
    this.subscriptions.add(this.shopsService.shopsCollectionChanged.subscribe(
      () => {
        this.shop = this.shopsService.getShop(this.id);
      }
    ));
  }

  getBadgeClass(supplyStatus : SupplyStatus){
    return {
      'badge-success' : supplyStatus.name === 'Received',
      'badge-warning' : supplyStatus.name === 'In progress'
    }
  }

  getDate(supply : Supply) : Date {
    if(supply.status.name === 'Received'){
      return supply.dateReceived;
    } else if (supply.status.name === 'In progress'){
      return supply.dateCreated;
    }
  }
}