import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { UtilitiesService } from '../http-services/utilities.service';
import { Country } from '../models/country.model';
import { ValueType } from '../models/value-type.model';
import { NotificationService } from '../notification.service';

@Component({
  selector: 'app-utilities',
  templateUrl: './utilities.component.html',
  styleUrls: ['./utilities.component.css']
})
export class UtilitiesComponent implements OnInit, OnDestroy {
  producerForm : FormGroup;
  countryForm : FormGroup;
  cityForm : FormGroup;
  characteristicForm : FormGroup;
  valueTypeForm : FormGroup;
  subscriptions : Subscription[] = [];
  countries : Country[] = [];
  valueTypes : ValueType[] = [];

  observer = {
    next: x => {
      this.notificationService.showSuccess('Item was added to the system!', 'Success!')
    },
    error: err => {
      this.notificationService.showError('Item was not added to the system!', 'Error!')
    }
  };

  constructor(
    private utilitiesService : UtilitiesService,
    private notificationService : NotificationService
  ) { }

  ngOnInit(): void {
    this.fetchDate();
    this.initFroms();
  }

  ngOnDestroy(){
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }

  fetchDate(){
    this.subscriptions.push(
      this.utilitiesService.getAllCountries().subscribe(
        countries => this.countries = countries
      )
    );

    this.subscriptions.push(
      this.utilitiesService.getAllValueTypes().subscribe(
        valueTypes => this.valueTypes = valueTypes
      )
    );
  }

  initFroms(){
    this.initProducerForm();
    this.initCityForm();
    this.initCountryForm();
    this.initValueTypeForm();
    this.initCharacteristicForm();
  }

  initProducerForm(){
    this.producerForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required]),
      'countryId' : new FormControl(null, [Validators.required])
    });
  }

  initCityForm(){
    this.cityForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required]),
      'countryId' : new FormControl(null, [Validators.required])
    });
  }

  initCountryForm(){
    this.countryForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required]),
    });
  }

  initValueTypeForm(){
    this.valueTypeForm = new FormGroup({
      'type' : new FormControl(null, [Validators.required]),
    });
  }

  initCharacteristicForm(){
    this.characteristicForm = new FormGroup({
      'name' : new FormControl(null, [Validators.required]),
      'valueTypeId' : new FormControl(null)
    });
  }

  onCountrySubmit(){
    this.subscriptions.push(this.utilitiesService.createCountry(this.countryForm.value).subscribe(
      this.observer
    ));
    this.countryForm.reset();
  }

  onProducerSubmit(){
    this.subscriptions.push(this.utilitiesService.createProducer(this.producerForm.value).subscribe(
      this.observer
    ));
    this.producerForm.reset();
  }

  onCitySubmit(){
    this.subscriptions.push(this.utilitiesService.createCity(this.cityForm.value).subscribe(
      this.observer
    ));
    this.cityForm.reset();
  }

  onValueTypeSubmit(){
    this.subscriptions.push(this.utilitiesService.createValueType(this.valueTypeForm.value).subscribe(
      this.observer
    ));
    this.valueTypeForm.reset();
  }

  onCharacteristicSubmit(){
    this.subscriptions.push(this.utilitiesService.createCharacteristic(this.characteristicForm.value).subscribe(
      this.observer
    ));
    this.characteristicForm.reset();
  }
}
