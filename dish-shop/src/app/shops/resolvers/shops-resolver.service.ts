import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Shop } from '../../models/shop.model';
import { ShopsStateService } from '../shops-state.service';

@Injectable()
export class ShopsResolverService implements Resolve<Shop[]>{
    constructor(private shopStateService: ShopsStateService){}

    resolve(route : ActivatedRouteSnapshot, state : RouterStateSnapshot){
        let shops = this.shopStateService.getShops();
        if(shops.length ===0)
        {
            return this.shopStateService.fetchShops();
        }
        else{
            return shops;
        }
    }
}