import { AfterContentChecked, Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/models/category.model';
import { Characteristic } from 'src/app/models/characteristic.model';
import { Producer } from 'src/app/models/producer.model';
import { CategoryService } from '../http-services/category.service';
import { CharacteristicService } from '../http-services/characteristic.service';
import { ProducerService } from '../http-services/producer.service';
import { ProductsStateService } from '../products-state.service';
import { ConfirmationDialogService } from 'src/app/confirmation-dialog/confirmation-dialog.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit, OnDestroy {
  id: number;
  editMode: boolean = false;
  productForm : FormGroup;
  categories : Category[];
  producers : Producer[];
  allCharacteristics : Characteristic[];
  subscriptions : Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private productsService : ProductsStateService,
    private router : Router,
    private categoryService : CategoryService,
    private producerService : ProducerService,
    private characteristicService : CharacteristicService,
    private confirmationDialogService: ConfirmationDialogService
    ) { }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }


  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.editMode = params['id'] != null;
        this.initForm();
      }
    )

    this.subscriptions.add(this.categoryService.getAllCategories().subscribe(
      categories =>{ this.categories = categories
      }
    ));

    this.subscriptions.add(this.producerService.getAllProducers().subscribe(
      producers => this.producers = producers
    ));

    this.subscriptions.add(this.characteristicService.getAllCharacteristics().subscribe(
      characteristics => this.allCharacteristics = characteristics
    ));

    this.allCharacteristics = this.characteristicService.getSavedCharacteristics();
  }

  private initForm(){
    let productName = '';
    let price: number;
    let productDescription = '';
    let category : number;
    let producer : number;
    let characteristics = new FormArray([]);

    if(this.editMode){
      const product = this.productsService.getProduct(this.id);
      productName = product.name;
      category = product.category.id;
      producer = product.producer.id;
      price = product.price;
      productDescription = product.description;

      if(product['productsCharacteristics']){
        for(let characteristic of product.productsCharacteristics){
          characteristics.push(
            new FormGroup({
              'characteristicId' : new FormControl(characteristic.characteristic.id),
              'value' : new FormControl(characteristic.value, [Validators.pattern(/^[1-9]+[0-9]*$/)])
            })
          );
        }
      }
    }

    this.productForm = new FormGroup({
      'name' : new FormControl(productName, [Validators.required]),
      'description' : new FormControl(productDescription),
      'price' : new FormControl(price, [Validators.required, Validators.pattern(/^[1-9]+[0-9]*$/)]),
      'categoryId' : new FormControl(null, [Validators.required]),
      'producerId' : new FormControl(null, [Validators.required]),
      'productsCharacteristics' : characteristics
    })

    this.patchDefaultValues(category, producer);
  }

  canCharacteristicHoldValue(control : FormGroup) : boolean {
    const characteristic = this.allCharacteristics.find(c => c.id === control.get('characteristicId').value);
    if(characteristic){
      if(characteristic.valueType === null)
      {
        control.get('value').setValue(null);
        return false;
      }
      else{
        return true;
      }
    } else{
      return false;
    }
  }

  onCategoryChange(value : string){
    if(!this.editMode)
    {
    this.confirmationDialogService.confirm('Please confirm..', 'Do you want to pull characteristics by category?')
    .then((confirmed) => {
      if(confirmed){
        const categoryId = (+value.split(':')[1]);
        this.characteristicService.getCharacteristicsByCategoryId(categoryId).subscribe(
          characteristics => {
            this.addCharacteristicsByCategory(characteristics);
          }
        )
      }
    })
    .catch(() => {})
    }
  }

  addCharacteristicsByCategory(characteristics : Characteristic []){
    const characteristicsArray = (<FormArray>this.productForm.get('productsCharacteristics'));
    characteristicsArray.clear();
    console.log(this.allCharacteristics);
    characteristics.forEach(
      (characteristic)=>{
        characteristicsArray.push(
          new FormGroup({
            'characteristicId' : new FormControl(characteristic.id),
            'value': new FormControl(null, [
              Validators.pattern(/^[1-9]+[0-9]*$/)
             ])
          })
        )
      })
  }

  patchDefaultValues(categoryId: number, producerId: number){
    if(categoryId)
    {
      this.productForm.get('categoryId').patchValue(categoryId);
    }
    if(producerId)
    {
      this.productForm.get('producerId').patchValue(producerId);
    }
  }

  onSubmit(){

    if(this.editMode){
      this.productsService.updateProduct(this.id, this.productForm.value);
    }
    else{
      this.productsService.addProduct(this.productForm.value);
    }
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  onAdd(){
    (<FormArray>this.productForm.get('productsCharacteristics')).push(
      new FormGroup({
        'characteristicId': new FormControl(null),
        'value': new FormControl(null, [
           Validators.pattern(/^[1-9]+[0-9]*$/)
          ])
      })
    )
  }

  onDeleteCharacteristic(index : number){
    (<FormArray>this.productForm.get('productsCharacteristics')).removeAt(index);
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }
}
