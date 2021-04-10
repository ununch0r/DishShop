import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Contract } from 'src/app/models/contract.model';
import { ProvidersStateService } from '../providers-state.service';

@Component({
  selector: 'app-contract-detail',
  templateUrl: './contract-detail.component.html',
  styleUrls: ['./contract-detail.component.css']
})
export class ContractDetailComponent implements OnInit {
  contract: Contract;
  providerId : number;
  contractId : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private providersService: ProvidersStateService,
    private router: Router
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this.subscriptions.add(this.activatedRoute.params.subscribe(
      (params: Params) => {
        this.providerId = +params['id'];
        this.contractId = +params['contractId'];
        this.contract = this.providersService.getContractByProviderIdAndContractId(this.providerId, this.contractId);
      }
    ));

    this.subscriptions.add(this.providersService.providersCollectionChanged.subscribe(
      () => {
        this.contract = this.providersService.getContractByProviderIdAndContractId(this.providerId, this.contractId);
      }
    ));
  }

  onShowProduct(productId : number){
    this.router.navigate(['products', productId]);
  }

  onCreateSupply(){
    this.router.navigate(['supplies','new']);
  }
}
