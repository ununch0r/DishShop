import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import { ContractService } from '../../http-services/contract.service';
import { ProvidersStateService } from '../../providers-state.service';

@Component({
  selector: 'app-contract-edit',
  templateUrl: './contract-edit.component.html',
  styleUrls: ['./contract-edit.component.css']
})
export class ContractEditComponent implements OnInit {
  subscriptions : Subscription[] = [];
  id: number;
  contractForm : FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router : Router,
    private contractsSerive: ContractService
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
  }

  private initForm(){
    this.contractForm = new FormGroup({
      'startDate' : new FormControl(null, [Validators.required]),
      'endDate' : new FormControl(null, [Validators.required]),
      'providerId' : new FormControl(this.id),
      'contractsContents' : new FormArray([])
    });
  }

  onAdd(){
    (<FormArray>this.contractForm.get('contractsContents')).push(
      new FormGroup({
        'productId': new FormControl(null, [Validators.pattern(/^[1-9]+[0-9]*$/),Validators.required]),
        'pricePerUnit': new FormControl(null, [Validators.pattern(/^[1-9]+[0-9]*$/),Validators.required])
      })
    )
  }

  onDeleteContent(index : number){
    (<FormArray>this.contractForm.get('contractsContents')).removeAt(index);
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  onSubmit(){
    console.log(this.contractForm.value);
    this.contractsSerive.addContract(this.contractForm.value);
    this.router.navigate(['../'], {relativeTo: this.route})
  }
}
