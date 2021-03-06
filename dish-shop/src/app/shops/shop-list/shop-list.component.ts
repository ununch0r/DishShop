import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Shop } from 'src/app/models/shop.model';
import { UserService } from 'src/app/user.service';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.css']
})
export class ShopListComponent implements OnInit, OnDestroy {
  shops : Shop[]
  subscription : Subscription

  constructor(
    private shopService : ShopsStateService,
    public userService : UserService
    )
     { }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.shops = this.shopService.getShops();
    this.subscription = this.shopService.shopsCollectionChanged.subscribe(
        shops => {
          this.shops = shops;
        }
      );
  }

}
