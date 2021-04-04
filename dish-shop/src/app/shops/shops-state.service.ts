import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Shop } from '../models/shop.model';
import { ShopService } from './http-services/shop.service';
import {tap} from 'rxjs/operators'
import { NotificationService } from '../notification.service';

@Injectable()
export class ShopsStateService{
    public shopsCollectionChanged = new Subject<Shop[]>();
    subscriptions : Subscription[] = []
    shops : Shop[] = [];

    constructor(
        public shopServive : ShopService,
        private notifyService : NotificationService
    ){
        this.subscriptions.push(this.fetchShops().subscribe( data => this.reloadShops(data)))
    }

    fetchShops(){
        return this.shopServive.getAllShops()
        .pipe(
            tap(
            shops => {
                this.shops = shops;
                this.shopsCollectionChanged.next(this.shops.slice());
            }
        ));
    }

    reloadShops(shops : Shop[]){
        this.shops = shops;
        this.shopsCollectionChanged.next(this.shops.slice());
    }

    getShop(id: number)
    {
        return this.shops.find(shop => shop.id === id);
    }

    getShops(){
        return this.shops.slice();
    }

    addShop(shop){
        this.shopServive.createShop(shop).subscribe(
            () => {
                this.subscriptions.push(this.fetchShops().subscribe( 
                    data => {
                        this.reloadShops(data)
                        this.notifyService.showSuccess("Shop was added succesfully!", "Shop added!")
                    },
                    error => {
                        this.notifyService.showSuccess(error, "Error occured!")
                    }));
            }
        )
    }
}