import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Supply } from 'src/app/models/supply.model';
import { SuppliesStateService } from '../supplies-state-service';

@Component({
  selector: 'app-supplies-list',
  templateUrl: './supplies-list.component.html',
  styleUrls: ['./supplies-list.component.css']
})
export class SuppliesListComponent implements OnInit {
  supplies : Supply[]
  subscription : Subscription

  constructor(private supplyService : SuppliesStateService) { }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.supplies = this.supplyService.getSupplies();
    this.subscription = this.supplyService.suppliesCollectionChanged.subscribe(
        supplies => {
          this.supplies = supplies;
        }
      );
  }
}
