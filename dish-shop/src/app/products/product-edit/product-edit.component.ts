import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ProductsStateService } from '../products-state.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  id: number;
  editMode: boolean = false;
  productForm : FormGroup;

  constructor(private route: ActivatedRoute, private productsService : ProductsStateService,private router : Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.editMode = params['id'] != null;
        this.initForm();
      }
    )
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
