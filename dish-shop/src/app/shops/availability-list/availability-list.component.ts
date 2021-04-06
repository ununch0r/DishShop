import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ShopAvailability } from 'src/app/models/shop-availability.model';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-availability-list',
  templateUrl: './availability-list.component.html',
  styleUrls: ['./availability-list.component.css']
})
export class AvailabilityListComponent implements OnInit, OnDestroy {

  availabilities: ShopAvailability[] = [];
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
        this.availabilities = this.shopsService.getAvailabilitiesByShopId(this.id);
      }
    ));

    
    this.subscriptions.add(this.shopsService.shopsCollectionChanged.subscribe(
      () => {
        this.availabilities = this.shopsService.getAvailabilitiesByShopId(this.id);
      }
    ));
  }
}
