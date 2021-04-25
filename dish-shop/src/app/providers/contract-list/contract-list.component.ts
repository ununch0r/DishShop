import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Contract } from 'src/app/models/contract.model';
import { UserService } from 'src/app/user.service';
import { ProvidersStateService } from '../providers-state.service';

@Component({
  selector: 'app-contract-list',
  templateUrl: './contract-list.component.html',
  styleUrls: ['./contract-list.component.css']
})
export class ContractListComponent implements OnInit {
  contracts: Contract[] = [];
  id : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private providersService: ProvidersStateService,
    private router: Router,
    public userService : UserService
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this.subscriptions.add(this.activatedRoute.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.contracts = this.providersService.getContractsByProviderId(this.id);
      }
    ));

    
    this.subscriptions.add(this.providersService.providersCollectionChanged.subscribe(
      () => {
        this.contracts = this.providersService.getContractsByProviderId(this.id);
      }
    ));
  }
}
