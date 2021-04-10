import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Contract } from 'src/app/models/contract.model';
import { Product } from 'src/app/models/product.model';
import { Provider } from 'src/app/models/provider.model';
import { ContractService } from 'src/app/providers/http-services/contract.service';
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
    private providerService : ProviderService
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
      'employeeId' : new FormControl(1, [Validators.required]),
      'shopId' : new FormControl(1, [Validators.required]),
      'contractId' : new FormControl(null, [Validators.required]),
      'suppliesContents' : new FormArray([])
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
    const contractId = (+value.split(':')[1]);
    this.availableProducts = this.selectedProvider.contracts
      .find(contract => contract.id == contractId).contractsContents
      .map(content => content.product);
      console.log(this.availableProducts);
      console.log(this.selectedProvider);
  }

  onSubmit(){
      this.suppliesService.addSupply(this.supplyForm.value);
      this.router.navigate(['../'], {relativeTo: this.route})
  }

  onAdd(){
    (<FormArray>this.supplyForm.get('suppliesContents')).push(
      new FormGroup({
        'productId': new FormControl(null),
        'count': new FormControl(null, [
           Validators.pattern(/^[1-9]+[0-9]*$/)
          ])
      })
    )
  }

  onDeleteProductContent(index : number){
    (<FormArray>this.supplyForm.get('suppliesContents')).removeAt(index);
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  showContracts(){

  }
}
