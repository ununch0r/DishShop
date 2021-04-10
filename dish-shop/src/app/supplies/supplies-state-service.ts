import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Supply } from '../models/supply.model';
import { SupplyService } from '../http-services/supply.service';
import {tap} from 'rxjs/operators'
import { NotificationService } from '../notification.service';

@Injectable()
export class SuppliesStateService{
    public suppliesCollectionChanged = new Subject<Supply[]>();
    subscriptions : Subscription[] = <Subscription[]>[]
    supplies : Supply[] = <Supply[]>[];

    constructor(
        public supplyServive : SupplyService,
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

    addSupply(supply){
        this.supplyServive.createSupply(supply).subscribe(
            () => {
                this.subscriptions.push(this.fetchSupplies().subscribe( 
                    data => {
                        this.reloadSupplies(data)
                        this.notifyService.showSuccess("Supply was added succesfully!", "Supply added!")
                    },
                    error => {
                        this.notifyService.showSuccess(error, "Error occured!")
                    }));
            }
        )
    }
}