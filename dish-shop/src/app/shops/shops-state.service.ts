import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Shop } from '../models/shop.model';
import { ShopNestedEmployee } from '../models/shop-nested-models/shop-nested-employee.model';
import { ShopService } from './http-services/shop.service';
import {tap} from 'rxjs/operators'
import { NotificationService } from '../notification.service';
import { Supply } from '../models/supply.model';
import { ShopAvailability } from '../models/shop-availability.model';

@Injectable()
export class ShopsStateService{
    public shopsCollectionChanged = new Subject<Shop[]>();
    subscriptions : Subscription[] = <Subscription[]>[]
    shops : Shop[] = <Shop[]>[];

    constructor(
        public shopServive : ShopService,
        private notifyService : NotificationService
    ){}

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

    getShop(id: number) : Shop{
        return this.shops.find(shop => shop.id === id);
    }

    getEmployeesByShopId(id: number) : ShopNestedEmployee[]{
        return this.shops.find(shop => shop.id === id).employees;
    }

    getSuppliesByShopId(id: number) : Supply[]{
        return this.shops.find(shop => shop.id === id).supplies;
    }

    getAvailabilitiesByShopId(id: number) : ShopAvailability[]{
        return this.shops.find(shop => shop.id === id).shopsAvailabilities;
    }

    getShops() : Shop[] {
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