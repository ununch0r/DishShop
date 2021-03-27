import { Injectable } from '@angular/core';
import { Subject, Subscription, from } from 'rxjs';
import { Product } from '../models/product.model';
import { ProductService } from './product.service';
import {tap} from 'rxjs/operators'

@Injectable()
export class ProductsStateService{
    public productsCollectionChanged = new Subject<Product[]>();
    subscriptions : Subscription[] = []
    products : Product[] = [];

    constructor(public productServive : ProductService){
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
        product.scanCode = "sdad";
        product.categoryId = 1;
        product.producerId = 1;
        console.log('in add');
        this.productServive.createProduct(product).subscribe(
            createdProduct => {
                this.subscriptions.push(this.fetchProducts().subscribe( 
                    data => this.reloadProducts(data),
                    error => console.log(error)));
            }
        )
    }
}