import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/models/category.model';
import { Producer } from 'src/app/models/producer.model';
import { CategoryService } from '../http-services/category-service';
import { ProducerService } from '../http-services/producer.service';
import { ProductsStateService } from '../products-state.service';

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
  subscriptions : Subscription = new Subscription();

  constructor(
    private route: ActivatedRoute,
    private productsService : ProductsStateService,
    private router : Router,
    private categoryService : CategoryService,
    private producerService : ProducerService
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
      categories => this.categories = categories
    ));

    this.subscriptions.add(this.producerService.getAllProducers().subscribe(
      producers => this.producers = producers
    ));
  }

  private initForm(){

    let productName = '';
    let price = '';
    let productDescription = '';
    let characteristics = new FormArray([]);

    if(this.editMode){
      const recipe = this.productsService.getProduct(this.id);
      productName = recipe.name;
      productDescription = recipe.description;
    }

    this.productForm = new FormGroup({
      'name' : new FormControl(productName, [Validators.required]),
      'description' : new FormControl(productDescription, [Validators.required]),
      'price' : new FormControl(price, [Validators.required, Validators.pattern(/^[1-9]+[0-9]*$/)]),
      'categoryId' : new FormControl(null, [Validators.required]),
      'producerId' : new FormControl(null, [Validators.required]),
      'characteristics' : characteristics
    })
  }

  onSubmit(){
    if(this.editMode){
    //  this.productsService.updateRecipe(this.id, this.productForm.value);
    }
    else{
      this.productsService.addProduct(this.productForm.value);
    }
    console.log(this.productForm.value);
    this.router.navigate(['../'], {relativeTo: this.route})
  }

  onAdd(){
    (<FormArray>this.productForm.get('ingredients')).push(
      new FormGroup({
        'name': new FormControl(null, [Validators.required]),
        'amount': new FormControl(null, [
          Validators.required,
           Validators.pattern(/^[1-9]+[0-9]*$/)
          ])
      })
    )
  }

  onDeleteIngredient(index : number){
    (<FormArray>this.productForm.get('ingredients')).removeAt(index);
  }

  onCancel(){
    this.router.navigate(['../'], {relativeTo: this.route})
  }
}
