import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UtilitiesService } from 'src/app/http-services/utilities.service';
import { City } from 'src/app/models/city.model';
import { ProvidersStateService } from '../providers-state.service';

@Component({
  selector: 'app-provider-edit',
  templateUrl: './provider-edit.component.html',
  styleUrls: ['./provider-edit.component.css']
})
export class ProviderEditComponent implements OnInit {
  subscriptions : Subscription[] = [];
  id: number;
  providerForm : FormGroup;
  cities : City[] = [];

  constructor(
    private route: ActivatedRoute,
    private router : Router,
    private providersService : ProvidersStateService,
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
    this.providerForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required]),
      'email' : new FormControl(null, [Validators.required]),
      'phoneNumber' : new FormControl(null, [Validators.required]),
      'cityId' : new FormControl(null, [Validators.required])
    });
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  onSubmit(){
    this.providersService.addProvider(this.providerForm.value);
    this.router.navigate(['../'], {relativeTo: this.route})
  }
}
