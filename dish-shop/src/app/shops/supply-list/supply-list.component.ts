import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Supply } from 'src/app/models/supply.model';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-supply-list',
  templateUrl: './supply-list.component.html',
  styleUrls: ['./supply-list.component.css']
})
export class SupplyListComponent implements OnInit, OnDestroy {
  supplies: Supply[] = [];
  id : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private shopsService: ShopsStateService,
    private router: Router
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  ngOnInit(): void {
    this.subscriptions.add(this.activatedRoute.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.supplies = this.shopsService.getSuppliesByShopId(this.id);
      }
    ));

    
    this.subscriptions.add(this.shopsService.shopsCollectionChanged.subscribe(
      () => {
        this.supplies = this.shopsService.getSuppliesByShopId(this.id);
      }
    ));
  }
}
