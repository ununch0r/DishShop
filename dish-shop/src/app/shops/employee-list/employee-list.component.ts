import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ShopNestedEmployee } from 'src/app/models/shop-nested-models/shop-nested-employee.model';
import { UserService } from 'src/app/user.service';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit, OnDestroy {
  employees: ShopNestedEmployee[] = [];
  id : number;
  subscriptions : Subscription = new Subscription();

  constructor(
    private activatedRoute: ActivatedRoute,
    private shopsService: ShopsStateService,
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
        this.employees = this.shopsService.getEmployeesByShopId(this.id);
      }
    ));

    
    this.subscriptions.add(this.shopsService.shopsCollectionChanged.subscribe(
      () => {
        this.employees = this.shopsService.getEmployeesByShopId(this.id);
      }
    ));
  }
}
