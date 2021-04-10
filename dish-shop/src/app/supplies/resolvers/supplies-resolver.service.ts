import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Supply } from '../../models/supply.model';
import { SuppliesStateService } from '../supplies-state-service';

@Injectable()
export class SuppliesResolverService implements Resolve<Supply[]>{
    constructor(private supplyStateService: SuppliesStateService){}

    resolve(route : ActivatedRouteSnapshot, state : RouterStateSnapshot){
        let supplies = this.supplyStateService.getSupplies();
        if(supplies.length ===0)
        {
            return this.supplyStateService.fetchSupplies();
        }
        else{
            return supplies;
        }
    }
}