import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-utilities',
  templateUrl: './utilities.component.html',
  styleUrls: ['./utilities.component.css']
})
export class UtilitiesComponent implements OnInit {
  producerForm : FormGroup;
  countryForm : FormGroup;
  cityForm : FormGroup;
  characteristicForm : FormGroup;
  valueTypeForm : FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.initFroms();
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
      'valueTypeId' : new FormControl(null, [Validators.required])
    });
  }

}
