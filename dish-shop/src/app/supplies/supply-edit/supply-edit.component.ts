import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import {Subscription } from 'rxjs';
import { pairwise, startWith } from 'rxjs/operators';
import { Contract } from 'src/app/models/contract.model';
import { Product } from 'src/app/models/product.model';
import { Provider } from 'src/app/models/provider.model';
import { NotificationService } from 'src/app/notification.service';
import { ProviderService } from 'src/app/providers/http-services/provider.service';
import { SuppliesStateService } from '../supplies-state-service';

@Component({
  selector: 'app-supply-edit',
  templateUrl: './supply-edit.component.html',
  styleUrls: ['./supply-edit.component.css']
})
export class SupplyEditComponent implements OnInit {
  supplyForm : FormGroup;
  selectedProvider : Provider;
  selectedContract : Contract;
  providers : Provider[];
  availableProducts : Product[];
  contracts : Contract[];
  subscriptions : Subscription = new Subscription();

  isContractsAvailable = false;
  isProductsAvailable = false;

  constructor(
    private route: ActivatedRoute,
    private suppliesService : SuppliesStateService,
    private router : Router,
    private providerService : ProviderService,
    private notificationService : NotificationService
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }


  ngOnInit(): void {
    this.initForm();

    this.subscriptions.add(this.providerService.getAllProviders().subscribe(
      providers => this.providers = providers
    ));
  }

  private initForm(){
    this.supplyForm = new FormGroup({
      'creatorId' : new FormControl(27, [Validators.required]),
      'shopId' : new FormControl(7, [Validators.required]),
      'contractId' : new FormControl(null, [Validators.required]),
      'suppliesContents' : new FormArray([], [Validators.required])
    });
  }

  onProviderChanged(value : string){
    const providerId = (+value.split(':')[1]);
    this.providerService.getProviderById(providerId).subscribe(
        provider => {
          this.selectedProvider = provider;
          this.contracts = provider.contracts;
        }
      );
  }

  onContractChanged(value : string){
    this.isProductsAvailable = true;
    this.isContractsAvailable = true;

    const contractId = (+value.split(':')[1]);

    this.selectedContract = this.selectedProvider.contracts
    .find(contract => contract.id === contractId);

    this.availableProducts = this.selectedContract.contractsContents
      .map(content => content.product);
  }

  onSubmit(){
      const isValid = this.validateSelectedProducts();
      if(isValid){
        this.suppliesService.addSupply(this.supplyForm.value);
        this.router.navigate(['../'], {relativeTo: this.route})
      }else{
        this.notificationService.showError("Your supply contains duplicate items!", "Check your content!");
      }
  }

  validateSelectedProducts(){
    const formArray = (<FormArray>this.supplyForm.get('suppliesContents'));
    const arrayOfProducts = Array<number>();
    formArray.controls.forEach((element) => {
      arrayOfProducts.push(element.value.productId);
    });

    return !this.hasDuplicates(arrayOfProducts);
  }

  hasDuplicates(array) {
    var valuesSoFar = Object.create(null);
    for (var i = 0; i < array.length; ++i) {
        var value = array[i];
        if (value in valuesSoFar) {
            return true;
        }
        valuesSoFar[value] = true;
    }
    return false;
  }

  onAdd(){
    const formGroup = new FormGroup({
      'productId': new FormControl(null),
      'count': new FormControl(null, [
         Validators.pattern(/^[1-9]+[0-9]*$/)
        ])
    });
    (<FormArray>this.supplyForm.get('suppliesContents')).push(
      formGroup
    )
  }

  onDeleteProductContent(index : number){
    (<FormArray>this.supplyForm.get('suppliesContents')).removeAt(index);
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  showContracts(){
    this.router.navigate(['providers', this.selectedProvider.id, 'contracts', this.selectedContract.id]);
  }
}
