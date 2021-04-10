import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Provider } from '../models/provider.model';
import { ProviderService } from './http-services/provider.service';
import {tap} from 'rxjs/operators'
import { NotificationService } from '../notification.service';
import { Contract } from '../models/contract.model';

@Injectable()
export class ProvidersStateService{
    public providersCollectionChanged = new Subject<Provider[]>();
    subscriptions : Subscription[] = <Subscription[]>[]
    providers : Provider[] = <Provider[]>[];

    constructor(
        public providerServive : ProviderService,
        private notifyService : NotificationService
    ){}

    fetchProviders(){
        return this.providerServive.getAllProviders()
        .pipe(
            tap(
            providers => {
                this.providers = providers;
                this.providersCollectionChanged.next(this.providers.slice());
            }
        ));
    }

    getContractsByProviderId(id: number) : Contract[]{
        return this.providers.find(provider => provider.id === id).contracts;
    }

    getContractByProviderIdAndContractId(providerId : number, contractId : number) : Contract{
        return this.providers.find(provider => provider.id === providerId)
                   .contracts.find(contract => contract.id === contractId);
    }

    reloadProviders(providers : Provider[]){
        this.providers = providers;
        this.providersCollectionChanged.next(this.providers.slice());
    }

    getProvider(id: number) : Provider{
        return this.providers.find(provider => provider.id === id);
    }

    getProviders() : Provider[] {
        return this.providers.slice();
    }

    addProvider(provider){
        this.providerServive.createProvider(provider).subscribe(
            () => {
                this.subscriptions.push(this.fetchProviders().subscribe( 
                    data => {
                        this.reloadProviders(data)
                        this.notifyService.showSuccess("Provider was added succesfully!", "Provider added!")
                    },
                    error => {
                        this.notifyService.showSuccess(error, "Error occured!")
                    }));
            }
        )
    }
}