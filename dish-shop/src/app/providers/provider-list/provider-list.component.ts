import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Provider } from 'src/app/models/provider.model';
import { ProvidersStateService } from '../providers-state.service';

@Component({
  selector: 'app-provider-list',
  templateUrl: './provider-list.component.html',
  styleUrls: ['./provider-list.component.css']
})
export class ProviderListComponent implements OnInit {
  providers : Provider[]
  subscription : Subscription

  constructor(private providerService : ProvidersStateService) { }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.providers = this.providerService.getProviders();
    this.subscription = this.providerService.providersCollectionChanged.subscribe(
        providers => {
          this.providers = providers;
        }
      );
  }
}
