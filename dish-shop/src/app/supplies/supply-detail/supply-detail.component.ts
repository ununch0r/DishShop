import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Supply } from 'src/app/models/supply.model';
import { SuppliesStateService } from '../supplies-state-service';

@Component({
  selector: 'app-supply-detail',
  templateUrl: './supply-detail.component.html',
  styleUrls: ['./supply-detail.component.css']
})
export class SupplyDetailComponent implements OnInit {
  supply: Supply;
  id : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private supplyService: SuppliesStateService,
    private router: Router
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this.subscriptions.add(this.activatedRoute.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.supply = this.supplyService.getSupply(this.id);
      }
    ));

    this.subscriptions.add(this.supplyService.suppliesCollectionChanged.subscribe(
      () => {
        this.supply = this.supplyService.getSupply(this.id);
      }
    ));
  }

  getBackgroundColor(){
    if(this.supply.status.name ==='Received'){
      return '#92FF94';
    } else if(this.supply.status.name === 'In progress'){
      return '#F1FFA2';
    } else if (this.supply.status.name === 'Canceled'){
      return '#FFA390';
    }
  }
}
