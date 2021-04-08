import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Provider } from '../../models/provider.model';
import { ProvidersStateService } from '../providers-state.service';

@Injectable()
export class ProvidersResolverService implements Resolve<Provider[]>{
    constructor(private providerStateService: ProvidersStateService){}

    resolve(route : ActivatedRouteSnapshot, state : RouterStateSnapshot){
        let providers = this.providerStateService.getProviders();
        if(providers.length ===0)
        {
            return this.providerStateService.fetchProviders();
        }
        else{
            return providers;
        }
    }
}