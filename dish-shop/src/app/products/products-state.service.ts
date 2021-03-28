import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Product } from '../models/product.model';
import { ProductService } from './product.service';
import {tap} from 'rxjs/operators'
import { NotificationService } from '../notification.service';

@Injectable()
export class ProductsStateService{
    public productsCollectionChanged = new Subject<Product[]>();
    subscriptions : Subscription[] = []
    products : Product[] = [];

    constructor(
        public productServive : ProductService,
        private notifyService : NotificationService
    ){
        this.subscriptions.push(this.fetchProducts().subscribe( data => this.reloadProducts(data)))
    }

    fetchProducts(){
        return this.productServive.getAllProducts()
        .pipe(
            tap(
            products => {
                this.products = products;
                this.productsCollectionChanged.next(this.products.slice());
            }
        ));
    }

    reloadProducts(products : Product[]){
        this.products = products;
        this.productsCollectionChanged.next(this.products.slice());
    }

    getProduct(id: number)
    {
        return this.products.find(product => product.id === id);
    }

    getProducts(){
        return this.products.slice();
    }

    addProduct(product){
        this.productServive.createProduct(product).subscribe(
            () => {
                this.subscriptions.push(this.fetchProducts().subscribe( 
                    data => {
                        this.reloadProducts(data)
                        this.notifyService.showSuccess("Dish was added succesfully!", "Dish added!")
                    },
                    error => {
                        this.notifyService.showSuccess(error, "Error occured!")
                    }));
            }
        )
    }

    updateProduct(id: number, product){
        this.productServive.updateProduct(id, product).subscribe(
            () => {
                this.subscriptions.push(this.fetchProducts().subscribe( 
                    data =>{
                        this.reloadProducts(data)
                        this.notifyService.showSuccess("Dish was updated!", "Dish updated!")
                    } ,
                    error => console.log(error)));
            }
        )
    }

    deleteProduct(id: number){
        this.productServive.deleteProduct(id).subscribe(
            () => {
                this.products.forEach(
                    (product, index) => {
                        if(product.id === id){
                            this.products.splice(index, 1);
                        }
                    }
                )
            }
        );

        this.productsCollectionChanged.next(this.products.slice());
    }
}