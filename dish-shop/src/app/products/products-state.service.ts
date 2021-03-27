import { Injectable } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { Product } from '../models/product.model';
import { ProductService } from './product.service';

@Injectable()
export class ProductsStateService{
    public productsCollectionChanged = new Subject<Product[]>();
    subscriptions : Subscription[] = []
    products : Product[] = [];

    constructor(public productServive : ProductService){
        this.subscriptions.push(this.getProducts())
    }

    getProducts(){
        return this.productServive.getAllProducts().subscribe(
            data => {
                this.reloadProducts(data)
            }
        )
    }

    reloadProducts(products : Product[]){
        this.products = products;
        this.productsCollectionChanged.next(this.products.slice());
    }

    getProduct(id: number)
    {
        return this.products.find(product => product.id === id);
    }
}