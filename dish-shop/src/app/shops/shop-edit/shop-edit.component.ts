import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UtilitiesService } from 'src/app/http-services/utilities.service';
import { City } from 'src/app/models/city.model';
import { ShopsStateService } from '../shops-state.service';

@Component({
  selector: 'app-shop-edit',
  templateUrl: './shop-edit.component.html',
  styleUrls: ['./shop-edit.component.css']
})
export class ShopEditComponent implements OnInit {
  subscriptions : Subscription[] = [];
  id: number;
  shopForm : FormGroup;
  cities : City[] = [];

  constructor(
    private route: ActivatedRoute,
    private router : Router,
    private shopsService : ShopsStateService,
    private cityService : UtilitiesService
  ) { }

  ngOnDestroy(): void {
    this.subscriptions.forEach(
      subscription => subscription.unsubscribe()
    );
  }


  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.initForm();
      }
    )

    this.subscriptions.push(
      this.cityService.getAllCities().subscribe(
        cities => this.cities = cities
      )
    );
  }

  private initForm(){
    this.shopForm = new FormGroup({
      'cityId' : new FormControl(null, [Validators.required]),
      'phoneNumber' : new FormControl(null, [Validators.required]),
      'streetName' : new FormControl(null, [Validators.required]),
      'streetIdentifier' : new FormControl(null, [Validators.required])
    });
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  onSubmit(){
    this.shopsService.addShop(this.shopForm.value);
    this.router.navigate(['../'], {relativeTo: this.route})
  }
}
