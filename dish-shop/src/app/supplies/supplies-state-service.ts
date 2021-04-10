import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Supply } from '../models/supply.model';
import { SupplyService } from '../http-services/supply.service';
import {tap} from 'rxjs/operators'
import { NotificationService } from '../notification.service';
import { ShopsStateService } from '../shops/shops-state.service';

@Injectable()
export class SuppliesStateService{
    public suppliesCollectionChanged = new Subject<Supply[]>();
    subscriptions : Subscription[] = <Subscription[]>[]
    supplies : Supply[] = <Supply[]>[];

    constructor(
        public supplyServive : SupplyService,
        private shopsService : ShopsStateService,
        private notifyService : NotificationService
    ){}

    fetchSupplies(){
        return this.supplyServive.getAllSupplies()
        .pipe(
            tap(
            supplies => {
                this.supplies = supplies;
                this.suppliesCollectionChanged.next(this.supplies.slice());
            }
        ));
    }

    reloadSupplies(supplies : Supply[]){
        this.supplies = supplies;
        this.suppliesCollectionChanged.next(this.supplies.slice());
    }

    getSupply(id: number) : Supply{
        return this.supplies.find(supply => supply.id === id);
    }

    getSupplies() : Supply[] {
        return this.supplies.slice();
    }

    receiveSupply(id : number){
        this.supplyServive.receiveSupply(id).subscribe(
            () => {
                this.notifyService.showSuccess("Supply was reveived", "Successfully received!");
                this.subscriptions.push(this.shopsService.fetchShops().subscribe(
                    shops => {
                        this.shopsService.reloadShops(shops);
                     }
                ));
                this.subscriptions.push(this.fetchSupplies().subscribe(
                    supplies => {
                        this.reloadSupplies(supplies);
                     }
                ));
            }
        );
    }

    cancelSupply(id : number){
        this.supplyServive.cancelSupply(id).subscribe(
            () => {
                this.notifyService.showSuccess("Supply was canceled", "Successfully canceled!");
                this.subscriptions.push(this.shopsService.fetchShops().subscribe(
                    shops => {
                        this.shopsService.reloadShops(shops);
                     }
                ));
                this.subscriptions.push(this.fetchSupplies().subscribe(
                    supplies => {
                        this.reloadSupplies(supplies);
                     }
                ));
            }
        );
    }

    addSupply(supply){
        this.supplyServive.createSupply(supply).subscribe(
            () => {
                this.subscriptions.push(this.fetchSupplies().subscribe( 
                    data => {
                        this.reloadSupplies(data);
                        this.notifyService.showSuccess("Supply was added succesfully!", "Supply added!");
                        this.subscriptions.push(this.shopsService.fetchShops().subscribe( 
                            data => {
                                this.shopsService.reloadShops(data);
                            }));
                    },
                    error => {
                        this.notifyService.showSuccess(error, "Error occured!")
                    }));
            }
        )
    }
}