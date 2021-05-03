import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Shop } from '../models/shop.model';
import { ShopsStateService } from '../shops/shops-state.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.css']
})
export class StatisticsComponent implements OnInit {

  shops : Shop[]
  subscription : Subscription

  constructor(
    private shopService : ShopsStateService
    )
     { }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.shops = this.shopService.getShops();
    console.log(this.shops)
    this.subscription = this.shopService.shopsCollectionChanged.subscribe(
        shops => {
          this.shops = shops;
        }
      );
  }

}
